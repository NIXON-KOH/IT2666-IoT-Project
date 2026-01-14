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

namespace admin
{
    public partial class EmailRequest : Form
    {
        public EmailRequest()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT User_Email, TOTP_Secret FROM [User] WHERE User_Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string totpSecret = reader["TOTP_Secret"]?.ToString();
                            Session.Email = email;
                            Session.TotpSecret = totpSecret;

                            if (!string.IsNullOrEmpty(totpSecret))
                            {
                                this.Hide();
                                totpVerify2 totpVerify2 = new admin.totpVerify2();
                                totpVerify2.Show();
                            }
                            else
                            {
                                labelError.Text = "Account does not have TOTP enabled";
                                labelError.Visible = true;
                            }
                        }
                        else
                        {
                            labelError.Text = "User not found";
                            labelError.Visible = true;
                        }
                    }
                }
            }
        }
    }
}
