using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSenseCore.UserControls
{
    public partial class CourseDetails : UserControl
    {
        private int _courseId;
        private string _courseName;
        public CourseDetails(int courseId, string courseName)
        {
            InitializeComponent();
            _courseId = courseId;
            _courseName = courseName;
        }

        private void CourseDetails_Load(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblCourse.Text = _courseName;
                sectionDetailsTableAdapter.FillBy(classSenseDataSet.SectionDetails, _courseId);
                foreach (var row in classSenseDataSet.SectionDetails)
                {
                    Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                    Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                    Guna2TileButton btnAttendance = new Guna2TileButton();
                    btnAttendance.BorderColor = SystemColors.ButtonFace;
                    btnAttendance.BorderRadius = 10;
                    btnAttendance.BorderThickness = 1;
                    btnAttendance.CustomizableEdges = customizableEdges1;
                    btnAttendance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
                    btnAttendance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
                    btnAttendance.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
                    btnAttendance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
                    btnAttendance.Font = new Font("Segoe UI", 8F);
                    btnAttendance.ForeColor = System.Drawing.Color.White;
                    btnAttendance.Name = "btnAttendance";
                    btnAttendance.ShadowDecoration.CustomizableEdges = customizableEdges2;
                    btnAttendance.Size = new System.Drawing.Size(100, 40);
                    btnAttendance.TabIndex = 150;
                    btnAttendance.Text = "Attendance";
                    DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
                    string[] dayAbbreviations = { "M", "T", "W", "Th", "F", "Sa", "Su" };

                    string currentDayAbbreviation = dayAbbreviations[(int)currentDayOfWeek-1];

                    if (row.Days.Contains(currentDayAbbreviation))
                    {
                        string[] slots = row.Slot.Split('-');
                        if (slots.Length == 2)
                        {
                            string startTime = slots[0];
                            string endTime = slots[1];

                            string currentTime = DateTime.Now.ToString("HH:mm");
                            bool bigger = currentTime.CompareTo(startTime) >= 0;
                            bool smaller = currentTime.CompareTo(endTime) <= 0;
                            if ( bigger && smaller )
                            {
                                btnAttendance.Enabled = true; // Set button visible if the current time is within the slot
                                btnAttendance.Click += (s, ev) =>
                                {
                                    frmCheckAttendance attendance = new frmCheckAttendance(row.ID);
                                    attendance.CourseID = row.CourseID;
                                    attendance.SectionLetter = row.Letter[0];
                                    attendance.CourseCode = row.Code;
                                    attendance.Show();
                                };
                            }
                            else btnAttendance.Enabled = false;
                        }
                    }
                    else btnAttendance.Enabled = false;
                    IconButton iconButton = new IconButton();
                    iconButton.BackColor = System.Drawing.Color.Transparent;
                    iconButton.IconChar= FontAwesome.Sharp.IconChar.History;
                    iconButton.IconColor = System.Drawing.Color.Black;
                    iconButton.IconSize = 28;
                    iconButton.Location = new System.Drawing.Point(375, 5);
                    iconButton.Name = "history";
                    iconButton.Size = new System.Drawing.Size(40,40);
                    iconButton.Click += (s, e) =>
                    {
                        /////////
                        ///
                        ((AdminMain)this.ParentForm).AttendanceOf(row.ID, DateTime.Now);






                    };

                    Guna2HtmlLabel lblCourse = new Guna.UI2.WinForms.Guna2HtmlLabel();
                    lblCourse.BackColor = System.Drawing.Color.Transparent;
                    lblCourse.CausesValidation = false;
                    lblCourse.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
                    lblCourse.ForeColor = System.Drawing.Color.Black;
                    lblCourse.Location = new System.Drawing.Point(26, 13);
                    lblCourse.Name = "lblSection";
                    lblCourse.TabIndex = 148;
                    lblCourse.Text = "Section " + row.Letter;
                    Guna2HtmlLabel lblSlot = new Guna.UI2.WinForms.Guna2HtmlLabel();
                    lblSlot.BackColor = System.Drawing.Color.Transparent;
                    lblSlot.CausesValidation = false;
                    lblSlot.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
                    lblSlot.ForeColor = System.Drawing.Color.Black;
                    lblSlot.Location = new System.Drawing.Point(lblCourse.Location.X+lblCourse.Width+20, 13);
                    lblSlot.Name = "lblSlot";
                    lblSlot.TabIndex = 151;
                    lblSlot.TextChanged += lblCourse_TextChanged;
                    lblSlot.Text = row.Days + " " + row.Slot;
                    btnAttendance.Location = new System.Drawing.Point(lblSlot.Location.X + lblSlot.Width + 20, 5);
                    Guna2Panel guna2Panel2 = new Guna2Panel();
                    Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                    Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                    guna2Panel2.BorderColor = System.Drawing.Color.Black;
                    guna2Panel2.BorderRadius = 10;
                    guna2Panel2.BorderThickness = 1;
                    guna2Panel2.Controls.Add(lblSlot);
                    guna2Panel2.Controls.Add(btnAttendance);
                    guna2Panel2.Controls.Add(lblCourse);
                    guna2Panel2.Controls.Add(iconButton);
                    guna2Panel2.CustomizableEdges = customizableEdges3;
                    guna2Panel2.FillColor = System.Drawing.Color.Teal;
                    guna2Panel2.Location = new System.Drawing.Point(3, 3);
                    guna2Panel2.Name = "guna2Panel2";
                    guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
                    guna2Panel2.Size = new System.Drawing.Size(flowLayoutPanel1.Width-4, 50);
                    guna2Panel2.TabIndex = 0;
                    flowLayoutPanel1.Controls.Add(guna2Panel2);
                }
            });
        }

        private void lblCourse_TextChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UserControl lbl = sender as UserControl;
                lbl.Location = new System.Drawing.Point((lbl.Parent.Width - lbl.Width) / 2, lbl.Location.Y);
            });
        }
    }

}
