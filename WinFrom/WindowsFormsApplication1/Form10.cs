using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form10 : CustomForm
    {
        private DataGridView logDataGridView;
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
        private Panel sideNavPanel;
        private Button hamburgerMenu;
        
        private void CreateHamburgerMenu()
        {
            // Create the hamburger menu button
            hamburgerMenu = new Button
            {
                Text = "☰",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(0, 25),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            hamburgerMenu.FlatAppearance.BorderSize = 0;
            hamburgerMenu.Click += HamburgerMenu_Click;

            //navigation panel heres
            sideNavPanel = new Panel
            {
                Size = new Size(200, this.Height),
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(30, 30, 30)
            };

            // hehe buttons to the side navigation panel here
            Button navButton1 = new Button
            {
                Text = "Daily Statistics",
                Location = new Point(0, 75),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton1.FlatAppearance.BorderSize = 0;
            navButton1.Click += NavButton1_Click;

            Button navButton2 = new Button
            {
                Text = "Priority",
                Location = new Point(0, 125),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton2.FlatAppearance.BorderSize = 0;
            navButton2.Click += NavButton2_Click;

            Button navButton3 = new Button
            {
                Text = "Chat",
                Location = new Point(0, 175),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton3.FlatAppearance.BorderSize = 0;
            navButton3.Click += NavButton3_Click;

            Button navButton4 = new Button
            {
                Text = "Settings",
                Location = new Point(0, 225),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton4.FlatAppearance.BorderSize = 0;
            navButton4.Click += NavButton4_Click;

            Button navButton5 = new Button // New button for Form10
            {
                Text = "Data Log",
                Location = new Point(0, 275), // Adjust location below navButton4
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton5.FlatAppearance.BorderSize = 0;
            navButton5.Click += NavButton5_Click; // Add click event handler


            sideNavPanel.Controls.Add(navButton1);
            sideNavPanel.Controls.Add(navButton2);
            sideNavPanel.Controls.Add(navButton3);
            sideNavPanel.Controls.Add(navButton4);
            sideNavPanel.Controls.Add(navButton5);


            // Add controls to the form
            this.Controls.Add(hamburgerMenu);
            this.Controls.Add(sideNavPanel);
        }

        private void NavButton5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void HamburgerMenu_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the side navigation bar
            if (sideNavPanel.Location.X < 0)
            {
                // Show the side navigation panel
                sideNavPanel.Location = new Point(0, 0);
            }
            else
            {
                // Hide the side navigation panel
                sideNavPanel.Location = new Point(-200, 0);
            }
        }

        private void NavButton1_Click(object sender, EventArgs e)
        {
            // go to Form3
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        private void NavButton2_Click(object sender, EventArgs e)
        {
            // go to Form4
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        private void NavButton3_Click(object sender, EventArgs e)
        {
            // go to Form5
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        private void NavButton4_Click(object sender, EventArgs e)
        {
            // go to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        public Form10()
        {
            this.Text = "Data Log";
            this.Size = new Size(900, 700); // Adjust size as needed
            this.BackColor = Color.White;

            InitializeLogUI();
            LoadLogData(); // Load data when form starts
        }

        private void InitializeLogUI()
        {
            // Create DataGridView
            logDataGridView = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(860, 640), // Adjust size as needed
                AllowUserToAddRows = false, // Prevent user from adding rows manually
                AllowUserToDeleteRows = false, // Prevent user from deleting rows manually
                ReadOnly = true, // Make it read-only
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill // Fill columns to fit width
            };
            this.Controls.Add(logDataGridView);
        }

        private async void LoadLogData()
        {
            DataTable logData = await FetchHardwareLogDataAsync();
            if (logData != null)
            {
                logDataGridView.DataSource = logData;
            }
            else
            {
                MessageBox.Show("Failed to load log data.", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<DataTable> FetchHardwareLogDataAsync()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    await myConnect.OpenAsync();

                    // Select all columns and all rows for logging
                    string strCommandText = "SELECT Datetime, Light, Distance, Water, RFID, Temperature, LED_Red, LED_Green FROM Hardware ORDER BY Datetime DESC";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader); // Load data reader directly into DataTable
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Database error in FetchHardwareLogDataAsync: {ex.Message}");
                return null; // Return null in case of error
            }
            return dataTable;
        }
    }
}
