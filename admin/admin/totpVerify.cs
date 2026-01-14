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

namespace admin
{
    public partial class totpVerify : Form
    {
        public totpVerify()
        {
            InitializeComponent();
        }

        private void buttontotpVerify_Click(object sender, EventArgs e)
        {
            string email = Session.Email;
            string enteredOtpCode = textBoxTOTPCode.Text;

            string storedSecret = GetTotpSecretFromDatabase(email); // Retrieve the TOTP secret from DB

            // Verify the TOTP code entered by the user
            if (TotpHelper.GenerateTotpCode(storedSecret).ToString() == enteredOtpCode)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                MainForm mainForm = new admin.MainForm();
                mainForm.Show();
                Log log = new Log();

                string subject = "New Login Detected!";
                string body = $"<h3>Hello {Session.Username},</h3><p>Your account was just logged in. If this wasn’t you, please reset your password immediately.</p>";
                EmailService.SendEmail(Session.Email, subject, body);
                log.LogActivity("Logged in as admin");
            }
            else
            {
                labelInvalid.Visible = true;
            }
        }


        // Retrieve TOTP secret from the database (simplified for this example)
        private string GetTotpSecretFromDatabase(string email)
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            string query = "SELECT [TOTP_Secret] FROM [User] WHERE [User_Id] = @Userid";
            string totpSecret = null;

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Userid", Session.UserId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    totpSecret = reader["TOTP_Secret"].ToString(); 
                }
            }

            return totpSecret;
        }
    }
}
