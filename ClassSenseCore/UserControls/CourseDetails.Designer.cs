namespace ClassSenseCore.UserControls
{
    partial class CourseDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblCourse = new Guna.UI2.WinForms.Guna2HtmlLabel();
            classSenseDataSet = new ClassSenseDataSet();
            sectionDetailsTableAdapter = new ClassSenseDataSetTableAdapters.SectionDetailsTableAdapter();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)classSenseDataSet).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(160, 160, 160, 180);
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(flowLayoutPanel1);
            guna2Panel1.Controls.Add(lblCourse);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = System.Drawing.Color.FromArgb(69, 69, 99);
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Margin = new Padding(3, 4, 3, 4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(30, 38, 30, 38);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new System.Drawing.Size(492, 308);
            guna2Panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(30, 38);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(432, 232);
            flowLayoutPanel1.TabIndex = 149;
            // 
            // lblCourse
            // 
            lblCourse.BackColor = System.Drawing.Color.Transparent;
            lblCourse.CausesValidation = false;
            lblCourse.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblCourse.ForeColor = System.Drawing.Color.Black;
            lblCourse.Location = new System.Drawing.Point(197, 4);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new System.Drawing.Size(96, 29);
            lblCourse.TabIndex = 148;
            lblCourse.Text = "CSCI300";
            lblCourse.TextChanged += lblCourse_TextChanged;
            // 
            // classSenseDataSet
            // 
            classSenseDataSet.DataSetName = "ClassSenseDataSet";
            classSenseDataSet.Namespace = "http://tempuri.org/ClassSenseDataSet.xsd";
            classSenseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sectionDetailsTableAdapter
            // 
            sectionDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // CourseDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CourseDetails";
            Size = new System.Drawing.Size(492, 308);
            Load += CourseDetails_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)classSenseDataSet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ClassSenseDataSet classSenseDataSet;
        private ClassSenseDataSetTableAdapters.SectionDetailsTableAdapter sectionDetailsTableAdapter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCourse;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
