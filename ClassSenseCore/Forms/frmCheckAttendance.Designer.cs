namespace ClassSenseCore
{
    partial class frmCheckAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            errorProvider1 = new ErrorProvider(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            dataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            StudentID = new DataGridViewTextBoxColumn();
            SectionIDColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            IsPresent = new DataGridViewCheckBoxColumn();
            picCapture = new Guna.UI2.WinForms.Guna2PictureBox();
            openFileDialog1 = new OpenFileDialog();
            guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            studentsTableAdapter = new ClassSenseDataSetTableAdapters.StudentsTableAdapter();
            classSenseDataSet = new ClassSenseDataSet();
            imagesTableAdapter = new ClassSenseDataSetTableAdapters.ImagesTableAdapter();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnConfirm = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCapture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classSenseDataSet).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 4;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWorkAsync;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(picCapture);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.FillColor = System.Drawing.Color.FromArgb(40, 40, 40);
            guna2Panel1.Location = new System.Drawing.Point(79, 66);
            guna2Panel1.Margin = new Padding(4, 5, 4, 5);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(1, 2, 1, 2);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new System.Drawing.Size(736, 478);
            guna2Panel1.TabIndex = 133;
            guna2Panel1.UseTransparentBackground = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(130, 173, 253);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(130, 173, 253);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 36;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StudentID, SectionIDColumn, DateColumn, IsPresent });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.GridColor = System.Drawing.Color.FromArgb(157, 143, 182);
            dataGridView1.Location = new System.Drawing.Point(81, 68);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 22;
            dataGridView1.Size = new System.Drawing.Size(734, 474);
            dataGridView1.TabIndex = 148;
            dataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepPurple;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.Silver;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.ThemeStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(157, 143, 182);
            dataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(130, 173, 253);
            dataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ThemeStyle.HeaderStyle.Height = 36;
            dataGridView1.ThemeStyle.ReadOnly = false;
            dataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(64, 128, 128);
            dataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ThemeStyle.RowsStyle.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver;
            dataGridView1.ThemeStyle.RowsStyle.Height = 22;
            dataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            dataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.Visible = false;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // StudentID
            // 
            StudentID.HeaderText = "StudentID";
            StudentID.MinimumWidth = 6;
            StudentID.Name = "StudentID";
            StudentID.ReadOnly = true;
            // 
            // SectionIDColumn
            // 
            SectionIDColumn.HeaderText = "SectionID";
            SectionIDColumn.MinimumWidth = 6;
            SectionIDColumn.Name = "SectionIDColumn";
            SectionIDColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            DateColumn.HeaderText = "Date";
            DateColumn.MinimumWidth = 6;
            DateColumn.Name = "DateColumn";
            DateColumn.ReadOnly = true;
            // 
            // IsPresent
            // 
            IsPresent.HeaderText = "Attendance";
            IsPresent.MinimumWidth = 6;
            IsPresent.Name = "IsPresent";
            IsPresent.ReadOnly = true;
            // 
            // picCapture
            // 
            picCapture.BorderRadius = 10;
            picCapture.CustomizableEdges = customizableEdges5;
            picCapture.Dock = DockStyle.Fill;
            picCapture.FillColor = System.Drawing.Color.FromArgb(40, 40, 40);
            picCapture.ImageRotate = 0F;
            picCapture.Location = new System.Drawing.Point(1, 2);
            picCapture.Name = "picCapture";
            picCapture.ShadowDecoration.CustomizableEdges = customizableEdges6;
            picCapture.Size = new System.Drawing.Size(734, 474);
            picCapture.SizeMode = PictureBoxSizeMode.StretchImage;
            picCapture.TabIndex = 131;
            picCapture.TabStop = false;
            picCapture.UseTransparentBackground = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Videos| *.mp4;*.mkv";
            openFileDialog1.Title = "Select a Video";
            // 
            // guna2GradientButton2
            // 
            guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            guna2GradientButton2.BorderRadius = 4;
            guna2GradientButton2.CausesValidation = false;
            customizableEdges9.BottomLeft = false;
            customizableEdges9.TopRight = false;
            guna2GradientButton2.CustomizableEdges = customizableEdges9;
            guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            guna2GradientButton2.FillColor = System.Drawing.Color.LightSteelBlue;
            guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(90, 140, 125);
            guna2GradientButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            guna2GradientButton2.Image = Properties.Resources.BackArrow;
            guna2GradientButton2.ImageSize = new System.Drawing.Size(30, 30);
            guna2GradientButton2.Location = new System.Drawing.Point(12, 5);
            guna2GradientButton2.Name = "guna2GradientButton2";
            guna2GradientButton2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2GradientButton2.Size = new System.Drawing.Size(56, 57);
            guna2GradientButton2.TabIndex = 77;
            guna2GradientButton2.UseTransparentBackground = true;
            guna2GradientButton2.Click += guna2GradientButton2_Click;
            // 
            // studentsTableAdapter
            // 
            studentsTableAdapter.ClearBeforeFill = true;
            // 
            // classSenseDataSet
            // 
            classSenseDataSet.DataSetName = "ClassSenseDataSet";
            classSenseDataSet.Namespace = "http://tempuri.org/ClassSenseDataSet.xsd";
            classSenseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imagesTableAdapter
            // 
            imagesTableAdapter.ClearBeforeFill = true;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.CausesValidation = false;
            lblTitle.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(166, 103, 100);
            lblTitle.Location = new System.Drawing.Point(234, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(171, 29);
            lblTitle.TabIndex = 147;
            lblTitle.Text = "Attendance for ";
            lblTitle.Visible = false;
            lblTitle.TextChanged += lblTitle_TextChanged;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConfirm.BackColor = System.Drawing.Color.Transparent;
            btnConfirm.BorderRadius = 8;
            btnConfirm.CausesValidation = false;
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.CustomizableEdges = customizableEdges3;
            btnConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnConfirm.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnConfirm.Enabled = false;
            btnConfirm.FillColor = System.Drawing.Color.LightSteelBlue;
            btnConfirm.FillColor2 = System.Drawing.Color.FromArgb(90, 140, 125);
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            btnConfirm.ForeColor = System.Drawing.Color.White;
            btnConfirm.Location = new System.Drawing.Point(724, 557);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirm.Size = new System.Drawing.Size(151, 54);
            btnConfirm.TabIndex = 148;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseTransparentBackground = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // guna2GradientButton1
            // 
            guna2GradientButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            guna2GradientButton1.BorderRadius = 8;
            guna2GradientButton1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            guna2GradientButton1.CausesValidation = false;
            guna2GradientButton1.Cursor = Cursors.Hand;
            guna2GradientButton1.CustomizableEdges = customizableEdges1;
            guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            guna2GradientButton1.Enabled = false;
            guna2GradientButton1.FillColor = System.Drawing.Color.LightSteelBlue;
            guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(90, 140, 125);
            guna2GradientButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            guna2GradientButton1.Location = new System.Drawing.Point(12, 557);
            guna2GradientButton1.Name = "guna2GradientButton1";
            guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientButton1.Size = new System.Drawing.Size(176, 54);
            guna2GradientButton1.TabIndex = 149;
            guna2GradientButton1.Text = "Make Changes";
            guna2GradientButton1.UseTransparentBackground = true;
            guna2GradientButton1.Click += guna2GradientButton1_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // frmCheckAttendance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(66, 97, 77);
            ClientSize = new System.Drawing.Size(891, 620);
            Controls.Add(dataGridView1);
            Controls.Add(guna2GradientButton1);
            Controls.Add(btnConfirm);
            Controls.Add(lblTitle);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2GradientButton2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCheckAttendance";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSupliers";
            FormClosing += frmStudents_FormClosing;
            Load += frmStudents_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCapture).EndInit();
            ((System.ComponentModel.ISupportInitialize)classSenseDataSet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2PictureBox picCapture;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ClassSenseDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private ClassSenseDataSet classSenseDataSet;
        private ClassSenseDataSetTableAdapters.ImagesTableAdapter imagesTableAdapter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2GradientButton btnConfirm;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn SectionIDColumn;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewCheckBoxColumn IsPresent;
        private System.Windows.Forms.Timer timer1;
    }
}