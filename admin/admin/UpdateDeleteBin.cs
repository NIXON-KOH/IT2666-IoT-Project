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
    public partial class UpdateDeleteBin : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        public UpdateDeleteBin()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            try
            {
                string strCommandText = "SELECT Location FROM [Bin] WHERE Bin_Id=@BinID";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@BinID", textBoxBinID.Text);

                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBoxLocation.Text = reader["Location"].ToString();
                }
                else
                {
                    MessageBox.Show("No Record Found", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateUserRecord();

        }

        private int UpdateUserRecord()
        {
            try
            {
                if (textBoxBinID.Text == "")
                {

                    MessageBox.Show("Error. Please Key In Bin ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;

                }

                if (textBoxLocation.Text == "")
                {

                    MessageBox.Show("Error. Please Key In Location.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;

                }

                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    String strCommandText = "UPDATE [Bin] SET Location=@location WHERE Bin_Id=@BinID";

                    SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);

                    updateCmd.Parameters.AddWithValue("@BinID", textBoxBinID.Text);
                    updateCmd.Parameters.AddWithValue("@location", textBoxLocation.Text);


                    myConnect.Open();
                    int result = updateCmd.ExecuteNonQuery();
                    myConnect.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Bin details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log log = new Log();
                        log.LogActivity("Bin " + textBoxBinID.Text + " details updated");
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please check the Bin ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private int DeleteUserRecord(string userid)
        {
            int result = 0;
            if (textBoxBinID.Text == "")
            {

                MessageBox.Show("Error. Please Key In Bin ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;

            }

            SqlConnection myConnect = new SqlConnection(strConnectionString);
            String strCommandText = "DELETE FROM [Bin] WHERE Bin_Id = @Bin_ID";
            SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);
            updateCmd.Parameters.AddWithValue("@Bin_ID", textBoxBinID.Text);

            myConnect.Open();
            result = updateCmd.ExecuteNonQuery();
            myConnect.Close();
            return result;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DeleteUserRecord(textBoxBinID.Text) > 0)
                {
                    MessageBox.Show("Bin " + textBoxBinID.Text + " has been deleted");
                    Log log = new Log();
                    log.LogActivity("Bin " + textBoxBinID.Text + " has been deleted");
                }

                else
                    MessageBox.Show("Delete Failed");
            }
        }
    }
}

