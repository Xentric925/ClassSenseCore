using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSenseCore
{
    public partial class Splash : Form
    {
        frmLogin frm;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Logo.uiMode = "none";
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "splash.mp4";
            Logo.Ctlenabled = false;
            Logo.stretchToFit = true;
            Logo.URL = path;
        }



        private void Logo_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (Logo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                frm = new frmLogin();
            }
            if (Logo.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    frm.Show();
                });
            }
        }
    }
}
