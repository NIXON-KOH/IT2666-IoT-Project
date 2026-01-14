using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;


namespace WindowsFormsApplication1
{
    public partial class Form9 : CustomForm
    {
        private Panel sideNavPanel;
        private Button hamburgerMenu;
        // Replace with your actual database connection string
        private string connectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;

        public Form9()
        {
            this.Text = "Dashboard";
            this.Size = new Size(850, 650); // Increased size to fit everything
            this.BackColor = Color.White;

            InitializeComponent();
            LoadSchedule();
            CreateHamburgerMenu();
            SetupDashboard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            Hide();
        }

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

            //navigation panel
            sideNavPanel = new Panel
            {
                Size = new Size(200, this.Height),
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(30, 30, 30)
            };

            // Navigation buttons matching Form2
            Button navButton1 = new Button
            {
                Text = "Home",
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

            Button navButton5 = new Button
            {
                Text = "Data Log",
                Location = new Point(0, 275),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton5.FlatAppearance.BorderSize = 0;
            navButton5.Click += NavButton5_Click;

            Button navButton6 = new Button
            {
                Text = "E-waste collection",
                Location = new Point(0, 325),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton6.FlatAppearance.BorderSize = 0;
            navButton6.Click += NavButton6_Click;

            Button navButton7 = new Button
            {
                Text = "Schedule",
                Location = new Point(0, 375),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton7.FlatAppearance.BorderSize = 0;
            navButton7.Click += NavButton7_Click;

            // Add all buttons to the panel
            sideNavPanel.Controls.Add(navButton1);
            sideNavPanel.Controls.Add(navButton2);
            sideNavPanel.Controls.Add(navButton3);
            sideNavPanel.Controls.Add(navButton4);
            sideNavPanel.Controls.Add(navButton5);
            sideNavPanel.Controls.Add(navButton6);
            sideNavPanel.Controls.Add(navButton7);

            // Add controls to the form
            this.Controls.Add(hamburgerMenu);
            this.Controls.Add(sideNavPanel);
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


        // Add these new click handlers
        private void NavButton5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void NavButton6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void NavButton7_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        // Update NavButton1_Click to go to Form2 instead of showing Form2
        private void NavButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void NavButton2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        private void NavButton3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        private void NavButton4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void LoadSchedule()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, DateCreated, CreatedBy, ForUser, ActivityExpected, bin FROM Schedule";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewSchedule.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }
        private void SetupDashboard()
        {
            Application.EnableVisualStyles();
        }
    }
}
