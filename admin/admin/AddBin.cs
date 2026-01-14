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
    public partial class AddBin : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public AddBin()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxLocation.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }



                SqlConnection myConnect = new SqlConnection(strConnectionString);
                String strCommandText = "INSERT [Bin] (Location)" + "VALUES (@location)";
                int result = 0;
                SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);
                updateCmd.Parameters.AddWithValue("@location", textBoxLocation.Text);
                myConnect.Open();
                result = updateCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("New Bin Record Added Successfully!");
                    Log log = new Log();
                    log.LogActivity("Created new bin ");
                }

                else
                {
                    MessageBox.Show("New Bin Record Failed to Add");
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


    }
}
