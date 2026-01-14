using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form5 : CustomForm
    {
        private Panel sideNavPanel;
        private Button hamburgerMenu;

        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
        private Dictionary<string, ListBox> messageListBoxes = new Dictionary<string, ListBox>();
        private string currentUserId = Session.UserID;

        public Form5()
        {
            this.Text = "Dashboard";
            this.Size = new Size(850, 650);
            this.BackColor = Color.White;
            
            CreateHamburgerMenu();
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            LoadConversations();

            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e) {
            LoadMessages(tabControl1.SelectedTab.Name, messageListBoxes[tabControl1.SelectedTab.Name]);
        }
        private void LoadConversations()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"SELECT User_Id as Partner, User_Name as [username] FROM [User] WHERE User_Id != @UserId;";

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
            string partnername = tabControl1.SelectedTab.Name;
            TextBox txt = null;
            foreach (Control control in tabControl1.SelectedTab.Controls)
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
                cmd.Parameters.AddWithValue("@partnerid", partnername);
                cmd.Parameters.AddWithValue("@message", msg);

                cmd.ExecuteNonQuery();
                txt.Text = "";
            }


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

            //navigation panel heres
            sideNavPanel = new Panel
            {
                Size = new Size(200, this.Height),
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(30, 30, 30)
            };

            // Navigation buttons matching Form4
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



        private void NavButton1_Click(object sender, EventArgs e)
        {
            // go to Form2
            Form2 form2 = new Form2();
            form2.Show();
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

    }
}