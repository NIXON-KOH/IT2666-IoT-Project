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


namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        private Panel sideNavPanel;
        private Button hamburgerMenu;
        private Button navButton1, navButton2, navButton3, navButton4, navButton6, navButton7;
        private string connectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
        private TextBox txtBinID;
        private TextBox txtDevice;
        private TextBox txtQuantity;
        private Button btnSubmit;

        public Form7()
        {
            this.Text = "E-waste Collection Form";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupFormComponents();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            Hide();
        }

        private void SetupFormComponents()
        {
            txtBinID = new TextBox { Text = "Enter Bin ID", Location = new Point(50, 30), Width = 300 };
            txtDevice = new TextBox { Text = "Enter Device Type", Location = new Point(50, 70), Width = 300 };
            txtQuantity = new TextBox { Text = "Enter Quantity", Location = new Point(50, 110), Width = 300 };
            btnSubmit = new Button { Text = "Submit", Location = new Point(50, 150), Width = 300 };

            btnSubmit.Click += BtnSubmit_Click;

            this.Controls.Add(txtBinID);
            this.Controls.Add(txtDevice);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(btnSubmit);
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

            //navigation panel here
            sideNavPanel = new Panel
            {
                Size = new Size(200, this.Height),
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(30, 30, 30)
            };

            // Navigation buttons matching Form4
            navButton1 = new Button
            {
                Text = LanguageManager.Instance.GetTranslation("Daily Statistics"),
                Location = new Point(0, 75),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton1.FlatAppearance.BorderSize = 0;
            navButton1.Click += NavButton1_Click;

            navButton2 = new Button
            {
                Text = LanguageManager.Instance.GetTranslation("Priority"),
                Location = new Point(0, 125),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 30),
            };
            navButton2.FlatAppearance.BorderSize = 0;
            navButton2.Click += NavButton2_Click;

            navButton3 = new Button
            {
                Text = LanguageManager.Instance.GetTranslation("Chat"),
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
                Text = LanguageManager.Instance.GetTranslation("Settings"),
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
                Text = LanguageManager.Instance.GetTranslation("Data Log"),
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
                Text = LanguageManager.Instance.GetTranslation("E-waste collection"),
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
                Text = LanguageManager.Instance.GetTranslation("Schedule"),
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

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBinID.Text) ||
                string.IsNullOrWhiteSpace(txtDevice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Device_Log (Datetime, BinId, Device, Quantity) VALUES (@Datetime, @BinId, @Device, @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@BinId", txtBinID.Text);
                        cmd.Parameters.AddWithValue("@Device", txtDevice.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Data submitted successfully." : "Submission failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}

