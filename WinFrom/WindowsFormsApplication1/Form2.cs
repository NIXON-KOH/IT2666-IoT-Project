using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form2 : CustomForm
    {
        private Panel sideNavPanel;
        private Button hamburgerMenu;
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;
        private Dictionary<string, Label> statCardValueLabels = new Dictionary<string, Label>();

        private Chart liveChart;
        private Series chartSeries; // Series for the chart data
        private ComboBox chartTypeComboBox; // Declare ComboBox as a class-level variable

        private System.Windows.Forms.Timer updateTimer;

        private Dictionary<string, Queue<string>> statCardDataHistory = new Dictionary<string, Queue<string>>();
        private Dictionary<string, Panel> statCardPanels = new Dictionary<string, Panel>(); // To store stat card panels

        public Form2()
        {
            this.Text = "Dashboard";
            this.Size = new Size(850, 650); // Increased size to fit everything
            this.BackColor = Color.White;

            // Create and setup all controls
            CreateHamburgerMenu();
            SetupDashboard();
            InitializeUI(); // Call UI initialization method
            StartDataUpdates(); // Start periodic data updates
        }

        private void InitializeUI()
        {
            CreateStatCards(); // Create stat cards
            CreateChartTypeComboBox(); // Create the chart type selection combo box
            CreateChart();     // Create the chart
            
        }

        private void CreateChartTypeComboBox()
        {
            chartTypeComboBox = new ComboBox
            {
                Location = new Point(20, 130), // Position it above the chart
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList, // Prevent manual typing
            };

            // Add data options to the combo box
            chartTypeComboBox.Items.AddRange(new string[] { "Temperature", "Light", "Distance", "Water" });
            chartTypeComboBox.SelectedItem = "Temperature"; // Default selection

            chartTypeComboBox.SelectedIndexChanged += ChartTypeComboBox_SelectedIndexChanged; // Add event handler

            this.Controls.Add(chartTypeComboBox);
        }

        private void ChartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the selection changes, clear the old chart data and optionally update the chart immediately
            chartSeries.Points.Clear(); // Clear existing data points
            liveChart.ChartAreas[0].AxisY.Title = chartTypeComboBox.SelectedItem.ToString(); // Update Y-axis title
        }
        private void StartDataUpdates()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 2000; // Update every 2 seconds (adjust as needed)
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("UpdateTimer_Tick event fired!"); // Debug 1: Check if timer tick is firing
            await UpdateLiveDataAsync();
        }

        private async Task UpdateLiveDataAsync()
        {
            Debug.WriteLine("Entering UpdateLiveDataAsync()"); // Debug 2: Check if UpdateLiveDataAsync is entered
            HardwareData data = await FetchHardwareDataAsync();
            if (data != null)
            {
                Debug.WriteLine("Data fetched successfully in UpdateLiveDataAsync()"); // Debug 3: Data fetch success
                UpdateStatCards(data);
                UpdateChart(data);
            }
            else
            {
                Debug.WriteLine("FetchHardwareDataAsync returned null in UpdateLiveDataAsync()"); // Debug 4: Data fetch failure
            }
            Debug.WriteLine("Exiting UpdateLiveDataAsync()"); // Debug 5: Check if UpdateLiveDataAsync is exited
        }
        private async Task<HardwareData> FetchHardwareDataAsync()
        {
            HardwareData hardwareData = null;
            try
            {
                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    await myConnect.OpenAsync();

                    string strCommandText = "SELECT TOP 1 * FROM Hardware ORDER BY Datetime DESC";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            hardwareData = new HardwareData()
                            {
                                Datetime = Convert.ToDateTime(reader["Datetime"]),
                                Light = Convert.ToDouble(reader["Light"]),
                                Distance = Convert.ToDouble(reader["Distance"]),
                                Water = Convert.ToDouble(reader["Water"]),
                                RFID = reader["RFID"].ToString(),
                                Temperature = Convert.ToDouble(reader["Temperature"]),
                                LED_Red = Convert.ToBoolean(reader["LED_Red"]),
                                LED_Green = Convert.ToBoolean(reader["LED_Green"])
                            };
                        }
                        else
                        {
                            return null; // Handle case where no data is returned
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return hardwareData;
        }

        private void UpdateStatCards(HardwareData data)
        {
            // Update stat card values based on HardwareData and set colors
            UpdateStatCardWithColor("Times you tapped\nthe card today", data?.RFID ?? "N/A");
            UpdateStatCardWithColor("Estimate Trash disposed", data?.Distance.ToString("F2") + " kg" ?? "N/A kg");
            UpdateStatCardWithColor("Bins emptied", data?.Water.ToString() ?? "N/A");
            UpdateStatCardWithColor("Average Trash capacity\nbefore unloading", data?.Temperature.ToString("F0") + "%" ?? "N/A%");
        }

        private void CreateStatCards()
        {
            // Adjusted card positions (shifted down by 15px and right by 20px)
            CreateStatCard("Times you tapped\nthe card today", "N/A", 40, 35);
            CreateStatCard("Estimate Trash disposed", "N/A", 240, 35);
            CreateStatCard("Bins emptied", "N/A", 440, 35);
            CreateStatCard("Average Trash capacity\nbefore unloading", "N/A", 640, 35);
        }

        private void UpdateStatCardWithColor(string cardTitle, string newValue)
        {
            if (statCardValueLabels.ContainsKey(cardTitle) && statCardPanels.ContainsKey(cardTitle)) // Ensure panel dictionary check too
            {
                Label valueLabel = statCardValueLabels[cardTitle];
                Panel cardPanel = statCardPanels[cardTitle]; // Get the panel

                Queue<string> dataQueue = statCardDataHistory[cardTitle];

                dataQueue.Enqueue(newValue); // Add new value to queue

                if (dataQueue.Count > 3) // Keep only last 3 values
                {
                    dataQueue.Dequeue(); // Remove oldest value
                }

                valueLabel.Text = newValue; // Update the value label

                // Determine color based on data history
                if (newValue == "N/A" || newValue.Contains("N/A")) // Check for "N/A" for missing data (more robust check)
                {
                    cardPanel.BackColor = Color.Firebrick; // Red for missing data
                }
                else if (dataQueue.Count == 3 &&
                         dataQueue.All(val => val == dataQueue.Peek())) // Check if all 3 values are the same
                {
                    cardPanel.BackColor = Color.RoyalBlue; // Blue if unchanged for 3 iterations
                }
                else
                {
                    cardPanel.BackColor = Color.Green; // Green if data changed or less than 3 iterations
                }
            }
        }



        private void CreateStatCard(string title, string value, int x, int y)
        {
            Panel card = new Panel // Keep Panel creation
            {
                Location = new Point(x, y),
                Size = new Size(180, 100),
                BackColor = Color.LightGray, // Default to light gray when created
            };

            Label valueLabel = new Label // Keep Label creation
            {
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Label titleLabel = new Label // Keep Label creation
            {
                Text = title,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(10, 50),
                ForeColor = Color.Gray
            };

            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            this.Controls.Add(card);

            // Store the value label in the dictionary for updates (keep this)
            statCardValueLabels.Add(title, valueLabel);

            // Initialize data history queue for this card
            statCardDataHistory.Add(title, new Queue<string>());

            // Store the panel in the dictionary
            statCardPanels.Add(title, card); // Store the panel here

            Debug.WriteLine($"Exiting CreateStatCard() with title: '{title}'");
        }


        private void UpdateChart(HardwareData data)
        {
            Debug.WriteLine("Entering UpdateChart()");
            try
            {
                if (liveChart != null && chartSeries != null && data != null && chartTypeComboBox.SelectedItem != null) // Check ComboBox selection
                {
                    Debug.WriteLine("Chart, Series, Data, and ComboBox are not null in UpdateChart()");

                    string selectedDataType = chartTypeComboBox.SelectedItem.ToString();
                    double yValue = double.NaN; // Default Y value if data type is not found or is null

                    // Get the Y value based on the selected data type
                    switch (selectedDataType)
                    {
                        case "Temperature":
                            if (data.Temperature != null) yValue = data.Temperature; // Use .Value to access double? from double?
                            break;
                        case "Light":
                            if (data.Light != null) yValue = data.Light; // Use .Value to access double? from double?
                            break;
                        case "Distance":
                            if (data.Distance != null) yValue = data.Distance; // Use .Value to access double? from double?
                            break;
                        case "Water":
                            if (data.Water != null) yValue = data.Water; // Use .Value to access double? from double?
                            break;
                        default:
                            Debug.WriteLine($"Unknown data type selected: {selectedDataType}");
                            return; // Exit if unknown type
                    }


                    if (!double.IsNaN(yValue)) // Only add point if yValue is a valid number
                    {
                        DateTime currentTime = DateTime.Now;
                        chartSeries.Points.AddXY(currentTime.ToString("HH:mm:ss"), yValue);

                        if (chartSeries.Points.Count > 10)
                        {
                            chartSeries.Points.RemoveAt(0);
                            liveChart.ChartAreas[0].AxisX.Minimum = chartSeries.Points[0].XValue;
                            liveChart.ChartAreas[0].AxisX.Maximum = chartSeries.Points.Last().XValue;
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"{selectedDataType} value is null in UpdateChart()!"); // Debug: Data value is null
                    }
                }
                else
                {
                    Debug.WriteLine("Chart, Series, Data, or ComboBox is null in UpdateChart()");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in UpdateChart: {ex.Message}");
            }
            Debug.WriteLine("Exiting UpdateChart()");
        }


        private void CreateChart()
        {
            liveChart = new Chart(); // Assign to the class-level variable
            liveChart.Location = new Point(20, 165);
            liveChart.Size = new Size(780, 400);

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.Title = chartTypeComboBox.SelectedItem?.ToString() ?? "Data Value"; // Initial Y-axis title, default if none selected
            liveChart.ChartAreas.Add(chartArea);

            chartSeries = new Series(); // Assign to the class-level variable
            chartSeries.ChartType = SeriesChartType.Line;
            chartSeries.Color = Color.FromArgb(0, 192, 192); // Cyan color
            chartSeries.BorderWidth = 3;
            liveChart.Series.Add(chartSeries);

            liveChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss"; // Format X-axis for time
            liveChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Interval in seconds
            liveChart.ChartAreas[0].AxisX.Interval = 30; // Show label every 30 seconds (adjust as needed)

            this.Controls.Add(liveChart);
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

            // hehe buttons to the side navigation panel here
            Button navButton1 = new Button
            {
                Text = "Daily Statistics",
                Location = new Point(0,75),
                Size = new Size(200,50),
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

        private void NavButton6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void NavButton5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void NavButton7_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
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
    
        private void SetupDashboard()
        {
            Application.EnableVisualStyles();
        }
    }
}
