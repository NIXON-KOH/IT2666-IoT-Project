using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace admin
{
    public partial class Schedule : Form
    {
        private MonthCalendar monthCalendar; private ToolTip toolTip; private Dictionary<DateTime, List<ScheduleEntry>> scheduleData;
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        private ComboBox binDropdown;
        private Button selectButton;
        public Schedule()
        {
            InitializeComponent();
            InitializeCalendar();
            LoadScheduleData();

            SetupForm();
            LoadBins();

        }
        private void InitializeCalendar()
        {
            // Create and configure the MonthCalendar control.
            monthCalendar = new MonthCalendar
            {
                Location = new Point(300, 100),
                MaxSelectionCount = 1 // single-date selection
            };

            // Handle mouse move events over the calendar.
            monthCalendar.MouseMove += MonthCalendar_MouseMove;
            this.Controls.Add(monthCalendar);

            // Initialize the tooltip.
            toolTip = new ToolTip();
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
        private void LoadScheduleData()
        {
            scheduleData = new Dictionary<DateTime, List<ScheduleEntry>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, DateCreated, CreatedBy, ForUser, ActivityExpected, bin FROM dbo.Schedule";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ScheduleEntry entry = new ScheduleEntry
                        {
                            Id = reader.GetInt32(0),
                            DateCreated = reader.GetDateTime(1),
                            CreatedBy = reader.GetString(2),
                            ForUser = reader.GetString(3),
                            ActivityExpected = reader.GetString(4),
                            Bin = reader.GetInt32(5)
                        };

                        // Group by the Date portion of DateCreated.
                        DateTime key = entry.DateCreated.Date;
                        if (!scheduleData.ContainsKey(key))
                        {
                            scheduleData[key] = new List<ScheduleEntry>();
                        }
                        scheduleData[key].Add(entry);
                    }
                }
            }
        }


        private void MonthCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            // In this simple example, we use the currently selected date as the date to display.
            DateTime selectedDate = monthCalendar.SelectionStart;

            if (scheduleData.ContainsKey(selectedDate))
            {
                string tooltipText = "";
                foreach (var entry in scheduleData[selectedDate])
                {
                    tooltipText += $"ID: {entry.Id}, ForUser: {entry.ForUser}, Activity: {entry.ActivityExpected}\n";
                }
                toolTip.SetToolTip(monthCalendar, tooltipText);
            }
            else
            {
                toolTip.SetToolTip(monthCalendar, "No schedule entries for this date.");
            }
        }



        public void Schedule_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            labelUsername.Text = $"Welcome, {Session.Username}!";
        }
        private void linkLabelUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new admin.UsersForm();
            usersForm.Show();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LoadScheduleData();
        }
     

        private void SetupForm()
        {
            this.Text = "Bin Selector";
       
            binDropdown = new ComboBox { Left = 300, Top = 300, Width = 180 };
            this.Controls.Add(binDropdown);

            selectButton = new Button { Text = "Select Bin", Left = 300, Top = 350, Width = 100 };
            selectButton.Click += SelectButton_Click;
            this.Controls.Add(selectButton);
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            string binid = binDropdown.SelectedItem.ToString();
            DateTime date = monthCalendar.SelectionRange.Start;
            Console.WriteLine($"{binid} : {date}");
            string poorsoul = who();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = @"INSERT INTO Schedule (DateCreated, CreatedBy, ForUser, ActivityExpected, bin)
                                VALUES(@datetime, @admin, @user, @msg, (SELECT Bin_Id FROM Bin WHERE Location = @bin));";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@datetime",date);
            cmd.Parameters.AddWithValue("@admin", Session.UserId);
            cmd.Parameters.AddWithValue("@user", poorsoul);
            cmd.Parameters.AddWithValue("@msg", "Routine Check.");
            cmd.Parameters.AddWithValue("@bin", binid);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string queryagain = "INSERT INTO Chat VALUES (@datetime, @admin, @user, @msg);";

            SqlCommand cmdagain = new SqlCommand(queryagain, conn);
            cmdagain.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmdagain.Parameters.AddWithValue("@admin", "0");
            cmdagain.Parameters.AddWithValue("@user", poorsoul);
            cmdagain.Parameters.AddWithValue("@msg", $"Routine Check at bin {binid}");
            cmdagain.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show($"User {poorsoul} has been assigned to bin {binid}");
        }
        private string who()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = @"
                             SELECT TOP 1 User_Id FROM [User] WHERE User_Role <> 'admin' ORDER BY NEWID();
                            ";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string huh = reader.GetInt32(0).ToString();
            Console.WriteLine(huh);

            conn.Close();
            return huh;
        }

        private void LoadBins()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Bin_Id, Location FROM Bin", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        binDropdown.Items.Add(new Bin { Id = reader.GetInt32(0), Location = reader.GetString(1) });
                    }
                }
            }
            binDropdown.DisplayMember = "Location";
            binDropdown.ValueMember = "Id";
        }
        public class ScheduleEntry
        {
            public int Id { get; set; }
            public DateTime DateCreated { get; set; }
            public string CreatedBy { get; set; }
            public string ForUser { get; set; }
            public string ActivityExpected { get; set; }
            public int Bin { get; set; }
        }
        public class Bin
        {
            public int Id { get; set; }
            public string Location { get; set; }

            public override string ToString()
            {
                return Location;
            }
        }

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mf = new admin.MainForm();
            mf.Show();
        }

        private void linkLabelReport_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Report rp = new admin.Report();
            rp.Show();
        }

        private void linkLabelUsers_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm uf = new admin.UsersForm();
            uf.Show();
        }

        private void linkLabelSchedule_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Schedule sd = new admin.Schedule();
            sd.Show();
        }

        private void linkLabelLogs_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LogsForm lf = new admin.LogsForm();
            lf.Show();
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
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();

        }
    }
}
