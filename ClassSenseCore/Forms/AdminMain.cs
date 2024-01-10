using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using ClassSenseCore.Properties;
using ClassSenseCore.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using ClassSenseCore.ClassSenseDataSetTableAdapters;

namespace ClassSenseCore
{
    public partial class AdminMain : Form
    {
        string categoryFilter = "", searchFilter = "", supplierFilter = "", priceFilter = "";
        private long receiptID = -1;
        public long InstructorID;

        Semaphore s = new Semaphore(0, 1);
        /*
        private int batchSize = 20; // Number of products to load in each batch
        private int loadedCount = 0; // Number of products already loaded
        private bool isLoading = false; // Indicates if a loading operation is already in progress*/
        private string OrderByFilter;
        private int toggle = 0;
        bool busy = false;
        bool isVisible = false; int nbPressedSort = 0; public string UserEmail; public long UserID = 1; bool comboPanelCreated = false;
        public AdminMain()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }


        private void customMenu1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = customMenu1.SelectedIndex;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'classSenseDataSet3.Reminders1' table. You can move, or remove it, as needed.
            this.reminders1TableAdapter.FillReminder(this.classSenseDataSet.Reminders1);
            // TODO: This line of code loads data into the 'classSenseDataSet5.AdminStudents' table. You can move, or remove it, as needed.
            this.adminStudentsTableAdapter.FillAdminStudent(this.classSenseDataSet.AdminStudents);
            // TODO: This line of code loads data into the 'classSenseDataSet3.Instructors' table. You can move, or remove it, as needed.
            this.instructorsTableAdapter.Fill(this.classSenseDataSet.Instructors);
            // TODO: This line of code loads data into the 'classSenseDataSet.Courses' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'classSenseDataSet.Attends' table. You can move, or remove it, as needed.
            this.attendsTableAdapter.Fill(this.classSenseDataSet.Attends);
            if (!busy)
                backgroundWorker1.RunWorkerAsync();
            this.reportViewer1.RefreshReport();
            /*this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();*/
        }



        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            //For the button add+
            switch (guna2TabControl1.SelectedIndex)
            {
                /*case 0: // Dashboard
                    frmDashboard frm = new frmDashboard();
                    frm.UserID = this.UserID;
                    frm.ShowDialog();
                    if (!busy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    break;*/
                case 1: // Instructor
                    frmInstructor frm1 = new frmInstructor();
                    frm1.UserID = this.UserID;
                    frm1.ShowDialog();
                    if (!busy)
                    {
                        backgroundWorker1.RunWorkerAsync("Instructor");
                    }
                    break;
                case 2: // Students
                    frmStudents frm2 = new frmStudents();
                    frm2.UserID = this.UserID;
                    frm2.ShowDialog();
                    if (!busy)
                    {
                        backgroundWorker1.RunWorkerAsync("Students");
                    }
                    break;
                /* case 3: // Attendance
                     frmAttendance frm3 = new frmAttendance();
                     frm3.UserID = this.UserID;
                     frm3.ShowDialog();
                     if (!busy)
                     {

                         backgroundWorker1.RunWorkerAsync("Attendance");
                     }
                     break;
                 case 4: // Reports
                     frmReports frm4 = new frmReports();
                     frm4.UserID = this.UserID;
                     frm4.ShowDialog();
                     if (!busy)
                     {

                         backgroundWorker1.RunWorkerAsync("Reports");
                     }
                     break;*/
                case 5: // Reminders
                    frmReminders frm5 = new frmReminders();
                    frm5.UserID = this.UserID;
                    frm5.ShowDialog();
                    if (!busy)
                    {

                        backgroundWorker1.RunWorkerAsync("Reminders");
                    }
                    break;/*
                case 6: // Settings
                    frmSettings frm6 = new frmSettings();
                    frm6.UserID = this.UserID;
                    frm6.ShowDialog();
                    if (!busy)
                    {
                        
                        backgroundWorker1.RunWorkerAsync("Settings");
                    }
                    break;*/
            }

        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Invalidate();
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            guna2Panel1.Cursor = Cursors.SizeAll;
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            guna2Panel1.Cursor = Cursors.Default;
        }

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                Cursor = Cursors.Default;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.Invalidate();

            if (this.Height < 630 && bunifuPanel3.CustomizableEdges.BottomLeft == true)
            {
                bunifuPanel3.CustomizableEdges.BottomLeft = false;
            }
            else
            {
                if (this.Height < 630 && bunifuPanel3.CustomizableEdges.BottomLeft == false)
                {
                    bunifuPanel3.CustomizableEdges.BottomLeft = true;
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(iconButton2.PointToScreen(new System.Drawing.Point(0, iconButton2.Height)));
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                sortPanel.Visible = true;
                isVisible = true;
            }
            else
            {
                sortPanel.Visible = false;
                isVisible = false;
            }
        }

        /*private void guna2Button1_Click(object sender, EventArgs e)
        {
            CustomComboBox btn = sender as CustomComboBox;
            if (btn.IsChecked && !this.Controls["pnl" + btn.Name].Visible)
            {
                sortPanel.Controls.SetChildIndex(btn, 0);
                btn.Checked();
                nbPressedSort++;
                if (btn.isPriceFilter)
                {
                    priceFilter = "Price >=" + btn.startPrice + " AND Price <=" + btn.endPrice;
                }
                else
                {
                    List<int> l = btn.CheckStates
                            .Select((value, index) => new { Value = value, Index = index })
                            .Where(item => item.Value)
                            .Select(item => item.Index)
                            .ToList();
                    foreach (int item in l)
                    {
                        if (btn.PlaceHolderText == "Supplier")
                        {
                            supplierFilter = "SuppName = '" + this.Controls["pnl" + btn.Name].Controls[item].Text + "' OR ";
                            supplierFilter = supplierFilter.Substring(0, supplierFilter.Length - 3);
                        }

                        else
                        {
                            categoryFilter = "Category = '" + this.Controls["pnl" + btn.Name].Controls[item].Text + "' OR ";
                            categoryFilter = categoryFilter.Substring(0, categoryFilter.Length - 3);
                        }
                    }
                }
            }
            else
            {
                if (!btn.IsChecked && !this.Controls["pnl" + btn.Name].Visible)
                {
                    if (btn.PlaceHolderText == "Supplier")
                        supplierFilter = "";
                    else if (btn.PlaceHolderText == "Category")
                        categoryFilter = "";
                    else
                    {
                        priceFilter = "";
                    }
                        sortPanel.Controls.SetChildIndex(btn, int.Parse(btn.Tag.ToString()) + (--nbPressedSort));
                    btn.UnChecked();
                }
            }
            updateFilter();
        }*/

        private void updateFilter()
        {/*
            bsProductCard.Filter = supplierFilter==""?"":"("+supplierFilter+")";
            bsProductCard.Filter += bsProductCard.Filter == "" ? (categoryFilter == "" ? "" : "(" + categoryFilter + ")"):(categoryFilter==""?"": " AND (" + categoryFilter+")");
            bsProductCard.Filter += bsProductCard.Filter == "" ? (searchFilter == "" ? "" : " (" + searchFilter + ")") : (searchFilter == "" ? "" : " AND (" + searchFilter+")");
            bsProductCard.Filter += bsProductCard.Filter == "" ? (priceFilter == "" ? "" : " (" + priceFilter + ")") : (priceFilter == "" ? "" : " AND (" + priceFilter + ")");
           */
            if (!busy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            // Check if the search term is not empty
            if (!string.IsNullOrEmpty(searchValue))
            {
                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in AdminStudentsGrid.Rows)
                {
                    // Assuming the names are in the first column (index 0)
                    string cellValue = row.Cells[0].Value.ToString();

                    // Case-insensitive search
                    if (cellValue.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // Highlight the row, scroll to it, or take any other action
                        row.Selected = true;
                        AdminStudentsGrid.CurrentCell = row.Cells[0]; // Set focus on the first cell of the row
                        break; // Stop searching after the first match
                    }
                }
            }
            else
            {
                // Clear selection if the search term is empty
                AdminStudentsGrid.ClearSelection();
            }
            /* searchFilter = "";
             if (!string.IsNullOrEmpty(txtSearch.Text))
                 searchFilter = "Title like '%" + txtSearch.Text + "%' OR Description like '%" + txtSearch.Text + "%'";
             else searchFilter = "";
             updateFilter();*/
        }

        public void customComboBoxPressed(ref Guna2Panel panel, CustomComboBox sender, Guna2VScrollBar scrollBar)
        {
            if (!sender.PanelCreated)
            {
                this.Controls.Add(panel);
                panel.BringToFront();
                System.Drawing.Point p = sender.Location;
                p.Offset(new System.Drawing.Point(guna2Panel3.Right + sortPanel.Location.X + 6, bunifuPanel2.Location.Y - 3 + sender.Bottom));
                panel.Location = p;
                panel.Name = "pnl" + sender.Name;
                comboPanelCreated = true;
                panel.Height = (int)(sender.Width / 1.2) + 10;
                panel.Width = sender.Width - 10;
                panel.Anchor = AnchorStyles.Top & AnchorStyles.Left;
                panel.Controls.Add(scrollBar);
                panel.Padding = new Padding(2, 2, 0, 0);
                scrollBar.BindingContainer = panel;
                Guna2Panel c = panel;
                panel.VisibleChanged += (s, e) => { if (!c.Visible) sender.buttonPressed(); };
            }
            else
            {
                if (!sender.IsChecked)
                {
                    System.Drawing.Point p = sender.Location;
                    p.Offset(new System.Drawing.Point(guna2Panel3.Right + sortPanel.Location.X + 6, bunifuPanel2.Location.Y - 3 + sender.Bottom));
                    this.Controls["pnl" + sender.Name].Location = p;
                    this.Controls["pnl" + sender.Name].Visible = this.Controls["pnl" + sender.Name].Visible ? false : true;
                }
                else { sender.IsChecked = false;/* sender.UnChecked();*/ }
            }
        }
        public void customComboBoxPressed(ref Guna2Panel panel, CustomComboBox sender)
        {
            if (!sender.PanelCreated)
            {
                this.Controls.Add(panel);
                panel.BringToFront();
                System.Drawing.Point p = sender.Location;
                p.Offset(new System.Drawing.Point(guna2Panel3.Right + sortPanel.Location.X + 6, bunifuPanel2.Location.Y - 3 + sender.Bottom));
                panel.Location = p;
                panel.Name = "pnl" + sender.Name;
                comboPanelCreated = true;
                panel.Height = (int)(sender.Width / 1.2) + 10;
                panel.Width = sender.Width - 10;
                panel.Anchor = AnchorStyles.Top & AnchorStyles.Left;
                Guna2Panel c = panel;
                panel.VisibleChanged += (s, e) => { if (!c.Visible) sender.buttonPressed(); };
            }
            else
            {
                if (!sender.IsChecked)
                {
                    System.Drawing.Point p = sender.Location;
                    p.Offset(new System.Drawing.Point(guna2Panel3.Right + sortPanel.Location.X + 6, bunifuPanel2.Location.Y - 3 + sender.Bottom));
                    this.Controls["pnl" + sender.Name].Location = p;
                    this.Controls["pnl" + sender.Name].Visible = this.Controls["pnl" + sender.Name].Visible ? false : true;
                }
                else { sender.IsChecked = false; sender.UnChecked(); sender.toggle = 0; }
            }
        }


        private void AdminMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboPanelCreated)
            {
                foreach (var item in this.Controls.OfType<Guna2Panel>().Where(c => c.Name.StartsWith("pnlcmb")))
                {
                    item.Visible = false;
                }
            }
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IconButton btn in guna2Panel2.Controls.OfType<IconButton>())
            {
                string tag = btn.Tag.ToString();
                bunifuToolTip1.SetToolTip(btn, tag.Substring(0, tag.IndexOf(" ") != -1 ? tag.IndexOf(" ") + 1 : tag.Length) + " " + guna2TabControl1.SelectedTab.Name + " " + (tag.IndexOf(" ") != -1 ? tag.Substring(tag.IndexOf(" ") + 1) : ""));
            }
            switch (guna2TabControl1.SelectedIndex)
            {
                case 0:
                    backgroundWorker1.RunWorkerAsync();
                    break;
                case 3:
                    backgroundWorker1.RunWorkerAsync("sect");

                    break;
                case 1:
                    backgroundWorker1.RunWorkerAsync("inst");
                    break;
                case 2:
                    backgroundWorker1.RunWorkerAsync("std");

                    break;
                case 4:
                    backgroundWorker1.RunWorkerAsync("reports");
                    break;
                case 5:
                    backgroundWorker1.RunWorkerAsync("reminders");
                    break;
                case 6:
                    backgroundWorker1.RunWorkerAsync("settings");
                    break;

            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            busy = true;
            if (e.Argument != null)
            {
                switch (e.Argument)
                {
                    case "sect":
                        this.Invoke((MethodInvoker)delegate { pnlCourses.Controls.Clear(); });
                        new CoursesTableAdapter().Fill(classSenseDataSet.Courses);
                        foreach (var row in classSenseDataSet.Courses)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                CourseDetails course = new CourseDetails(row.ID, row.Code);
                                AddCourse(course);
                            });

                        }
                        break;
                    case "inst":
                        new InstructorsTableAdapter().Fill(classSenseDataSet.Instructors);
                        break;
                    case "std":
                        adminStudentsTableAdapter.FillAdminStudent(classSenseDataSet.AdminStudents);
                        sectionDetailsTableAdapter.FillBy1(classSenseDataSet.SectionDetails);
                        this.BeginInvoke(() =>
                        {
                            sectionDetailsBindingSource.ResetBindings(false);
                            foreach (DataGridViewRow row in AdminStudentsGrid.Rows)
                            {
                                string path = AppDomain.CurrentDomain.BaseDirectory;
                                path = Path.Combine(path, row.Cells[5].Value.ToString());
                                string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }; // Define image extensions

                                // Get all files in the folder with image extensions
                                string[] imageFiles = Directory.GetFiles(path)
                                                              .Where(file => imageExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                                              .ToArray();

                                if (imageFiles.Length > 0)
                                {
                                    path = imageFiles[0];
                                }
                                if (File.Exists(path))
                                    ((DataGridViewImageCell)row.Cells[0]).Value = new Bitmap(path);
                            }
                        });
                        break;
                }
            }
            else
            {

            }
            busy = false;
        }

        private void AddCourse(CourseDetails course)
        {
            pnlCourses.Controls.Add(course);
        }

        private void instructorGrid1_SelectionChanged(object sender, EventArgs e)
        {
            Guna2DataGridView gridView = (Guna2DataGridView)sender;
            if (gridView.SelectedRows.Count > 0)
            {
                InstructorID = long.Parse(gridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
            {
                InstructorID = -1;
            }
            sectionDetailsBindingSource.Filter="InstructorID="+InstructorID;
        }

        private void instructorGrid2_SelectionChanged(object sender, EventArgs e)
        {
        }



        private void receiptsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /*if (e.Context.HasFlag(DataGridViewDataErrorContexts.Display))
            {
                var cell = receiptsGrid[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DisplayStyle= DataGridViewComboBoxDisplayStyle.Nothing;
                if (cell != null)
                {
                    if (cell.Items.Count > 0)
                    {
                        cell.Value = cell.Items[0]; // Assign the first item as the value
                    }
                    else
                    {
                        cell.Value = DBNull.Value; // Handle the case where there are no items
                    }
                    e.ThrowException = false;
                }
            }*/
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Assuming the names are in the first column (index 0)
            string columnName = "Name"; // Replace with the actual column name

            // Sorting the data in descending order
            InstuctorGrid2.Sort(InstuctorGrid1.Columns[columnName], ListSortDirection.Descending);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Assuming the names are in the first column (index 0)
            string columnName = "FName"; // Replace with the actual column name

            // Sort the data in ascending order
            InstuctorGrid1.Sort(InstuctorGrid1.Columns[columnName], ListSortDirection.Ascending);
        }

        private void AdminStudentsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in AdminStudentsGrid.Rows)
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, row.Cells[5].Value.ToString());
                string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }; // Define image extensions

                // Get all files in the folder with image extensions
                string[] imageFiles = Directory.GetFiles(path)
                                              .Where(file => imageExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                              .ToArray();

                if (imageFiles.Length > 0)
                {
                    path = imageFiles[0];
                }
                if (File.Exists(path))
                    ((DataGridViewImageCell)row.Cells[0]).Value = new Bitmap(path);

            }
        }

        public void AttendanceOf( long sectionID, DateTime date)
        {
            customMenu1.ToggleAttendance();
            attendsBindingSource.Filter = $"sectionID={sectionID} AND Date >= #{date.Date}# AND Date < #{date.Date.AddDays(1)}#";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            customMenu1.ToggleAttendance();
        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            if (toggle == 0)
            {
                iconMenuItem3.Checked = true;
                iconMenuItem3.IconChar = IconChar.SortAlphaDown;
                toggle++;
                /*bsProductCard.Sort = "Title ASC";*/
                backgroundWorker1.RunWorkerAsync();
            }
            else if (toggle == 1)
            {
                iconMenuItem3.Checked = true;
                iconMenuItem3.IconChar = IconChar.SortAlphaUp;
                toggle++;
                /*bsProductCard.Sort = "Title DESC";*/
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                iconMenuItem3.Checked = false;
                iconMenuItem3.IconChar = IconChar.A;
                /*bsProductCard.Sort = null;*/
                backgroundWorker1.RunWorkerAsync();
                toggle = 0;
            }
            iconMenuItem2.Checked = false;
            iconMenuItem6.Checked = false;
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            IconMenuItem item = sender as IconMenuItem;
            if (item == iconMenuItem6)
            {
                iconMenuItem2.Checked = false;
            }
            else
                iconMenuItem6.Checked = false;
            iconMenuItem3.Checked = false;
            toggle = 0;
        }

        private void iconMenuItem6_CheckedChanged(object sender, EventArgs e)
        {
            /* IconMenuItem item = sender as IconMenuItem;
             if (item == iconMenuItem6 && item.Checked)
             {
                 bsProductCard.Sort = "Price ASC";
             }
             else if (item == iconMenuItem2 && item.Checked)
             {
                 bsProductCard.Sort = "Length ASC,Width ASC,Height ASC";
             }
             else bsProductCard.Sort = "";
             if(!busy)
                 backgroundWorker1.RunWorkerAsync();*/
        }

        private void AdminStudentsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void AdminStudentsGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in AdminStudentsGrid.Rows)
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, row.Cells[5].Value.ToString());
                string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }; // Define image extensions

                // Get all files in the folder with image extensions
                string[] imageFiles = Directory.GetFiles(path)
                                              .Where(file => imageExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                              .ToArray();

                if (imageFiles.Length > 0)
                {
                    path = imageFiles[0];
                }
                if (File.Exists(path))
                    ((DataGridViewImageCell)row.Cells[0]).Value = new Bitmap(path);

            }
        }
    }
}
