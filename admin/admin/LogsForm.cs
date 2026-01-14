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
    public partial class LogsForm : Form
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public LogsForm()
        {
            InitializeComponent();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            labelUsername.Text = $"Welcome, {Session.Username}!";

            LoadData();
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
        }

        

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Datetime, User_ID, Activity FROM [Log]"; 

                    

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new admin.MainForm();
            mainForm.Show();
        }

        private void linkLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Report report = new admin.Report();
            report.Show();
        }

        private void linkLabelUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm usr = new admin.UsersForm();
            usr.Show();
        }

        private void linkLabelSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Schedule sd = new admin.Schedule();
            sd.Show();
        }

        private void linkLabelLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LogsForm log = new admin.LogsForm();
            log.Show();
        }

        private void linkLabelThresholds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Threshold th = new admin.Threshold();
            th.Show();
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SettingsForm st = new admin.SettingsForm();
            st.Show();
        }

        private void ChatLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Chat chat = new admin.Chat();
            chat.Show();
        }

        private void linkLabelBins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Bin bin = new admin.Bin();
            bin.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();
        }
    }
}
