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
    public partial class AddUser : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public AddUser()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool exists = false;
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxRole.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                if (textBoxRole.Text != "Admin" && textBoxRole.Text != "User")
                {
                    MessageBox.Show("Invalid Role. Role must be 'Admin' or 'User'.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE User_Email = @email", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);

                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Email has already been taken", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE User_Name = @name", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxUsername.Text);

                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Username has already been taken", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                string passwordSalt = Salt();
                string passwordHash = ComputeHash(textBoxPassword.Text, passwordSalt);
                int result = 0;
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                String strCommandText = "INSERT [User] (User_Name, User_PasswordHash, User_PasswordSalt, User_Role, User_RFID, User_Email)" + "VALUES (@NewUsername,@passwordHash, @passwordSalt, @NewRole, @NewRFID, @NewEmail)";

                SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);
                updateCmd.Parameters.AddWithValue("@NewUsername", textBoxUsername.Text);
                updateCmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                updateCmd.Parameters.AddWithValue("@passwordSalt", passwordSalt);
                updateCmd.Parameters.AddWithValue("@NewRole", textBoxRole.Text);
                updateCmd.Parameters.AddWithValue("@NewRFID", textBoxRFID.Text);
                updateCmd.Parameters.AddWithValue("@NewEmail", textBoxEmail.Text);
                myConnect.Open();
                result = updateCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("New User Record Added Successfully!");
                    Log log = new Log();
                    log.LogActivity("Created new user " + textBoxUsername.Text);
                }

                else
                {
                    MessageBox.Show("New User Record Failed to Add");
                }

                myConnect.Close();
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related errors (e.g., connection issues, query issues)
                MessageBox.Show("Database error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle any other types of errors (e.g., unexpected errors)
                MessageBox.Show("An error occurred: " + ex.Message);
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
