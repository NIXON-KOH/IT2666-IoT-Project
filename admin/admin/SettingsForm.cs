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
    public partial class SettingsForm : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            labelUsername.Text = $"Welcome, {Session.Username}!";
            RetreiveData();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            labelUsername.Text = $"Welcome, {Session.Username}!";
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Session.Clear();
            MessageBox.Show("Log Out Successful");
            this.Hide();
            LoginForm loginForm = new admin.LoginForm();
            loginForm.Show();
        }
        private void linkLabelLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LogsForm logsForm = new admin.LogsForm();
            logsForm.Show();
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SettingsForm settingsForm = new admin.SettingsForm();
            settingsForm.Show();
        }

        private void linkLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Report report = new admin.Report();
            report.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Chat chat = new admin.Chat();
            chat.Show();
        }

        private void linkLabelSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Schedule sd = new admin.Schedule();
            sd.Show();
        }

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new admin.MainForm();
            mainForm.Show();
        }

        private void linkLabelUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new admin.UsersForm();
            usersForm.Show();
        }



        private void RetreiveData()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            try
            {
                string strCommandText = "SELECT User_Name, User_PasswordHash, User_PasswordSalt FROM [User] WHERE User_ID=@UserID";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@UserID", Session.UserId);

                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBoxSettingsUsername.Text = reader["User_Name"].ToString();
                    

                }
                else
                {
                    MessageBox.Show("Error", "An Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConnect.Close();
            }
        }

        private int UpdateUserRecord()
        {

            try
            {
                if (textBoxSettingsUsername.Text == "")
                {

                    MessageBox.Show("Error. Please Key In Username.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;

                }

                


                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    String strCommandText = "UPDATE [User] SET User_Name=@NewUsername WHERE User_Id=@UserID";

                    SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);

                    updateCmd.Parameters.AddWithValue("@UserID", Session.UserId);
                    updateCmd.Parameters.AddWithValue("@NewUsername", textBoxSettingsUsername.Text);
                    

                    myConnect.Open();
                    int result = updateCmd.ExecuteNonQuery();
                    myConnect.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log log = new Log();
                        log.LogActivity("User " + Session.UserId + " details updated");
                        Session.Username = textBoxSettingsUsername.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return result;
                }
            }

            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return -1 in case of general errors
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


        static bool VerifyHash(string password, string hash, string salt)
        {
            password = ComputeHash(password, salt);

            if (password == hash)
            {
                return true;
            }
            else { return false; }
        }

        private void buttonSettingsSave_Click(object sender, EventArgs e)
        {
            UpdateUserRecord();
        }

        private void buttonEnableTOTP_Click(object sender, EventArgs e)
        {
            string email = Session.Email;
            string secretKey = TotpHelper.GenerateSecretKey(); // Generate the TOTP secret

            // Store the secret in the database (you should hash it for security in real applications)
            SaveUser(email, secretKey);

            // Generate the TOTP URI for QR Code
            string totpUri = TotpHelper.GenerateTotpUri(email, secretKey);

            // Generate the QR code image
            Bitmap qrCodeImage = TotpHelper.GenerateQrCode(totpUri);

            // Display the QR code in a PictureBox
            pictureBoxQrCode.Image = qrCodeImage;

            MessageBox.Show("TOTP Secret Generated. Please scan the QR code with your authenticator app.");
        }

        // Save user data with TOTP secret (this is a simple example; don't store plain TOTP secret in real applications)
        private void SaveUser(string email, string totpSecret)
        {
            
            string query = "UPDATE [User] SET TOTP_Secret = @TOTPSecret WHERE User_ID = @UserId";

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TotpSecret", totpSecret);
                cmd.Parameters.AddWithValue("@UserId", Session.UserId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void linkLabelSchedule_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Schedule sd = new admin.Schedule();
            sd.Show();
        }

        private void linkLabelThresholds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Threshold th = new admin.Threshold();
            th.Show();
        }

        private void linkLabelSettings_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SettingsForm sf = new admin.SettingsForm();
            sf.Show();

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Chat ct = new admin.Chat();
            ct.Show();
        }

        private void linkLabelBins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Bin bin = new admin.Bin();
            bin.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();

        }
    }
    
}
