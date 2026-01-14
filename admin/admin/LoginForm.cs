using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace admin
{
    public partial class LoginForm : Form
    {
        //retrieve connection information from App.Config
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
            labelError.Visible = false;

        }

        private void LoggingIn(string storedUsername, string storedEmail)
        {
            

            MessageBox.Show("Login Successful");
            this.Hide();
            MainForm mainForm = new admin.MainForm();
            mainForm.Show();
            Log log = new Log();

            string subject = "New Login Detected!";
            string body = $"<h3>Hello {storedUsername},</h3><p>Your account was just logged in. If this wasn’t you, please reset your password immediately.</p>";
            EmailService.SendEmail(storedEmail, subject, body);
            log.LogActivity("Logged in as admin");
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Success");
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT * FROM [User] WHERE User_Name=@username";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);

            try
            {
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve data from the database
                    string storedUsername = reader["User_Name"].ToString();
                    string storedHash = reader["User_PasswordHash"].ToString();
                    string storedSalt = reader["User_PasswordSalt"].ToString();
                    string storedEmail = reader["User_Email"].ToString();
                    string storedRole = reader["User_Role"].ToString();
                    int storedUserId = int.Parse(reader["User_Id"].ToString());
                    string storedtotpsecret = reader["TOTP_Secret"].ToString();
                    // Verify the password
                    if (VerifyHash(textBoxPassword.Text, storedHash, storedSalt))
                    {

                        Session.Username = storedUsername;
                        Session.Role = storedRole;
                        Session.UserId = storedUserId;
                        Session.Email = storedEmail;
                        if (storedtotpsecret != "")
                        {
                            this.Hide();
                            totpVerify totpVerify = new admin.totpVerify();
                            totpVerify.Show();
                        }

                        else
                        {
                            LoggingIn(storedUsername, storedEmail);
                        }
                       
                    }
                    else
                    {
                        labelError.Text = "Invalid username or password.";
                        labelError.Visible = true;
                    }
                }
                else
                {
                    labelError.Text = "Invalid username or password.";
                    labelError.Visible = true;
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                labelError.Text = $"Database error: {ex.Message}";
            }
            finally
            {
                myConnect.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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


        static bool VerifyHash(string password, string hash, string salt)
        {
            password = ComputeHash(password, salt);

            if (password == hash)
            {
                return true;
            }
            else { return false; }
        }


        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            EmailRequest EmailRequest = new admin.EmailRequest();
            EmailRequest.Show();
        }
    }
}
