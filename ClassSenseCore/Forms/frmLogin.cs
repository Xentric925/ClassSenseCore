
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ClassSenseCore
{
    public partial class frmLogin : Form
    {
        private SHA256Managed hashAlgorithm = new SHA256Managed();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSignUp().ShowDialog();
            try
            {
                this.instructorsTableAdapter.Fill(this.classSenseDataSet.Instructors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txt_Leave(object sender, EventArgs e)
        {
            isValidEmail();
        }
        public bool isValidEmail()
        {
            if (instructorsTableAdapter.FindInstructorsByEmail(txtEmail.Text).Count != 0)
            {
                lblEmailNotFound.Visible = false;
                return true;
            }
            else lblEmailNotFound.Visible = true;

            return false;
        }
        public bool isValidPassword()
        {
            if (isValidEmail())
            {
                DataRow userRow = instructorsTableAdapter.FindInstructorsByEmail(txtEmail.Text)[0];


                // Get the user's entered password from the login form
                string enteredPassword = txtPassword.Text;

                // Retrieve the stored hashed password and salt from the database
                string storedHashedPasswordString = userRow["password"].ToString(); //GetStoredHashedPasswordFromDatabase();
                string storedSaltString = ""; userRow["salt"].ToString();//GetStoredSaltFromDatabase()

                // Combine the stored salt and entered password
                string saltedEnteredPassword = storedSaltString + enteredPassword;

                // Compute the hash of the salted entered password
                byte[] hashedEnteredPassword = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(saltedEnteredPassword));

                // Convert the hashed entered password to a string for comparison
                string hashedEnteredPasswordString = Convert.ToBase64String(hashedEnteredPassword);

                // Compare the stored hashed password and the hashed entered password
                if (hashedEnteredPasswordString != storedHashedPasswordString)
                {   // Passwords don't match, user authentication failed
                    // Display an error message or take appropriate action
                    lblWrongPassword.Visible = true;
                    return false;
                }
                else
                {
                    // Passwords match, user is authenticated
                    // Proceed with the login process
                    lblWrongPassword.Visible = false;
                    return true;
                }

            }
            return false;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isValidPassword())
            {
                Form frm;bool isManager=false;
                var userRow = instructorsTableAdapter.FindInstructorsByEmail(txtEmail.Text)[0];
                isManager = userRow.IsAdmin;
                if (isManager)
                {
                    frm = new AdminMain();
                    ((AdminMain)frm).UserEmail = txtEmail.Text;
                }
                else { 
                    frm = new InstructorMain();
                    ((InstructorMain)frm).UserEmail = txtEmail.Text;
                }
                frm.Show();
                this.Hide();
            }
        }
        private void frmLogin_Closing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.instructorsTableAdapter.Fill(this.classSenseDataSet.Instructors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
