using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{

    public partial class Form6 : CustomForm
    {
        private Panel sideNavPanel;
        private Button hamburgerMenu;
        private Panel settingsPanel;
        private ComboBox languageDropdown;
        private Button changeLanguageButton;
        private Button reportButton;
        private Button helpButton;

        public Form6()
        {
            this.Text = "Dashboard";
            this.Size = new Size(850, 650);
            this.BackColor = Color.White;

            CreateHamburgerMenu();
            SetupDashboard();
            CreateSettingsPanel();
            ApplyTranslations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            Hide();
        }

        // Add these fields at the top of the class
        private Button navButton1;
        private Button navButton2;
        private Button navButton3;
        private Button navButton4;
        private Button navButton5;
        private Button navButton6;
        private Button navButton7;



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

            navButton4 = new Button
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


        private void CreateSettingsPanel()
        {
            settingsPanel = new Panel
            {
                Size = new Size(400, 300),
                Location = new Point((this.Width - 400) / 2, (this.Height - 300) / 2),
                BackColor = Color.White
            };

            // Change Language components
            languageDropdown = new ComboBox
            {
                Location = new Point(100, 30),
                Width = 200
            };
            languageDropdown.Items.AddRange(new string[] { "English", "Chinese", "Tamil", "Malay" });

            changeLanguageButton = new Button
            {
                Text = "Change Language",
                Location = new Point(100, 70),
                Width = 200
            };
            changeLanguageButton.Click += ChangeLanguageButton_Click;

            // Report Button
            reportButton = new Button
            {
                Text = "Report",
                Location = new Point(100, 110),
                Width = 200
            };
            reportButton.Click += ReportButton_Click;

            // Help Button
            helpButton = new Button
            {
                Text = "Help",
                Location = new Point(100, 150),
                Width = 200
            };
            helpButton.Click += HelpButton_Click;

            Button logoutButton = new Button
            {
                Text = "Logout",
                Location = new Point(100, 190),
                Width = 200
            };
            logoutButton.Click += LogoutButton_Click;


            settingsPanel.Controls.Add(languageDropdown);
            settingsPanel.Controls.Add(changeLanguageButton);
            settingsPanel.Controls.Add(reportButton);
            settingsPanel.Controls.Add(helpButton);
            settingsPanel.Controls.Add(logoutButton);

            this.Controls.Add(settingsPanel);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have logged out.");
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            string selectedLanguage = languageDropdown.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedLanguage))
            {
                LanguageManager.Instance.LoadLanguage(selectedLanguage);
                ApplyTranslations();
                MessageBox.Show($"Language changed to: {selectedLanguage}");
                Console.WriteLine(selectedLanguage);
            }
        }


        private void ApplyTranslations()
        {
            LanguageManager lang = LanguageManager.Instance;

            // Update side navigation buttons directly
            navButton1.Text = lang.GetTranslation("Home");
            navButton2.Text = lang.GetTranslation("Priority");
            navButton3.Text = lang.GetTranslation("Chat");
            navButton4.Text = lang.GetTranslation("Settings");

            // Update settings panel buttons
            changeLanguageButton.Text = lang.GetTranslation("ChangeLanguage");
            reportButton.Text = lang.GetTranslation("Report");
            helpButton.Text = lang.GetTranslation("Help");

            // Update window title
            this.Text = lang.GetTranslation("Settings");
        }




        private void ReportButton_Click(object sender, EventArgs e)
        {
            // Assuming these are the values from the logged-in user
            string loggedInUserName = "test"; // You should replace this with the actual logged-in user's name
            int loggedInUserId = 123; // You should replace this with the actual logged-in user's ID

            // Pass user details to the ReportForm constructor
            ReportForm reportForm = new ReportForm(loggedInUserName, loggedInUserId);
            reportForm.ShowDialog();
        }


        private void HelpButton_Click(object sender, EventArgs e)
        {
            string pdfPath = "C:\\Users\\ASUS\\Desktop\\WinFrom\\WinFrom\\WinFrom\\WinFrom\\WindowsFormsApplication1\\Resources\\EWasteGuide.pdf"; // Replace with the actual path
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open the help document: {ex.Message}");
            }
        }


        private void SetupDashboard()
        {
            Application.EnableVisualStyles();
        }
    }

    // Remember to change report here :p
    public class ReportForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
        private TextBox nameTextBox;
        private TextBox idTextBox;
        private TextBox reportTextBox;
        private Button uploadImageButton;
        private Button submitButton;
        private OpenFileDialog imageUploadDialog;

        // Added properties to accept User's name and ID from the logged-in session
        public string UserName { get; set; }
        public int UserId { get; set; }

        public ReportForm(string userName, int userId)
        {
            this.UserName = userName;
            this.UserId = userId;

            this.Text = "Report Form";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            SetupFormComponents();
            AutofillFields();  // Autofill name and ID
        }

        private void SetupFormComponents()
        {
            nameTextBox = new TextBox { Text = "Name", Location = new Point(50, 30), Width = 300 };
            idTextBox = new TextBox { Text = "ID", Location = new Point(50, 70), Width = 300 };
            reportTextBox = new TextBox { Text = "Report", Location = new Point(50, 110), Width = 300, Height = 100, Multiline = true };
            uploadImageButton = new Button { Text = "Upload Image", Location = new Point(50, 230), Width = 300 };
            submitButton = new Button { Text = "Submit", Location = new Point(50, 270), Width = 300 };

            uploadImageButton.Click += UploadImageButton_Click;
            submitButton.Click += SubmitButton_Click;

            this.Controls.Add(nameTextBox);
            this.Controls.Add(idTextBox);
            this.Controls.Add(reportTextBox);
            this.Controls.Add(uploadImageButton);
            this.Controls.Add(submitButton);

            imageUploadDialog = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
        }

        // Autofill name and ID text boxes
        private void AutofillFields()
        {
            nameTextBox.Text = this.UserName;
            idTextBox.Text = this.UserId.ToString();

            // Make the name and ID fields read-only to prevent user modification
            nameTextBox.ReadOnly = true;
            idTextBox.ReadOnly = true;
        }


        private void UploadImageButton_Click(object sender, EventArgs e)
        {
            if (imageUploadDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Image uploaded: {imageUploadDialog.FileName}");
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string reportText = reportTextBox.Text;
            string imagePath = imageUploadDialog.FileName;

            // Save report to the database
            SaveReportToDatabase(reportText, imagePath);
        }

        // Save report details to the database
        private void SaveReportToDatabase(string reportText, string imagePath)
        {
            try
            {
                // Database connection and command execution
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert report into database
                    string query = "INSERT INTO Reports (User_Id, ReportText, ImagePath, Active) VALUES (@UserId, @ReportText, @ImagePath, 1)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", this.UserId);
                    cmd.Parameters.AddWithValue("@ReportText", reportText);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Report submitted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit the report: {ex.Message}");
            }
        }
    }
}