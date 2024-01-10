using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ClassSenseCore
{
    public partial class frmSignUp : Form
    {
        int phoneNb;
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender == txtEmail)
                isValidEmail();
            else if (sender == txtRepassword)
                isValidPassword();
            else isValidUsername();
        }
        public bool isValidEmail()
        {
            try
            {
                MailAddress ma = new MailAddress(txtEmail.Text);
                lblEmailErr.Visible = false;
            }
            catch
            {
                lblEmailErr.Visible = true;
                return false;
            }
            if (instructorsTableAdapter.FindInstructorsByEmail(txtEmail.Text).Count != 0)
            {
                lblEmailAlreadyRegistered.Visible = true;
                return false;
            }
            else lblEmailAlreadyRegistered.Visible = false;

            return true;
        }
        public bool isValidUsername()
        {
            if (string.IsNullOrWhiteSpace(txtFname.Text)  || string.IsNullOrWhiteSpace(txtLname.Text) )
                return false;

            return true;
        }
        public bool isValidPassword()
        {
            if (txtPassword.Text.Length == 0)
            {
                return false;
            }
            else
            {
                if (txtPassword.Text.Equals(txtRepassword.Text))
                {
                    lblPasswordMismatch.Visible = false;
                    return true;
                }
                else
                {
                    lblPasswordMismatch.Visible = true;
                    return false;
                }
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (isValidEmail() && isValidPassword() && isValidUsername())
            {
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                // Convert the salt to a string for storage in the database
                string saltString = Convert.ToBase64String(salt);

                // Get the user's password from the signup form
                string password = txtPassword.Text;

                // Combine the salt and password
                string saltedPassword = saltString + password;

                // Create a new instance of the hashing algorithm (e.g., bcrypt)
                var hashAlgorithm = new SHA256Managed();

                // Compute the hash of the salted password
                byte[] hashedPassword = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert the hashed password to a string for storage in the database
                string hashedPasswordString = Convert.ToBase64String(hashedPassword);

                // Store the hashedPasswordString and saltString in the database
                // along with other user details
                try
                {
                    DataRow newPersonRow = classSenseDataSet.Instructors.NewRow();
                    newPersonRow["FName"] = txtFname.Text;
                    newPersonRow["Lname"] = txtLname.Text;
                    newPersonRow["ID"] = newPersonRow["ID"];
                    newPersonRow["Email"] = txtEmail.Text;
                    newPersonRow["Birth"] = birthDate.Value;
                    newPersonRow["Password"] = hashedPasswordString;
                    newPersonRow["Salt"] = saltString;
                    classSenseDataSet.Instructors.Rows.Add(newPersonRow);
                    this.instructorsTableAdapter.Update(this.classSenseDataSet.Instructors);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Add the new row to the dataset

                this.Hide();

            }
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'classSenseDataSet.Person' table. You can move, or remove it, as needed.
            try
            {
                this.instructorsTableAdapter.Fill(this.classSenseDataSet.Instructors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
