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

namespace ClassSenseCore
{
    public partial class frmInstructor : Form
    {
        public frmInstructor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        #region Variables
        
        public long UserID = -1;

        #endregion

        private void btnCapture_Click(object sender, EventArgs e)
        {
            
        }


        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {

        }
        //Step 4: train Images .. we will use the saved images from the previous example 

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
