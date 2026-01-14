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
    public partial class UpdateDeleteUser : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        public UpdateDeleteUser()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            try
            {
                string strCommandText = "SELECT User_Name, User_Role, User_RFID, User_Email FROM [User] WHERE User_Id=@UserID";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@UserID", textBoxUserID.Text);

                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBoxUsername.Text = reader["User_Name"].ToString();
                    textBoxEmail.Text = reader["User_Email"].ToString();
                    textBoxRole.Text = reader["User_Role"].ToString();
                    textBoxRFID.Text = reader["User_RFID"].ToString();
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
            bool exists = false;
            try
            {
                if (textBoxUserID.Text == "")
                {

                    MessageBox.Show("Error. Please Key In User ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;

                }

                if (textBoxUsername.Text == "")
                {
                    MessageBox.Show("Error. Please Key In Username.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                if (textBoxEmail.Text == "")
                {
                    MessageBox.Show("Error. Please Key In Email.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE User_Email = @email AND User_Id != @UserId", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        cmd.Parameters.AddWithValue("@UserId", textBoxUserID.Text);

                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Email has already been taken", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                if (textBoxRole.Text == "")
                {
                    MessageBox.Show("Error. Please Key In Role 'Admin' or 'User' .", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                if (textBoxRole.Text != "Admin" && textBoxRole.Text != "User")
                {
                    MessageBox.Show("Invalid Role. Role must be 'Admin' or 'User'.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }


                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    String strCommandText = "UPDATE [User] SET User_Name=@NewUsername, User_Role=@NewRole, User_RFID=@NewRFID, User_Email=@NewEmail WHERE User_Id=@UserID";

                    SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);

                    updateCmd.Parameters.AddWithValue("@UserID", textBoxUserID.Text);
                    updateCmd.Parameters.AddWithValue("@NewUsername", textBoxUsername.Text);
                    updateCmd.Parameters.AddWithValue("@NewRole", textBoxRole.Text);
                    updateCmd.Parameters.AddWithValue("@NewRFID", textBoxRFID.Text);
                    updateCmd.Parameters.AddWithValue("@NewEmail", textBoxEmail.Text);

                    myConnect.Open();
                    int result = updateCmd.ExecuteNonQuery();
                    myConnect.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log log = new Log();
                        log.LogActivity("User " + textBoxUserID.Text + " details updated");
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please check the User ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            SqlConnection myConnect = new SqlConnection(strConnectionString);
            String strCommandText = "DELETE FROM [User] WHERE User_Id = @User_ID";
            SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);
            updateCmd.Parameters.AddWithValue("@User_ID", userid);

            myConnect.Open();
            result = updateCmd.ExecuteNonQuery();
            myConnect.Close();
            return result;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DeleteUserRecord(textBoxUserID.Text) > 0)
                {
                    MessageBox.Show("User " + textBoxUserID.Text + " has been deleted");
                    Log log = new Log();
                    log.LogActivity("User " + textBoxUserID.Text + " has been deleted");
                }

                else
                    MessageBox.Show("Delete Failed");
            }
        }
    }
}

