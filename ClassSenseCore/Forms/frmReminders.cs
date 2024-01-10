using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassSenseCore
{
    public partial class frmReminders : Form
    {
        public long UserID;
        public frmReminders()
        {
            InitializeComponent();
        }

        private void frmReminders_Load(object sender, EventArgs e)
        {

        }
        
        private void chkNotifyme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (chkNotifyme.Checked) // Check if the checkbox is checked
            {
                DateTime selectedDate = dtPicker.Value.Date; // Get the selected date from the DateTimePicker
                string timeInput = txtTime.Text.Trim(); // Get the user-entered time from the TextBox

                if (DateTime.TryParse(timeInput, out DateTime selectedTime))
                {
                    // Combine the selected date and time
                    DateTime selectedDateTime = selectedDate.Add(selectedTime.TimeOfDay);

                    TimeSpan delay = selectedDateTime - DateTime.Now; // Calculate the delay until the selected date and time

                    if (delay.TotalMilliseconds > 0)
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = (int)delay.TotalMilliseconds;
                        timer.Tick += Timer_Tick!;
                        timer.Start();

                        MessageBox.Show($"Notification set for {selectedDateTime}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date and time. Please select a future date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid time format entered. Please enter a valid time (e.g., 10:30 AM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               //paste here

            }
            //here for the 2days in advance notification:
            if (chkAdvanceNotification.Checked)
            {
                DateTime selectedDate = dtPicker.Value.Date;

                double x = ((double)cmbDays.SelectedIndex) + 1;
                DateTime newDate = selectedDate.AddDays(-x);
                string timeInput2 = txtTime.Text.Trim(); // Get the user-entered time from the TextBox


                if (DateTime.TryParse(timeInput2, out DateTime selectedTime2))
                {
                    // Combine the selected date and time
                    DateTime selectedDateTime2 = newDate.Add(selectedTime2.TimeOfDay);

                    TimeSpan delay = selectedDateTime2 - DateTime.Now; // Calculate the delay until the selected date and time

                    if (delay.TotalMilliseconds > 0)
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = (int)delay.TotalMilliseconds;
                        timer.Tick += Timer_Tick!;
                        timer.Start();

                        MessageBox.Show($"Notification set for {selectedDateTime2}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date and time. Please select a future date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid time format entered. Please enter a valid time (e.g., 10:30 AM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //////
            else if (chkEmail.Checked)
            {
                DateTime selectedDate = dtPicker.Value.Date; // Get the selected date from the DateTimePicker
                string timeInput = txtTime.Text.Trim(); // Get the user-entered time from the TextBox

                if (DateTime.TryParse(timeInput, out DateTime selectedTime))
                {
                    // Combine the selected date and time
                    DateTime selectedDateTime = selectedDate.Add(selectedTime.TimeOfDay);

                    TimeSpan delay = selectedDateTime - DateTime.Now; // Calculate the delay until the selected date and time

                    if (delay.TotalMilliseconds > 0)
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = (int)delay.TotalMilliseconds;
                        timer.Tick += Timer_Tick;
                        timer.Start();

                        MessageBox.Show($"Notification set for {selectedDateTime}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date and time. Please select a future date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid time format entered. Please enter a valid time (e.g., 10:30 AM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        // Timer tick event handler
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer to prevent repeated notifications
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();

            // Show the notification message
            if (chkNotifyme.Checked|| chkAdvanceNotification.Checked)
                MessageBox.Show(txtMemo.Text, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (chkEmail.Checked)
            {
                string url = "https://www.gmail.com"; // Replace with the desired website URL
                OpenWebsite(url);
            }
        }


        private void numH_ValueChanged(object sender, EventArgs e)
        {
            txtTime.Text = numH.Value.ToString() + ":" + NumMin.Value.ToString();
        }

        private void NumMin_ValueChanged(object sender, EventArgs e)
        {
            txtTime.Text = numH.Value.ToString() + ":" + NumMin.Value.ToString();
        }
        private void OpenWebsite(string url)
        {
            Process.Start(url);
        }

        private void numH_ValueChanged_1(object sender, EventArgs e)
        {
            
                txtTime.Text = numH.Value.ToString() + ":" + NumMin.Value.ToString();
            }

        private void NumMin_ValueChanged_1(object sender, EventArgs e)
        {
            txtTime.Text = numH.Value.ToString() + ":" + NumMin.Value.ToString();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
    