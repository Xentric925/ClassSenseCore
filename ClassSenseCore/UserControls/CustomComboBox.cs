using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ClassSenseCore.UserControls
{
    public partial class CustomComboBox : UserControl
    {
        public int toggle=0;
        private string _placeholderText;
        private bool[] checkStates;
        private bool isChecked = false;
        public bool isPriceFilter;
        public event EventHandler CheckedChanged;
        bool ready = false;
        private long sid;
        public long StoreID { get { return sid; } set { sid = value; } }
        public decimal startPrice = 0;
        public decimal endPrice = 50;
        private bool panelCreated=false;
        public bool PanelCreated { get { return this.panelCreated; }}
        public bool[] CheckStates { get { return this.checkStates; } set { this.checkStates = value ; } }
        public bool IsChecked { get { return this.isChecked; } set { if (value != isChecked && ready==true) { this.isChecked = value; OnCheckedChanged(EventArgs.Empty); } } }
        public string PlaceHolderText {
            get { return this._placeholderText; }
            set 
            {
                this._placeholderText = value; guna2TileButton1.Text = value; 
                try
                {/*
                    if (value == "Category")
                        new filterCategoryTableAdapter().Fill(_MyInv_Data_DataSet.filterCategory);
                    else if (value == "Price")
                        isPriceFilter = true;
                    else new filterSupplierTableAdapter().Fill(_MyInv_Data_DataSet.filterSupplier,this.StoreID);
                    int i = 0;
                    if (!isPriceFilter)
                    {
                        CheckStates = new bool[_MyInv_Data_DataSet.Tables["filter" + PlaceHolderText].Rows.Count];
                        foreach (DataRow r in _MyInv_Data_DataSet.Tables["filter" + PlaceHolderText].Rows)
                        {
                            Guna2CheckBox chk = generateCheckBox();
                            chk.Text = r["Name"].ToString();
                            chk.CheckedChanged += Chk_CheckedChanged;
                            chk.Tag = i;
                            CheckStates[i++] = false;
                            guna2Panel1.Controls.Add(chk);
                        }
                        ready = true;
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }
        public void buttonPressed()
        {
            if (!isPriceFilter)
            {
                if (toggle == 1)
                    IsChecked = CheckStates.Any(b => b);
                toggle++;
                if (toggle == 3)
                {
                    if (!IsChecked)
                    {
                        foreach (Guna2CheckBox chk in guna2Panel1.Controls)
                        { chk.Checked = false; }
                        this.UnChecked();
                    }
                    toggle = 0;
                    return;
                }
            }else
            {
                if (toggle ==1)
                {
                    this.IsChecked = true;
                }
                toggle++; 
            }
        }

        public void Checked()
        {
            guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(162, 183, 185);
            iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(162, 183, 185);
            iconPictureBox1.IconChar = IconChar.Close;
            iconPictureBox1.IconColor = System.Drawing.Color.Red;
            this.Invalidate();
        }
        public void UnChecked()
        {
            guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(156, 113, 120);
            iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(156, 113, 120);
            iconPictureBox1.IconChar = IconChar.ChevronDown;
            iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(51, 51, 72);
            this.Invalidate();
        }

        public CustomComboBox()
        {
            InitializeComponent();
        }
        private Guna2CheckBox generateCheckBox()
        {
            Guna2CheckBox chk =new Guna2CheckBox();
            chk.AutoEllipsis = true;
            chk.AutoSize = true;
            chk.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(113)))), ((int)(((byte)(120)))));
            chk.CheckedState.BorderRadius = 3;
            chk.CheckedState.BorderThickness = 1;
            chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            chk.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(131)))));
            chk.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(113)))), ((int)(((byte)(120)))));
            chk.Dock = System.Windows.Forms.DockStyle.Top;
            chk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(113)))), ((int)(((byte)(120)))));
            chk.Location = new System.Drawing.Point(0, 0);
            chk.Name = "guna2CheckBox1";
            chk.Size = new System.Drawing.Size(44, 17);
            chk.TabIndex = 23;
            chk.Padding = new Padding(0, 1, 0, 1);
            chk.Text = "guna2CheckBox1";
            chk.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            chk.UncheckedState.BorderRadius = 3;
            chk.UncheckedState.BorderThickness = 1;
            chk.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(131)))));
            return chk;
        }
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (isPriceFilter)
            {
                if(toggle==0)
                    this.buttonPressed();
                ((AdminMain)this.ParentForm).customComboBoxPressed(ref guna2Panel2, this);
                this.panelCreated = true;
                ready = true;
            }
            else
            {
                if (toggle == 2||toggle==0)
                {
                    buttonPressed();
                    /*return;*/
                }
                ((AdminMain)this.ParentForm).customComboBoxPressed(ref guna2Panel1, this, guna2VScrollBar1);
                this.panelCreated = true;
            }

        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CheckBox chk = sender as Guna2CheckBox;
            bool[] newState = new bool[CheckStates.Length];

            for (int i = 0; i < CheckStates.Length; i++)
            {
                newState[i] = CheckStates[i];
            }
            newState[int.Parse(chk.Tag.ToString())]= chk.Checked;
            CheckStates = newState;
        }

        private void CustomComboBox_Resize(object sender, EventArgs e)
        {
            iconPictureBox1.Location = new System.Drawing.Point(iconPictureBox1.Location.X + iconPictureBox1.Width - iconPictureBox1.Height, iconPictureBox1.Location.Y);
            iconPictureBox1.Width = iconPictureBox1.Height;
        }

        private void iconPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!IsChecked)
            {
                iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(132, 96, 102);
                guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(132, 96, 102);
                guna2TileButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(132, 96, 102);
            }
            else
            {
                iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(142, 163, 165);
                iconPictureBox1.IconColor = System.Drawing.Color.Red;
                guna2TileButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(142, 163, 165);
                guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(142, 163, 165);

            }
        }

        private void guna2TileButton1_MouseLeave(object sender, EventArgs e)
        {
            if (!IsChecked)
            {
                iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(156, 113, 120);
                guna2TileButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(156, 113, 120);
                guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(156, 113, 120);

            }
            else
            {
                iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(162, 183, 185);
                iconPictureBox1.IconColor = System.Drawing.Color.Red;
                guna2TileButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(162, 183, 185);
                guna2TileButton1.FillColor = System.Drawing.Color.FromArgb(162, 183, 185);

            }
        }

        private void guna2NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (guna2NumericUpDown1.Value > guna2NumericUpDown3.Value)
            {
                guna2NumericUpDown3.Value = guna2NumericUpDown1.Value;
            }
            startPrice = guna2NumericUpDown1.Value;
            endPrice = guna2NumericUpDown3.Value;
        }
    }
}
