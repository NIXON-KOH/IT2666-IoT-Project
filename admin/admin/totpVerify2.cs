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
    public partial class totpVerify2 : Form
    {
        public totpVerify2()
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

                this.Hide();
                ResetPassword ResetPassword = new admin.ResetPassword();
                ResetPassword.Show();

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
            string query = "SELECT [TOTP_Secret] FROM [User] WHERE [User_Email] = @Email";
            string totpSecret = null;

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", Session.Email);

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
