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
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Emgu.Util;
namespace ClassSenseCore
{
    public partial class frmStudents : Form
    {
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(Path.Combine(AppDomain.CurrentDomain.BaseDirectory/*.Replace("ClassSense\\bin\\x64\\Debug\\", "")*/, "haar-cascade-files-master\\haarcascade_frontalface_alt.xml"));


        #region Variables
        private readonly object frameLock = new object();
        private object syncLock = new object();
        bool busy = false;
        Semaphore s = new Semaphore(1, 1);
        Semaphore semTrain = new Semaphore(1, 1);
        int i = 0;
        List<Image<Bgr, byte>> facesToSave = new List<Image<Bgr, byte>>();
        int nbFramesWithFaces = 0;
        private VideoCapture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool facesDetectionEnabled = true;
        bool fromUpload = false;
        public long UserID;
        
        System.Drawing.Rectangle[] currentFaces;
        #endregion
        public frmStudents()
        {
            InitializeComponent();
        }


        private async void ProcessFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
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
                        currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);
                    }
                }                //Step 2: Face Detection
                if (facesDetectionEnabled)
                {

                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    currentFaces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3);
                    //If faces detected
                    if (currentFaces.Length > 0)
                    {
                        if (guna2CircleButton1.Checked)
                            nbFramesWithFaces++;

                        foreach (var face in currentFaces)
                        {

                            //Draw square around each face 
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(System.Drawing.Color.Red).MCvScalar, 2);

                            //Step 3: Add Person 
                            //Assign the face to the picture Box face picDetected
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            /*picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = new Bitmap(new MemoryStream(resultImage.ToJpegData()));*/
                            if (guna2CircleButton1.Checked)
                            {
                                facesToSave.Add(resultImage.Resize(500, 500, Inter.Cubic));
                            }
                        }
                    }
                }
                //Render the video capture into the Picture Box picCapture
                picCapture.Image = new Bitmap(new MemoryStream(currentFrame.ToJpegData()));
            }
        }
        

        private async void btnAddPerson_ClickAsync(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var check=studentsTableAdapter.GetDataBy(txtFname.Text+" "+txtLname.Text,txtEmail.Text);
                    if(check.Count>0)
                    {
                        MessageBox.Show("This student already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lblEnterDetails.Visible = false;
                    lblWait.Visible = true;
                    progressBar.Visible = true;
                    string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                    string personPath = path + @"\" + txtFname.Text + txtLname.Text;
                    var student = classSenseDataSet.Students.NewStudentsRow();
                    student.Email = txtEmail.Text;
                    student.Fname = txtFname.Text;
                    student.LName = txtLname.Text;
                    studentsTableAdapter.Insert(student.Fname, student.LName, student.Email);

                    // Refresh the dataset to fetch the updated values from the database
                    studentsTableAdapter.Fill(classSenseDataSet.Students);

                    // Get the actual ID assigned by the database
                    int newStudentID = classSenseDataSet.Students.Max(s => s.ID);

                    var images = classSenseDataSet.Images.NewImagesRow();
                    images.URL="TrainedImages\\" + txtFname.Text + txtLname.Text;
                    images.StudentID = newStudentID;
                    imagesTableAdapter.Insert(images.URL, images.StudentID);
                    imagesTableAdapter.Update(images);
                    if (!Directory.Exists(personPath))
                        Directory.CreateDirectory(personPath);
                    await Task.Factory.StartNew(() =>
                    {
                        double percentage= 0;
                        foreach (var item in facesToSave)
                        {
                            item.Resize(1000, 1000, Inter.Cubic).Save(personPath + @"\" + txtFname.Text + txtLname.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss-FFFFFFF") + ".jpg");
                            percentage += 100.0 / (double) facesToSave.Count;
                            progressBar.Value +=(int)percentage;
                        }
                        /*if(progressBar.Value<100)
                            progressBar.Value = 100;*/
                    });

                    this.Height = 532;
                    txtEmail.Text = "";
                    txtFname.Text = "";
                    txtLname.Text = "";
                    btnAddPerson.Enabled = false;
                    Train.TrainImagesFromDirAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                await Train.TrainImagesFromDirAsync();
            }
        }

        

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            studentsTableAdapter.Fill(classSenseDataSet.Students);
            Train.TrainImagesFromDirAsync();
        }

        private async void backgroundWorker1_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke(new Action(() => { Cursor = Cursors.WaitCursor; }));
            await Train.TrainImagesFromDirAsync();
            this.BeginInvoke(new Action(() => { Cursor = Cursors.Default; }));

        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            startPanel.Visible = false;
            btnCancel.Visible = true;
            fromUpload = false;
            videoCapture = new VideoCapture(0);
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();
            facesDetectionEnabled = true;
            guna2CircleButton1.Visible = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            fromUpload = true;
            startPanel.Visible = false;
            btnCancel.Visible = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDetailsUp.Visible = true;
                lblWaitUp.Visible = true;
                this.Height = 738;
                /*FileVideoSource videoSource=new FileVideoSource(openFileDialog1.FileName);
                AsyncVideoSource asyncSource = new AsyncVideoSource(videoSource);
                asyncSource.SkipFramesIfBusy = false;
                asyncSource.PlayingFinished += (s, args) =>
                {
                    if (nbFramesWithFaces > facesToSave.Count * 1.05)
                    {
                        MessageBox.Show("Multiple faces have been detected!", "Error proccessing images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        startPanel.Visible = true;
                    }
                    else
                    {
                        this.BeginInvoke(new Action(() => {
                            lblDetailsUp.Visible = false;
                            lblWaitUp.Visible = false;
                            btnAddPerson.Enabled = true;
                            lblEnterDetails.Visible = true;
                        }));
                    }
                    */

                /*videoCapture = new VideoCapture(openFileDialog1.FileName);
                    videoCapture.ImageGrabbed += ProcessFrame;
                    videoCapture.Start();*//*
                    facesDetectionEnabled = true;
                    guna2CircleButton1.Checked = true;
                };
                asyncSource.NewFrame += (esender, eventArgs) =>
                {
                    currentFrame = Image<Bgr, byte>.FromIplImagePtr(eventArgs.Frame.GetHbitmap());
                    if (facesDetectionEnabled)
                    {
                        //Convert from Bgr to Gray Image
                        Mat grayImage = new Mat();
                        CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                        //Enhance the image to get better result
                        CvInvoke.EqualizeHist(grayImage, grayImage);

                        currentFaces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3);
                        //If faces detected
                        if (currentFaces.Length > 0)
                        {
                            if (guna2CircleButton1.Checked)
                                nbFramesWithFaces++;

                            foreach (var face in currentFaces)
                            {
                                //Assign the face to the picture Box face picDetected
                                Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                                resultImage.ROI = face;
                                if (guna2CircleButton1.Checked)
                                {
                                    facesToSave.Add(resultImage.Resize(1000, 1000, Inter.Cubic));
                                }
                            }
                        }
                    }

                };
                asyncSource.Start();*/

                Task.Run(() =>
                {
                    using (VideoCapture capture = new VideoCapture(openFileDialog1.FileName))
                    {
                        double totalFrames = capture.Get(Emgu.CV.CvEnum.CapProp.FrameCount);
                        double length = totalFrames/2;
                        Task[] tasks = new Task[(int)length];
                        for (int i = 0; i < length; i++)
                        {
                            int startFrame = (int)((double)totalFrames / length) * i;
                            int endFrame = (int)((double)totalFrames / length) * (i + 1);
                            tasks[i] = Task.Run(() =>
                                {
                            for (int j = startFrame; j < endFrame; j++)
                            {
                                Image<Bgr, Byte> frame = null;
                                Mat frameMat;
                                lock (syncLock)
                                {
                                            // Move to the desired frame
                                    capture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, j);
                                            // Safely capture the frame
                                    frameMat = capture.QueryFrame();
                                }
                                if (frameMat != null)
                                {
                                    lock (syncLock)
                                    {
                                        frame = frameMat.ToImage<Bgr, Byte>();
                                    }
                                    ProcessFrame(frame);
                                }
                                else
                                {
                                            // Handle the case when the frame could not be captured
                                }
                            }
                        });
                        }
                        Task.WaitAll(tasks);
                        HandleFinishedPlaying();
                    }
                });// Wait for all tasks to complete

                // Code to execute after all frames are processed
            }
        }
        private void HandleFinishedPlaying()
        {
            if (nbFramesWithFaces * 1.1 < facesToSave.Count)
            {
                MessageBox.Show("Multiple faces have been detected!", "Error proccessing images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startPanel.Visible = true;
            }
            else
            {
                this.BeginInvoke(new Action(() => {
                    lblDetailsUp.Visible = false;
                    lblWaitUp.Visible = false;
                    btnAddPerson.Enabled = true;
                    lblEnterDetails.Visible = true;
                }));
            }
        }
        private void ProcessFrame(Image<Bgr, Byte> frame)
        {
            Image<Bgr, byte> currentFrame = frame;
            if (facesDetectionEnabled)
            {
                //Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                currentFaces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3);
                //If faces detected
                if (currentFaces.Length > 0)
                {
                    lock (syncLock)
                    {
                        nbFramesWithFaces++;
                    }

                    foreach (var face in currentFaces)
                    {
                        //Assign the face to the picture Box face picDetected
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        lock (syncLock)
                        {
                            facesToSave.Add(resultImage.Resize(1000, 1000, Inter.Cubic));
                        }
                    }
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (guna2CircleButton1.Checked)
            {
                guna2CircleButton1.ImageSize = new System.Drawing.Size(58, 58);
            }
            else
            {
                guna2CircleButton1.ImageSize = new System.Drawing.Size(50, 50);
                guna2CircleButton1.Visible = false;
                videoCapture.Stop();
                videoCapture.Dispose();
                picCapture.Image = null;
                if (!startPanel.Visible)
                {
                    if (nbFramesWithFaces > facesToSave.Count * 1.05)
                    {
                        MessageBox.Show("Multiple faces have been detected!", "Error proccessing images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        startPanel.Visible = true;
                    }
                    else
                    {
                        lblEnterDetails.Visible = true;
                        this.Height = 738;
                        btnAddPerson.Enabled = true;
                    }
                }
            }
        }

        private void progressBar_ValueChanged(object sender, EventArgs e)
        {
            if (progressBar.Value >= 100)
            {
                this.BeginInvoke(() =>
                {
                    progressBar.Visible = false;
                    lblWait.Visible = false;
                    progressBar.Value = 0;
                });
            }
        }

        private void frmStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (Train.istraining) ;
            videoCapture.Dispose();
            picCapture.Image = null;
        }

        private void txtPersonName_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox? txt = sender as Guna2TextBox;
            if (string.IsNullOrEmpty(txt!.Text))
            {
                e.Cancel = true;
                txtFname.Focus();
                errorProvider1.SetError(txt, "Please " + txt.PlaceholderText.ToLower());
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(guna2CircleButton1.Checked)
            {
                MessageBox.Show("Please stop the camera before canceling the form.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }    
            if (videoCapture != null)
            {
                videoCapture.Dispose();
            }
            facesToSave.Clear();
            lblEnterDetails.Visible = false; 
            picCapture.Image = null;
            startPanel.Visible = true;
            btnAddPerson.Enabled = false;
            btnCancel.Visible = false;
        }
    }
}
