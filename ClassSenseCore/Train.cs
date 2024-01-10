using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore
{
    internal class Train
    {
        public static List<string> PersonsNames = new List<string>();
        public static List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        public static List<int> PersonsLabels = new List<int>();
        public static bool istraining = false;
        public static bool isTrained = false;
        public static LBPHFaceRecognizer recognizer;

        public static async Task TrainImagesFromDirAsync()
        {
            istraining = true;
            isTrained = false;
            int ImagesCount = -1;
            //double Threshold = 50000; // Increase the threshold to improve face recognition
            TrainedFaces.Clear();
            PersonsLabels.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                if (!Directory.Exists(path))
                    return;
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {

                        Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(500, 500, Inter.Cubic);
                        CvInvoke.EqualizeHist(trainedImage, trainedImage);
                        string name = file.Split('\\').Last().Split('_')[0];
                        /*semTrain.WaitOne();
                        Interlocked.Increment(ref ImagesCount);*/
                        ImagesCount++;

                        TrainedFaces.Add(trainedImage);
                        PersonsLabels.Add(ImagesCount);
                        PersonsNames.Add(name);

                        /*semTrain.Release();*/
                        Debug.WriteLine(ImagesCount + ". " + name);
                    }
                });
                if (TrainedFaces.Count() > 0)
                {
                    // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                    recognizer = new LBPHFaceRecognizer();
                    List<Mat> t = new List<Mat>();
                    TrainedFaces.ToList().ForEach(l =>
                    {
                        t.Add(l.Mat);
                    }
                        );
                    recognizer.Train(t.ToArray(), PersonsLabels.ToArray());

                    string modelPath = "TrainedImages\\trained_model.xml";
                    modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelPath);
                    recognizer.Write(modelPath);
                    CreateLabelsFile();
                    isTrained = true;
                    istraining = false;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                }
                else
                {
                    isTrained = false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
            }
            

        }
        public static void CreateLabelsFile()
        {
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages\Labels.csv";
            StringBuilder csvContent = new StringBuilder();

            for (int i = 0; i < PersonsNames.Count; i++)
            {
                csvContent.AppendLine($"{PersonsLabels[i]},{PersonsNames[i]}");
            }

            File.WriteAllText(path, csvContent.ToString());
            TrainedFaces.Clear();
            PersonsLabels.Clear();
            PersonsNames.Clear();
        }
        public static void ReadLabelsFile()
        {
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages\Labels.csv";
            if (File.Exists(path))
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    PersonsLabels.Add(int.Parse(parts[0]));
                    PersonsNames.Add(parts[1]);
                }
            }
        }
    }
}
