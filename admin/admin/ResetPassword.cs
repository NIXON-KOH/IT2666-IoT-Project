using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace admin
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxNewPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                labelError.Visible = true;
                labelError.Text = "Password fields are empty.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                labelError.Visible = true;
                labelError.Text = "Passwords do not match. Please try again.";
                return;
            }

            string email = Session.Email;

            string passwordSalt = Salt();
            string passwordHash = ComputeHash(textBoxNewPassword.Text, passwordSalt);

            // Update password in the database
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
            {
                string query = "UPDATE [User] SET [User_PasswordHash] = @Password_Hash, [User_PasswordSalt] = @Password_Salt  WHERE [User_Email] = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password_Hash", passwordHash);
                cmd.Parameters.AddWithValue("@Password_Salt", passwordSalt);
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Password reset successfully. You can now log in with your new password.", "Success", MessageBoxButtons.OK);
                        Session.Clear();
                        this.Hide();
                        LoginForm LoginForm = new admin.LoginForm();
                        LoginForm.Show();
                    }
                    else
                    {
                        labelError.Visible = true;
                        labelError.Text = "An error occurred while resetting the password. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    labelError.Visible = true;
                    labelError.Text = "Error: " + ex.Message;
                }
            }
        }
        static string Salt()
        {
            byte[] randomBytes = new byte[32];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        static string ComputeHash(string password, string salt)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(salt + password);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }

        }

    }
}
