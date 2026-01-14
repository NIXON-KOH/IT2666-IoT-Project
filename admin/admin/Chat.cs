using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.Drawing;
using System.Collections.Generic;

namespace admin
{
    public partial class Chat : Form
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        private Dictionary<string, ListBox> messageListBoxes = new Dictionary<string, ListBox>();

        public Chat()
        {
            InitializeComponent();
            
        }

        //private string currentUserId = Session.UserId.ToString();
        private string currentUserId = "1";


        private void Chat_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            tabControl1.TabPages.Clear();
            labelUsername.Text = $"Welcome, {Session.Username}!";
            LoadConversations(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LoadMessages(tabControl1.SelectedTab.Name, messageListBoxes[tabControl1.SelectedTab.Name]);
            
        }
        private void LoadConversations()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"SELECT User_Id as Partner, User_Name as username FROM [User] WHERE User_Id != @UserId;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {


                        Console.WriteLine(reader["Partner"].ToString());
                        string conversationPartner = reader["Partner"].ToString();
                        string partnername = reader["username"].ToString();
                        CreateConversationTab(conversationPartner, partnername);
                 
                    }
                }
            }
        }
        private void LoadMessages(string partner, ListBox messageListBox)
        {
            Console.Write(partner + "loading");
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                                SELECT
                                    c.Datetime,
                                    u.User_Name AS Sender,
                                    c.Message
                                FROM
                                    Chat AS c
                                INNER JOIN  
                                    [User] AS u ON c.Sender = u.User_Id 
                                WHERE
                                    (c.Sender = @UserId AND c.Receiver = @Partner) OR
                                    (c.Sender = @Partner AND c.Receiver = @UserId)
                                ORDER BY
                                    c.Datetime ASC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    cmd.Parameters.AddWithValue("@Partner", partner);

                    SqlDataReader reader = cmd.ExecuteReader();
                    messageListBox.Items.Clear(); //Brought this down here jic of performance issues,, dont want epilepsy

                    while (reader.Read())
                    {
                        DateTime datetime = Convert.ToDateTime(reader["Datetime"]);
                        string sender = reader["Sender"].ToString();
                        string message = reader["Message"].ToString();

                        string formattedMessage = $"{datetime:G} - {sender}: {message}";
                        messageListBox.Items.Add(formattedMessage);
                    }

                }
                messageListBox.SendToBack();
            }
        }
        // Create a new tab for each conversation partner
        private void CreateConversationTab(string partner, string partnername)
        {
            TabPage tabPage = new TabPage(partnername);
            tabPage.Name = partner;
            ListBox messageListBox = new ListBox();
            messageListBox.Dock = DockStyle.Fill;

            // Load messages when the tab is selected
            tabPage.Enter += (s, e) => LoadMessages(partner, messageListBox);
            tabPage.Controls.Add(messageListBox);
            tabControl1.TabPages.Add(tabPage);

            messageListBoxes.Add(partner, messageListBox);

            //Create submit button
            Button btn = new Button();
            btn.Parent = this.tabControl1.TabPages[partner];
            btn.Text = "Message";
            btn.Name = partnername;
            btn.Width = 100;
            btn.Height = 30;
           
            btn.Click += SubmitMsg;
            btn.Dock = DockStyle.Bottom;
            
            //Create Textbox
            TextBox txtbox = new TextBox();
            txtbox.Parent = this.tabControl1.TabPages[partner];
            txtbox.Dock = DockStyle.Bottom;
            txtbox.Name = partner;

            btn.BringToFront();
            txtbox.BringToFront();
            
        }

        

        private void SubmitMsg(object sender, EventArgs e)
        {
            Console.WriteLine(tabControl1.SelectedTab.Name);
            string partnername = tabControl1.SelectedTab.Name;
            TextBox txt = null;
            foreach ( Control control in tabControl1.SelectedTab.Controls)
            {
                if (control is TextBox && control.Name == partnername)
                {
                    txt = (TextBox)control;
                    break;
                }
            }

            string msg = txt.Text;
            Console.WriteLine(msg);
            string query = @"INSERT INTO CHAT ([datetime], sender, Receiver, message) VALUES (@huh, @myid, @partnerid, @message)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@huh", DateTime.Now);
                cmd.Parameters.AddWithValue("@myid", currentUserId);
                cmd.Parameters.AddWithValue("@partnerid",partnername);
                cmd.Parameters.AddWithValue("@message", msg);

                cmd.ExecuteNonQuery();
                txt.Text = "";
            }


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

        private void linkLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Report report = new admin.Report();
            report.Show();
        }

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mf = new admin.MainForm();
            mf.Show();
        }

        private void linkLabelSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();

        }
    }

}
