using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using ClassSenseCore.ClassSenseDataSetTableAdapters;
using System.Timers;
using Stimulsoft.Controls.Win.DotNetBar.Controls;
namespace ClassSenseCore
{
    public partial class frmCheckAttendance : Form
    {
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(Path.Combine(AppDomain.CurrentDomain.BaseDirectory/*.Replace("ClassSense\\bin\\x64\\Debug\\", "")*/, "haar-cascade-files-master\\haarcascade_frontalface_alt.xml"));


        #region Variables
        List<ClassSenseDataSet.AttendsRow> rows;
        List<DataGridViewRow> gridRows;
        int errorCount = 0;
        int totalAttendance = 0;
        private System.Windows.Forms.Timer timer;
        public long UserID;
        public int CourseID;
        public string CourseCode;
        public char SectionLetter;
        private readonly object frameLock = new object();
        bool busy = false;
        List<Image<Bgr, byte>> facesToSave = new List<Image<Bgr, byte>>();
        private VideoCapture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        private Image<Bgr, Byte> CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                if (currentFrame == null)
                {

                }
                this.currentFrame = value;
            }
        }
        Mat frame = new Mat();
        private bool facesDetectionEnabled = true;
        System.Drawing.Rectangle[] currentFaces;
        Dictionary<string, int> Attendance = new Dictionary<string, int>();
        int SectionID = -1;
        #endregion
        public frmCheckAttendance(int SectionID)
        {
            InitializeComponent();
            this.SectionID = SectionID;
        }


        private async void ProcessFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                if (Train.recognizer == null)
                {
                    if (!Train.istraining)
                        await Train.TrainImagesFromDirAsync();
                    return;
                }
                while (videoCapture.Retrieve(frame, 0) == false) ;
                if (frame.IsEmpty)
                {
                    ProcessFrame(sender, e);
                    return;
                }
                else
                {
                    lock (frameLock)
                    {
                        CurrentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);
                    }
                }
                //Step 2: Face Detection
                if (facesDetectionEnabled)
                {

                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(CurrentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    currentFaces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3);
                    //If faces detected
                    if (currentFaces.Length > 0)
                    {
                        foreach (var face in currentFaces)
                        {

                            //Draw square around each face 
                            CvInvoke.Rectangle(CurrentFrame, face, new Bgr(System.Drawing.Color.Red).MCvScalar, 2);
                            Image<Bgr, Byte> resultImage = CurrentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            facesToSave.Add(resultImage.Resize(1000, 1000, Inter.Cubic));


                            // Step 5: Recognize the face 
                            if (Train.isTrained && !busy)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(1000, 1000, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = Train.recognizer.Predict(grayFaceResult);
                                if (result.Label != -1 && result.Distance < 100 && Train.PersonsNames.Count > 0) // Increase the threshold to improve face recognition
                                {
                                    Debug.WriteLine(result.Label + ". " + result.Distance);
                                    //Here results found known faces
                                    CvInvoke.PutText(CurrentFrame, Train.PersonsNames[result.Label], new System.Drawing.Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(System.Drawing.Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(CurrentFrame, face, new Bgr(System.Drawing.Color.Green).MCvScalar, 2);
                                    if (Attendance.ContainsKey(Train.PersonsNames[result.Label]))
                                    {
                                        Attendance[Train.PersonsNames[result.Label]]++;
                                        totalAttendance++;
                                    }
                                    else errorCount++;
                                }

                                else
                                {
                                    CvInvoke.PutText(CurrentFrame, "Unknown", new System.Drawing.Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(System.Drawing.Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(CurrentFrame, face, new Bgr(System.Drawing.Color.Red).MCvScalar, 2);

                                }
                            }
                        }
                    }
                }
                //Render the video capture into the Picture Box picCapture
                picCapture.Image = new Bitmap(new MemoryStream(CurrentFrame.ToJpegData()));
            }
        }

        //Step 4: train Images .. we will use the saved images from the previous example 5  

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync("ReadModel");
            studentsTableAdapter.FillBySection(classSenseDataSet.Students, SectionID);
            var students = studentsTableAdapter.GetDataBySection(SectionID);
            foreach (var student in students)
            {
                Attendance.Add(student.Fname + student.LName, 0);
            }
            videoCapture = new VideoCapture(0);
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();
            lblTitle.Text = "Attendance for " + CourseCode + " " + SectionLetter;
        }

        private async void backgroundWorker1_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke(new Action(() => { Cursor = Cursors.WaitCursor; }));
            if (e.Argument == null)
                await Train.TrainImagesFromDirAsync();
            else
            {
                Train.istraining = true;
                string path = "TrainedImages\\trained_model.xml";
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                if (File.Exists(path))
                {
                    Train.recognizer = new LBPHFaceRecognizer();
                    Train.recognizer.Read(path);
                    Train.isTrained = true;
                }
                Train.ReadLabelsFile();
                Train.istraining = false;
            }
            this.BeginInvoke(new Action(() => { Cursor = Cursors.Default; }));

        }

        private void frmStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCapture != null)
                videoCapture.Dispose();
            picCapture.Image = null;
        }

        private void lblTitle_TextChanged(object sender, EventArgs e)
        {
            UserControl lbl = sender as UserControl;
            lbl.Location = new System.Drawing.Point((this.Width - lbl.Width) / 2, lbl.Location.Y);
        }

        public (List<ClassSenseDataSet.AttendsRow>, List<DataGridViewRow>) computeAttendance()
        {
            List<ClassSenseDataSet.AttendsRow> rows = new List<ClassSenseDataSet.AttendsRow>();
            List<DataGridViewRow> gridRows = new List<DataGridViewRow>();
            foreach ((string key, int value) in Attendance)
            {
                DataGridViewRow gridRow = new DataGridViewRow();
                var row = classSenseDataSet.Attends.NewAttendsRow();
                int StudentID = studentsTableAdapter.GetDataByFullName(key)[0].ID;
                row.StudentID = StudentID;
                gridRow.Cells.Add(new DataGridViewTextBoxCell() { Value = StudentID });
                row.SectionID = SectionID;
                gridRow.Cells.Add(new DataGridViewTextBoxCell() { Value = SectionID });
                row.Date = DateTime.Now;
                gridRow.Cells.Add(new DataGridViewDateTimeInputCell() { ValueType = Type.GetType("DateTime"), Value = StudentID });

                if (value > totalAttendance / Attendance.Count - 2)
                {
                    row.IsPresent = true;
                    gridRow.Cells.Add(new DataGridViewCheckBoxCell() { TrueValue=true,FalseValue=false, Value = true });
                }

                else
                {
                    row.IsPresent = false;
                    gridRow.Cells.Add(new DataGridViewCheckBoxCell() { TrueValue = true, FalseValue = false, Value = false });
                }
                rows.Add(row);
                gridRows.Add(gridRow);
            }
            return (rows, gridRows);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[3].ReadOnly = !guna2GradientButton1.Checked;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 3)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ((bool)cell.Value)
                    rows[e.RowIndex].IsPresent = true;
                else
                    rows[e.RowIndex].IsPresent = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (var row in rows)
                new AttendsTableAdapter().Insert(row.StudentID, row.SectionID, row.Date, row.IsPresent);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            (rows, gridRows) = computeAttendance();
            timer1.Stop();
            gridRows.ForEach(r => dataGridView1.Rows.Add(r));
            videoCapture.Dispose();
            picCapture.Image = null;
            dataGridView1.Visible = true;
            dataGridView1.Invalidate();
        }
    }
}
