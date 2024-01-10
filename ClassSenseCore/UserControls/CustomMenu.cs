using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassSenseCore.UserControls
{
    public partial class CustomMenu : UserControl
    {
        private int selectedIndex = 0;
        public event EventHandler SelectedIndexChanged;
        public int SelectedIndex { get { return selectedIndex; } }
        public CustomMenu()
        {
            InitializeComponent();
        }
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, e);
        }
        public void UpdateSelectedIndex(int newIndex)
        {
            if (selectedIndex != newIndex-1)
            {
                selectedIndex = newIndex-1;
                OnSelectedIndexChanged(EventArgs.Empty);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (sender != guna2Button8)
            {
                if (guna2Button8.Visible)
                {
                    ToggleAttendance();
                }
            }
            else { guna2Button8.Checked = true; guna2Button4.Checked = false; }
            Guna2Button btn = sender as Guna2Button;
            Console.WriteLine(btn.Tag);
            int.TryParse(btn.Tag.ToString(),out int i);
            foreach(var x in bunifuPanel1.Controls)
            {
                if(x is Guna2PictureBox pic)
                {
                    if (pic.Tag == btn.Tag)
                        pic.Visible = true;
                    else pic.Visible = false;
                }
            }
            UpdateSelectedIndex(i);
        }

        private void guna2Button1_MouseEnter(object sender, EventArgs e)
        { 
            Guna2Button btn = sender as Guna2Button;
            if(!btn.Checked)
                btn.ImageSize = new System.Drawing.Size(50, 50);
        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if(!btn.Checked)
                btn.ImageSize = new System.Drawing.Size(45,45);
        }

        public void ToggleAttendance()
        {
            // Store the current positions
            System.Drawing.Point tempButtonPosition = guna2Button7.Location;
            System.Drawing.Point tempPictureBoxPosition = guna2PictureBox7.Location;

            // Swap positions
            guna2PictureBox7.Location = guna2PictureBox8.Location;
            guna2Button7.Location = guna2Button8.Location;

            guna2PictureBox8.Location = tempPictureBoxPosition;
            guna2Button8.Location = tempButtonPosition;
            guna2PictureBox8.BringToFront();
            // Make guna2Button8 and guna2PictureBox8 visible
            guna2Button8.Visible = !guna2Button8.Visible;
            if (!guna2Button8.Checked && guna2Button8.Visible)
            {
                guna2Button1_Click(guna2Button8,EventArgs.Empty);
            }
            if(!guna2Button8.Visible) { guna2PictureBox8.Visible = false; }
            UpdateSelectedIndex(int.Parse(guna2Button8.Tag.ToString()));
        }
    }
}
