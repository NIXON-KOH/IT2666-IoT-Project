using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;

namespace admin
{
    public partial class Threshold : Form
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public Threshold()
        {
            InitializeComponent();
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            labelUsername.Text = $"Welcome, {Session.Username}!";
            SqlConnection conn = new SqlConnection(ConnectionString);
            string query = "Select TOP 1 * FROM threshold ORDER BY Id DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        textBox3.Text = reader["light"].ToString();
                    }
                    catch { textBox3.Text = "Eror!"; } //Hardcoded Default Value

                    try
                    {
                        textBox4.Text = reader["fill level soft"].ToString();

                    }
                    catch
                    {
                        textBox4.Text = "Error!";
                    }

                    try
                    {
                        textBox1.Text = reader["fill level hard"].ToString();

                    }
                    catch
                    {
                        textBox1.Text = "Error!";
                    }
                    try
                    {
                        textBox2.Text = reader["Temperature"].ToString();
                    }
                    catch
                    {
                        textBox2.Text = "Error!";
                    }
                    try
                    {
                        textBox5.Text = reader["Water"].ToString();
                    }
                    catch
                    {
                        textBox5.Text = "ERROR!";
                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Session.Clear();
            MessageBox.Show("Log Out Successful");
            this.Hide();
            LoginForm loginForm = new admin.LoginForm();
            loginForm.Show();
            Log log = new Log();
            log.LogActivity("Logged out");
        }

        private void linkLabelUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new admin.UsersForm();
            usersForm.Show();
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

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainform = new admin.MainForm();
            mainform.Show();
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


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double water = double.Parse(textBox5.Text);
                double soft = double.Parse(textBox4.Text);
                double hard = double.Parse(textBox1.Text);
                double temp = double.Parse(textBox2.Text);
                double light = double.Parse(textBox3.Text);
            }
            catch
            {
                label7.Show();
                return;
            }
            string query = "INSERT INTO Threshold (Id, Water, Temperature, [Fill Level hard], [Fill Level soft], Light) VALUES (@id, @water, @temp, @hard, @soft, @light)";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", DateTime.Now);
            cmd.Parameters.AddWithValue("@water", textBox5.Text);
            cmd.Parameters.AddWithValue("@temp", textBox2.Text);
            cmd.Parameters.AddWithValue("@hard", textBox1.Text);
            cmd.Parameters.AddWithValue("@soft", textBox4.Text);
            cmd.Parameters.AddWithValue("@light", textBox3.Text);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
            {
                MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log log = new Log();
                log.LogActivity("User " + Session.UserId + " details updated");

            }
            else
            {
                MessageBox.Show("Error", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void linkLabelReport_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Report rp = new admin.Report();
            rp.Show();
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
