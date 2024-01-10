namespace ClassSenseCore
{
    partial class frmReminders
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReminders));
            this.bunifuLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.bunifuLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chkNotifyme = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.txtMemo = new Guna.UI2.WinForms.Guna2TextBox();
            this.bunifuLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numH = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.NumMin = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkAdvanceNotification = new System.Windows.Forms.CheckBox();
            this.bunifuLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.bunifuLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.txtTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMin)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuLabel1.Location = new System.Drawing.Point(27, 41);
            this.bunifuLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(127, 30);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "Choose Date:";
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(27, 167);
            this.bunifuLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(134, 30);
            this.bunifuLabel2.TabIndex = 1;
            this.bunifuLabel2.Text = "Choose Time :";
            // 
            // chkNotifyme
            // 
            this.chkNotifyme.AutoSize = true;
            this.chkNotifyme.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotifyme.Location = new System.Drawing.Point(376, 41);
            this.chkNotifyme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkNotifyme.Name = "chkNotifyme";
            this.chkNotifyme.Size = new System.Drawing.Size(252, 27);
            this.chkNotifyme.TabIndex = 5;
            this.chkNotifyme.Text = "Notify me on the same date";
            this.chkNotifyme.UseVisualStyleBackColor = true;
            this.chkNotifyme.CheckedChanged += new System.EventHandler(this.chkNotifyme_CheckedChanged);
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmail.Location = new System.Drawing.Point(376, 86);
            this.chkEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(170, 27);
            this.chkEmail.TabIndex = 6;
            this.chkEmail.Text = "Notify/sendEmail";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.txtMemo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtMemo.BackgroundImage")));
            this.txtMemo.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txtMemo.BorderRadius = 8;
            this.txtMemo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemo.DefaultText = "Type ur memo";
            this.txtMemo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(125)))));
            this.txtMemo.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtMemo.ForeColor = System.Drawing.Color.Empty;
            this.txtMemo.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemo.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemo.Location = new System.Drawing.Point(381, 223);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMemo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.PlaceholderForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMemo.PlaceholderText = "Enter text here";
            this.txtMemo.SelectedText = "";
            this.txtMemo.Size = new System.Drawing.Size(387, 175);
            this.txtMemo.TabIndex = 7;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bunifuLabel3.Location = new System.Drawing.Point(381, 167);
            this.bunifuLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(176, 30);
            this.bunifuLabel3.TabIndex = 8;
            this.bunifuLabel3.Text = "Enter your memo :";
            // 
            // numH
            // 
            this.numH.BackColor = System.Drawing.Color.Transparent;
            this.numH.BorderColor = System.Drawing.Color.DodgerBlue;
            this.numH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(125)))));
            this.numH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numH.Location = new System.Drawing.Point(35, 223);
            this.numH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numH.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(56, 30);
            this.numH.TabIndex = 10;
            this.numH.ValueChanged += new System.EventHandler(this.numH_ValueChanged_1);
            // 
            // NumMin
            // 
            this.NumMin.BackColor = System.Drawing.Color.Transparent;
            this.NumMin.BorderColor = System.Drawing.Color.DodgerBlue;
            this.NumMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NumMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(125)))));
            this.NumMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NumMin.Location = new System.Drawing.Point(147, 223);
            this.NumMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NumMin.Name = "NumMin";
            this.NumMin.Size = new System.Drawing.Size(56, 30);
            this.NumMin.TabIndex = 11;
            this.NumMin.ValueChanged += new System.EventHandler(this.NumMin_ValueChanged_1);
            // 
            // chkAdvanceNotification
            // 
            this.chkAdvanceNotification.AutoSize = true;
            this.chkAdvanceNotification.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvanceNotification.Location = new System.Drawing.Point(376, 134);
            this.chkAdvanceNotification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAdvanceNotification.Name = "chkAdvanceNotification";
            this.chkAdvanceNotification.Size = new System.Drawing.Size(116, 27);
            this.chkAdvanceNotification.TabIndex = 12;
            this.chkAdvanceNotification.Text = "Notify me ";
            this.chkAdvanceNotification.UseVisualStyleBackColor = true;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel4.Location = new System.Drawing.Point(101, 231);
            this.bunifuLabel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(14, 22);
            this.bunifuLabel4.TabIndex = 13;
            this.bunifuLabel4.Text = "H";
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel5.Location = new System.Drawing.Point(239, 231);
            this.bunifuLabel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(28, 22);
            this.bunifuLabel5.TabIndex = 14;
            this.bunifuLabel5.Text = "Min";
            // 
            // dtPicker
            // 
            this.dtPicker.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dtPicker.BorderRadius = 8;
            this.dtPicker.Checked = true;
            this.dtPicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(125)))));
            this.dtPicker.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtPicker.Location = new System.Drawing.Point(27, 86);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(200, 50);
            this.dtPicker.TabIndex = 16;
            this.dtPicker.Value = new System.DateTime(2023, 8, 26, 13, 22, 43, 374);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.guna2GradientButton1.BorderRadius = 8;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(35, 369);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(180, 46);
            this.guna2GradientButton1.TabIndex = 19;
            this.guna2GradientButton1.Text = "Add Reminder";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(530, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "days in advance";
            // 
            // cmbDays
            // 
            this.cmbDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbDays.Location = new System.Drawing.Point(484, 134);
            this.cmbDays.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(40, 24);
            this.cmbDays.TabIndex = 23;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.txtTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTime.BackgroundImage")));
            this.txtTime.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txtTime.BorderRadius = 8;
            this.txtTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTime.DefaultText = "";
            this.txtTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(125)))));
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtTime.ForeColor = System.Drawing.Color.Empty;
            this.txtTime.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTime.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTime.Location = new System.Drawing.Point(35, 290);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTime.Name = "txtTime";
            this.txtTime.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTime.PasswordChar = '\0';
            this.txtTime.PlaceholderForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTime.PlaceholderText = "";
            this.txtTime.SelectedText = "";
            this.txtTime.Size = new System.Drawing.Size(169, 48);
            this.txtTime.TabIndex = 24;
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.guna2GradientButton2.BorderRadius = 8;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.Location = new System.Drawing.Point(675, 7);
            this.guna2GradientButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(113, 43);
            this.guna2GradientButton2.TabIndex = 35;
            this.guna2GradientButton2.Text = "⇐  Back";
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // frmReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2GradientButton2);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.cmbDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.bunifuLabel5);
            this.Controls.Add(this.bunifuLabel4);
            this.Controls.Add(this.chkAdvanceNotification);
            this.Controls.Add(this.NumMin);
            this.Controls.Add(this.numH);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.chkNotifyme);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmReminders";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReminders";
            this.Load += new System.EventHandler(this.frmReminders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel bunifuLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel bunifuLabel2;
        private System.Windows.Forms.CheckBox chkNotifyme;
        private System.Windows.Forms.CheckBox chkEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtMemo;
        private Guna.UI2.WinForms.Guna2HtmlLabel bunifuLabel3;
        private Guna.UI2.WinForms.Guna2NumericUpDown numH;
        private Guna.UI2.WinForms.Guna2NumericUpDown NumMin;
        private System.Windows.Forms.CheckBox chkAdvanceNotification;
        private Guna.UI2.WinForms.Guna2HtmlLabel bunifuLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel bunifuLabel5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtPicker;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDays;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2TextBox txtTime;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
    }
}