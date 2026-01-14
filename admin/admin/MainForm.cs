using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.Drawing;
using System.Linq;

namespace admin
{
    public partial class MainForm : Form
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        bool error = false;
        private bool _isFirstLoad = true;

        int LightThreshold;
        float FillThresholdSoft;
        float FillThresholdHard;
        float TemperatureThreshold;
        float waterThreshold;
        //Get all threshold to be used.

        private void ThresholdCheck()
        {
            string query = "SELECT TOP 1 * FROM Threshold ORDER BY Id DESC ";
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        LightThreshold = int.Parse(reader["light"].ToString());
                    }
                    catch { LightThreshold = 400; } //Hardcoded Default Value

                    try
                    {
                        FillThresholdSoft = float.Parse(reader["fill level soft"].ToString());

                    }
                    catch
                    {
                        FillThresholdSoft = 0.5F;
                    }

                    try
                    {
                        FillThresholdHard = float.Parse(reader["fill level hard"].ToString());

                    }
                    catch
                    {
                        FillThresholdHard = 0.8F;
                    }
                    try
                    {
                        TemperatureThreshold = float.Parse(reader["Temperature"].ToString());
                    }
                    catch
                    {
                        TemperatureThreshold = 40F;
                    }
                    try
                    {
                        waterThreshold = float.Parse(reader["Water"].ToString());
                    }
                    catch
                    {
                        waterThreshold = 0.2F;
                    }

                }
            }
           }

        public MainForm()
        {
            InitializeComponent();
        }
        public delegate void myprocessDataDelegate(string strData);
        private static DataComms dataComms;

        public void commsDataRecieve(string dataReceived)
        {
            HandleData(dataReceived);
        }

        public void commsSendError(string errMsg)
        {
            MessageBox.Show(errMsg);
        }


        private void InitComms()
        {
            try
            {
                dataComms = new DataComms();

                dataComms.dataReceiveEvent += new DataComms.DataReceivedDelegate(commsDataRecieve);
                dataComms.dataSendErrorEvent += new DataComms.DataSendErrorDelegate(commsSendError);
            }
            catch
            {

            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            labelUsername.Text = $"Welcome, {Session.Username}!";
            ThresholdCheck();
            InitializeTabControl();
            //if (_isFirstLoad)
            //{
                //InitComms();
                //_isFirstLoad = false;
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ErrorMsg();

            if (tabControlBins.SelectedTab != null) {

                int binId = int.Parse(tabControlBins.SelectedTab.Tag.ToString());
                LoadChartsForTab(binId);
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

        private void InitializeTabControl()
        {
            try
            {
                string query = "SELECT Bin_Id, Location FROM Bin ORDER BY Bin_Id";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int binId = reader.GetInt32(0);
                        string location = reader.GetString(1);

                        TabPage tabPage = new TabPage($"Bin {binId}");
                        tabPage.Tag = binId.ToString();
                        tabPage.Controls.Add(CreateSummaryPanel(location));
                        tabControlBins.TabPages.Add(tabPage);
                    }

                    tabControlBins.SelectedIndexChanged += TabControlBins_SelectedIndexChanged;

                    if (tabControlBins.TabPages.Count > 0)
                    {
                        LoadChartsForTab((int)tabControlBins.TabPages[0].Tag);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private Panel CreateSummaryPanel(string location)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            Label label = new Label
            {
                Text = $"Location: {location}",
                Dock = DockStyle.Left,
                AutoSize = true
            };

            panel.Controls.Add(label);
            return panel;
        }

        private void TabControlBins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlBins.SelectedTab != null)
            {
                int binId = int.Parse(tabControlBins.SelectedTab.Tag.ToString());
                LoadChartsForTab(binId);
            }
        }
        private void HandleData(string strData)
        {
            //string strData = "Bin=1, Light=123, Distance=123, Water=123, RFID='Test', Temp=123, Red=True, Green=False";

            string[] splitData = strData.Split(',');



            //Variables
            int bin_id = 0;
            int light = 0;
            int distance = 0;
            int water = 0;
            string rfid = string.Empty;
            int temp = 0;
            bool ledred = false;
            bool ledgreen = false;

            foreach (string i in splitData)
            {
                string[] keyValue = i.Trim().Split('=');

                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "Bin":
                        bin_id = int.Parse(value);
                        break;

                    case "Light":
                        light = int.Parse(value);
                        break;

                    case "Distance":
                        distance = int.Parse(value);
                        break;

                    case "Water":
                        water = int.Parse(value);
                        break;

                    case "RFID":
                        rfid = value;
                        break;

                    case "Temp":
                        temp = int.Parse(value.Split('.')[0]);
                        break;

                    case "Red":
                        ledred = bool.Parse(value);
                        break;

                    case "Green":
                        Console.WriteLine(value);
                        ledgreen = bool.Parse(value);
                        break;


                }
            }

            SqlConnection myConnect = new SqlConnection(ConnectionString);


            string query = "INSERT Hardware (Bin_Id, Datetime, Light, Distance, Water, RFID, Temperature, LED_Red, LED_Green) " +
                            "VALUES (@Bin_Id, @Datetime, @Light, @Distance, @Water, @RFID, @Temp, @LED_Red, @LED_Green)";
            SqlCommand command = new SqlCommand(query, myConnect);


            command.Parameters.AddWithValue("@Bin_Id", bin_id);
            command.Parameters.AddWithValue("@Datetime", DateTime.Now);
            command.Parameters.AddWithValue("@Light", light);
            command.Parameters.AddWithValue("@Distance", distance);
            command.Parameters.AddWithValue("@Water", water);
            command.Parameters.AddWithValue("@RFID", rfid);
            command.Parameters.AddWithValue("@Temp", temp);
            command.Parameters.AddWithValue("@LED_Red", ledred);
            command.Parameters.AddWithValue("@LED_Green", ledgreen);

            myConnect.Open();
            int result = command.ExecuteNonQuery();
            myConnect.Close();
        }


        private void LoadChartsForTab(int binId)
        {
            try
            {
                Console.WriteLine("Load Chart for tab triggered");
                LoadLightChartData(binId);
                UpdateThermometerChart(binId);
                UpdateWaterLevelChart(binId);
                UpdateDistanceChart(binId);
                UpdateLEDIndicators(binId);
                UpdateBinStatus(binId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading charts for Bin {binId}: {ex.Message}");
            }
        }

        private void LoadLightChartData(int binId)
        {
            try
            {
                // Check if the chart already exists for this bin
                Chart chart = tabControlBins.SelectedTab.Controls.OfType<Chart>()
                    .FirstOrDefault(c => c.Name == $"LightChart_{binId}");

                // If the chart doesn't exist, create a new one
                if (chart == null)
                {
                    chart = new Chart
                    {
                        Name = $"LightChart_{binId}",
                        Dock = DockStyle.None,
                        Width = 450,
                        Height = 450,
                        Location = new Point(10, 60),
                        BackColor = Color.WhiteSmoke, // Subtle background
                        BorderlineDashStyle = ChartDashStyle.Solid,
                        BorderlineColor = Color.Gray,
                        BorderlineWidth = 1
                    };
                    tabControlBins.SelectedTab.Controls.Add(chart);

                    // Create ChartArea
                    ChartArea chartArea = new ChartArea
                    {
                        BackColor = Color.Transparent,
                        AxisX = {
                    Title = "Time",
                    TitleFont = new Font("Segoe UI", 10, FontStyle.Bold),
                    TitleForeColor = Color.Black,
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.DimGray },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot }
                },
                        AxisY = {
                    Title = "Light Intensity",
                    TitleFont = new Font("Segoe UI", 10, FontStyle.Bold),
                    TitleForeColor = Color.Black,
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.DimGray },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot }
                }
                    };
                    chart.ChartAreas.Add(chartArea);

                    // Add Legend
                    Legend legend = new Legend("Legend1")
                    {
                        Docking = Docking.Top,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    chart.Legends.Add(legend);

                    // Create Series
                    Series lightSeries = new Series("Light")
                    {
                        ChartType = SeriesChartType.Line,
                        Color = Color.Blue,
                        BorderWidth = 1, // Thinner line
                        Legend = "Legend1",
                        LegendText = "Light Intensity"
                    };
                    chart.Series.Add(lightSeries);
                }

                // Assuming the series is always the first (and only) series
                Series series = chart.Series[0];

                // Query data from the database
                string query = "SELECT TOP 100 Datetime, Light FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear previous points to refresh data
                    series.Points.Clear();

                    while (reader.Read())
                    {
                        DateTime timestamp = (DateTime)reader["Datetime"];
                        string formattedTimestamp = timestamp.ToString("HH:mm:ss");
                        int lightValue = (int)reader["Light"];

                        // Add data points to the series
                        series.Points.AddXY(formattedTimestamp, lightValue);

                        // Update the label based on the light value
                        labelOpenClose.Text = lightValue > LightThreshold ? "Open" : "Close";
                    }
                }

                // Refresh the chart to reflect the new data
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading light chart data: {ex.Message}");
            }
        }


        private void UpdateThermometerChart(int binId)
        {
            try
            {
                // Check if the chart already exists for this bin
                Chart chart = tabControlBins.SelectedTab.Controls
                    .OfType<Chart>()
                    .FirstOrDefault(c => c.Name == $"ThermometerChart_{binId}");

                if (chart == null)
                {
                    // Create the chart if it doesn't exist
                    chart = new Chart
                    {
                        Name = $"ThermometerChart_{binId}",
                        Dock = DockStyle.None,
                        Width = 250,
                        Height = 450,
                        Location = new Point(550, 60), // Position within the tab
                        BackColor = Color.Transparent, // Transparent background for dashboard integration
                        BorderlineDashStyle = ChartDashStyle.Solid,
                        BorderlineColor = Color.Gray,
                        BorderlineWidth = 1
                    };

                    // Configure chart area
                    ChartArea chartArea = new ChartArea("ChartArea1")
                    {
                        BackColor = Color.WhiteSmoke, // Subtle background color
                        AxisX = { Enabled = AxisEnabled.False }, // Hide X-axis
                        AxisY = {
                    Maximum = 100,
                    Minimum = 0,
                    Title = "Temperature (°C)",
                    TitleFont = new Font("Segoe UI", 10, FontStyle.Bold),
                    TitleForeColor = Color.Black,
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.DimGray },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot },
                    LineColor = Color.Gray
                }
                    };
                    chart.ChartAreas.Add(chartArea);

                    // Enable legend
                    chart.Legends.Add(new Legend("Legend1") { Enabled = true, Docking = Docking.Top, Font = new Font("Segoe UI", 9, FontStyle.Bold) });

                    // Configure the series
                    Series series = new Series("TemperatureSeries")
                    {
                        ChartArea = "ChartArea1",
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true,
                        LabelForeColor = Color.Black,
                        Color = Color.FromArgb(255, 99, 71), // Tomato color for heat indication
                        BorderColor = Color.DarkRed,
                        BorderWidth = 2,
                        Legend = "Legend1",
                        LegendText = "Temperature"
                    };
                    series["PointWidth"] = "0.6"; // Sleeker cylinder style
                    series["DrawingStyle"] = "Cylinder"; // Cylinder appearance

                    chart.Series.Add(series);

                    // Add the chart to the selected tab
                    tabControlBins.SelectedTab.Controls.Add(chart);
                }

                // Fetch and update the data
                string query = "SELECT TOP 1 Temperature FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int temperature = Convert.ToInt32(result);
                        labelTemperature.Text = $"{temperature}°C";

                        // Update the existing series
                        Series series = chart.Series["TemperatureSeries"];
                        series.Points.Clear();
                        series.Points.AddY(temperature);

                        // Dynamic color change based on temperature
                        series.Color = temperature > TemperatureThreshold ? Color.Red : Color.Blue;

                        chart.Invalidate(); // Redraw the chart
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating thermometer chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

        private void UpdateWaterLevelChart(int binId)
        {
            try
            {
                // Query to fetch the water sensor value
                string query = "SELECT TOP 1 Water FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int sensorValue = Convert.ToInt32(result);
                        int waterLevelPercentage = 100 - ((sensorValue * 100) / 1023);  // Water level percentage
                        labelWaterLevel.Text = $"{waterLevelPercentage}%";

                        // Check if the chart already exists for this bin
                        Chart chart = tabControlBins.SelectedTab.Controls
                            .OfType<Chart>()
                            .FirstOrDefault(c => c.Name == $"WaterLevelChart_{binId}");

                        if (chart == null)
                        {
                            // Create the chart if it doesn't exist
                            chart = new Chart
                            {
                                Name = $"WaterLevelChart_{binId}",
                                Dock = DockStyle.None,
                                Width = 450,  // Adjust width to fit horizontal chart
                                Height = 300, // Adjust height to fit horizontal chart
                                Location = new Point(10, 550),  // Set position as per your design
                                BackColor = Color.WhiteSmoke,  // Clean background
                                BorderlineDashStyle = ChartDashStyle.Solid,
                                BorderlineColor = Color.Gray,
                                BorderlineWidth = 1
                            };

                            // Set the chart area
                            ChartArea chartArea = new ChartArea("ChartArea1")
                            {
                                AxisX = { Enabled = AxisEnabled.False }, // Hide X-axis
                                AxisY = {
                            Maximum = 100,
                            Title = "Water Level (%)",
                            TitleFont = new Font("Segoe UI", 10, FontStyle.Bold),
                            TitleForeColor = Color.Black,
                            LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.DimGray },
                            MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot },
                            LineColor = Color.Gray
                        }
                            };
                            chart.ChartAreas.Add(chartArea);

                            // Set the legend
                            Legend legend = new Legend("Legend1")
                            {
                                Enabled = true,
                                Docking = Docking.Top,
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                ForeColor = Color.Black
                            };
                            chart.Legends.Add(legend);

                            // Add the series (horizontal bar chart)
                            Series series = new Series("WaterLevelSeries")
                            {
                                ChartArea = "ChartArea1",
                                ChartType = SeriesChartType.Bar,  // Horizontal bar
                                Legend = "Legend1",
                                LegendText = "Water Level",
                                Color = Color.FromArgb(70, 130, 180), // Steel Blue
                                BorderColor = Color.DarkBlue,
                                BorderWidth = 2
                            };

                            // Set the appearance for the bars
                            series["PointWidth"] = "0.6"; // Adjust bar thickness

                            chart.Series.Add(series);

                            // Add the chart to the selected tab
                            tabControlBins.SelectedTab.Controls.Add(chart);
                        }

                        // Access the existing series and update the data
                        Series waterSeries = chart.Series["WaterLevelSeries"];
                        waterSeries.Points.Clear();  // Clear any old data

                        // Add the new water level data
                        waterSeries.Points.AddY(waterLevelPercentage);

                        // Refresh the chart to reflect the new data
                        chart.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating water level chart: {ex.Message}");
            }
        }




        private void UpdateDistanceChart(int binId)
        {
            try
            {
                // Check if the chart already exists for this bin
                Chart chart = tabControlBins.SelectedTab.Controls
                    .OfType<Chart>()
                    .FirstOrDefault(c => c.Name == $"DistanceChart_{binId}");

                if (chart == null)
                {
                    // Create the chart if it doesn't exist
                    chart = new Chart
                    {
                        Name = $"DistanceChart_{binId}",
                        Dock = DockStyle.None,
                        Width = 200,
                        Height = 450,
                        Location = new Point(850, 60), // Position within the tab
                        BackColor = Color.Transparent, // Transparent background for dashboard integration
                        BorderlineDashStyle = ChartDashStyle.Solid,
                        BorderlineColor = Color.Gray,
                        BorderlineWidth = 1
                    };

                    // Set the chart area with styling
                    ChartArea chartArea = new ChartArea("ChartArea1")
                    {
                        BackColor = Color.WhiteSmoke, // Subtle background color
                        AxisX = { Enabled = AxisEnabled.False }, // Hide X-axis
                        AxisY = {
                    Maximum = 100,
                    Minimum = 0,
                    Title = "Fill Level (%)",
                    TitleFont = new Font("Segoe UI", 10, FontStyle.Bold),
                    TitleForeColor = Color.Black,
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.DimGray },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot },
                    LineColor = Color.Gray
                }
                    };
                    chart.ChartAreas.Add(chartArea);

                    // Enable legend with custom styling
                    chart.Legends.Add(new Legend("Legend1")
                    {
                        Enabled = true,
                        Docking = Docking.Top,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    });

                    // Configure the series with column chart appearance
                    Series series = new Series("BinFillLevel")
                    {
                        ChartArea = "ChartArea1",
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true,
                        LabelForeColor = Color.Black,
                        BorderColor = Color.DarkRed,
                        BorderWidth = 2,
                        Legend = "Legend1",
                        LegendText = "Fill Level"
                    };
                    series["PointWidth"] = "0.6"; // Sleeker column style
                    series["DrawingStyle"] = "Cylinder"; // Cylinder appearance

                    chart.Series.Add(series);

                    // Add the chart to the selected tab
                    tabControlBins.SelectedTab.Controls.Add(chart);
                }

                // Fetch and update the data
                string query = "SELECT TOP 1 Distance FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int distance = Convert.ToInt32(result);
                        int fullness = 100 - ((distance * 100) / 400);
                        labelFullness.Text = $"{fullness}%";

                        // Access the existing series and update the data
                        Series series = chart.Series["BinFillLevel"];
                        series.Points.Clear();

                        // Add the new fullness data with color change based on the fullness level
                        DataPoint point = new DataPoint(0, fullness)
                        {
                            // Set the color based on the fullness level
                            Color = fullness >= FillThresholdHard ? Color.Red : Color.Green
                        };
                        series.Points.Add(point);

                        // Refresh the chart to display the updated data
                        chart.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating distance chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLEDIndicators(int binId)
        {
            try
            {
                // Check if the GroupBox already exists
                GroupBox groupBoxLEDs = tabControlBins.SelectedTab.Controls
                    .OfType<GroupBox>()
                    .FirstOrDefault(g => g.Name == $"GroupBoxLEDs_{binId}");

                if (groupBoxLEDs == null)
                {
                    // Create GroupBox
                    groupBoxLEDs = new GroupBox
                    {
                        Name = $"GroupBoxLEDs_{binId}",
                        Text = "LED Status",
                        Size = new Size(200, 150), // Increased size
                        Location = new Point(550, 550), // Adjust as needed
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.Black,
                        BackColor = Color.LightGray
                    };
                    tabControlBins.SelectedTab.Controls.Add(groupBoxLEDs);
                }

                // Check if LED panels exist
                Panel panelRedLED = groupBoxLEDs.Controls
                    .OfType<Panel>()
                    .FirstOrDefault(p => p.Name == $"PanelRedLED_{binId}");

                Panel panelGreenLED = groupBoxLEDs.Controls
                    .OfType<Panel>()
                    .FirstOrDefault(p => p.Name == $"PanelGreenLED_{binId}");

                Label labelOnOff = groupBoxLEDs.Controls
                    .OfType<Label>()
                    .FirstOrDefault(l => l.Name == $"LabelOnOff_{binId}");

                if (panelRedLED == null)
                {
                    panelRedLED = new Panel
                    {
                        Name = $"PanelRedLED_{binId}",
                        Size = new Size(20, 20),
                        Location = new Point(20, 30),
                        BackColor = Color.Gray,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    groupBoxLEDs.Controls.Add(panelRedLED);

                    Label lblRed = new Label
                    {
                        Text = "Red",
                        Location = new Point(45, 30),
                        AutoSize = true
                    };
                    groupBoxLEDs.Controls.Add(lblRed);
                }

                if (panelGreenLED == null)
                {
                    panelGreenLED = new Panel
                    {
                        Name = $"PanelGreenLED_{binId}",
                        Size = new Size(20, 20),
                        Location = new Point(20, 60),
                        BackColor = Color.Gray,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    groupBoxLEDs.Controls.Add(panelGreenLED);

                    Label lblGreen = new Label
                    {
                        Text = "Green",
                        Location = new Point(45, 60),
                        AutoSize = true
                    };
                    groupBoxLEDs.Controls.Add(lblGreen);
                }

                if (labelOnOff == null)
                {
                    labelOnOff = new Label
                    {
                        Name = $"LabelOnOff_{binId}",
                        Location = new Point(20, 100),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true
                    };
                    groupBoxLEDs.Controls.Add(labelOnOff);
                }

                // Fetch LED status from database
                string query = "SELECT TOP 1 LED_Red, LED_Green FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isRedOn = (bool)reader["LED_Red"];
                        bool isGreenOn = (bool)reader["LED_Green"];

                        // Update panel colors
                        panelRedLED.BackColor = isRedOn ? Color.Red : Color.Gray;
                        panelGreenLED.BackColor = isGreenOn ? Color.Green : Color.Gray;

                        // Update label text
                        labelOnOff.Text = isGreenOn ? "ON" : "OFF";
                        labelOnOff.ForeColor = isGreenOn ? Color.Green : Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating LED indicators: {ex.Message}", "LED Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBinStatus(int binId)
        {
        
                // Check if the GroupBox already exists for the specific binId
                GroupBox groupBoxBinStatus = tabControlBins.SelectedTab.Controls
                    .OfType<GroupBox>()
                    .FirstOrDefault(g => g.Name == $"GroupBoxBinStatus_{binId}");

                if (groupBoxBinStatus == null)
                {
                    // Create GroupBox if it doesn't exist
                    groupBoxBinStatus = new GroupBox
                    {
                        Name = $"GroupBoxBinStatus_{binId}",
                        Text = "Bin Status Summary",
                        Size = new Size(300, 250),
                        Location = new Point(800, 550), // Adjust as needed
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.Black,
                        BackColor = Color.LightGray
                    };
                    tabControlBins.SelectedTab.Controls.Add(groupBoxBinStatus);
                }

                // Retrieve or create labels for binId
                Label lblStatus = GetOrCreateLabel(groupBoxBinStatus, $"LabelStatus_{binId}", new Point(20, 30));
                Label lblTemperature = GetOrCreateLabel(groupBoxBinStatus, $"LabelTemperature_{binId}", new Point(20, 60));
                Label lblWaterLevel = GetOrCreateLabel(groupBoxBinStatus, $"LabelWaterLevel_{binId}", new Point(20, 90));
                Label lblFillLevel = GetOrCreateLabel(groupBoxBinStatus, $"LabelFillLevel_{binId}", new Point(20, 120));
                Label lblBinLid = GetOrCreateLabel(groupBoxBinStatus, $"LabelBinLid_{binId}", new Point(20, 150));  
                Label lblScheduleMaintenance = GetOrCreateLabel(groupBoxBinStatus, $"LabelScheduleMaintenance_{binId}", new Point(20, 180), Color.Red);
                Label lblError = GetOrCreateLabel(groupBoxBinStatus, $"LabelError_{binId}", new Point(20, 210), Color.Red);
                lblError.Visible = false;
                lblScheduleMaintenance.Text = "Maintenance Required!";
                lblScheduleMaintenance.Visible = false;
            
            // Retrieve or create Schedule Maintenance Button
            Button btnSchedule = groupBoxBinStatus.Controls
                    .OfType<Button>()
                    .FirstOrDefault(b => b.Name == $"ButtonSchedule_{binId}");
             
                if (btnSchedule == null)
                {
                    btnSchedule = new Button
                    {
                        Name = $"ButtonSchedule_{binId}",
                        Text = "Schedule Maintenance",
                        Location = new Point(20, 210),
                        Size = new Size(200, 30),
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Visible = false // Initially hidden
                    };
                    btnSchedule.Click += BtnSchedule_Click;
                    btnSchedule.FlatAppearance.BorderSize = 0;

                    groupBoxBinStatus.Controls.Add(btnSchedule);
                }

                // Fetch bin status data from database using binId
                string query = "SELECT TOP 1 LED_RED, LED_Green, Light, Temperature, Water, Distance FROM Hardware WHERE Bin_Id = @BinId ORDER BY Datetime DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BinId", binId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isOn = (bool)reader["LED_RED"]; // Assuming LED_RED is the status
                        int temperature = (int)reader["Temperature"];
                        int rawWaterLevel = (int)reader["Water"]; // Raw sensor value for water level
                        int rawFillLevel = (int)reader["Distance"]; // Raw distance value for fill level
                        int fillLevel = 100 - ((rawFillLevel * 100) / 400);
                        int waterLevel = 100 - ((rawWaterLevel * 100) / 1023);
                        int lightValue = (int)reader["Light"]; // Light value to determine Bin Lid status

                        // Update label texts with the fetched data
                        lblStatus.Text = $"Status: {(isOn ? "Off" : "On" )}";
                        lblTemperature.Text = $"Temperature: {temperature}°C";
                        lblWaterLevel.Text = $"Water Level: {waterLevel}%";
                        lblFillLevel.Text = $"Fill Level: {fillLevel}%";

                        // Determine Bin Lid status (open/closed) based on the light value threshold
                        string binLidStatus = lightValue < LightThreshold ? "Closed" : "Open"; // Adjust threshold as needed
                        lblBinLid.Text = $"Bin Lid: {binLidStatus}";

                        // Update label colors based on thresholds
                        lblStatus.ForeColor = isOn ?  Color.Red : Color.Green;
                        lblTemperature.ForeColor = temperature < TemperatureThreshold ? Color.Blue : Color.Red;
                        lblWaterLevel.ForeColor = waterLevel < waterThreshold ? Color.Blue : Color.Red;
                        lblFillLevel.ForeColor = fillLevel < FillThresholdHard ? Color.Green : Color.Red;

                        // Determine if maintenance is required based on thresholds
                        bool needsMaintenance = temperature > TemperatureThreshold || waterLevel > waterThreshold || fillLevel > FillThresholdHard;
                        lblScheduleMaintenance.Visible = needsMaintenance;
                    if (needsMaintenance)
                    {
                        dataComms.sendData("RED = ON, GREEN = OFF");
                    }
                    else
                    {
                        dataComms.sendData("RED = OFF, GREEN = ON");
                    }

                        btnSchedule.Visible = needsMaintenance;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Data not found";
                    }
                }
            }

        

        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            string binid = tabControlBins.SelectedTab.Tag.ToString();
            string Message = $"There is an issue with bin {binid}";
            string userid = who();


            MessageUser(binid, userid);
            AddSchedule(binid, userid);
            MessageBox.Show($"User {userid} has been assigned to bin {binid}");
            //Make system a user?
            //Add in Email notifs?            
        }

        private void AddSchedule(string bin, string user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            
            conn.Open();
            string query = $"INSERT INTO Schedule (DateCreated, CreatedBy, ForUser, ActivityExpected, bin) VALUES (@datetime, @admin, @user, @msg, @bin)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@admin", Session.UserId);
            cmd.Parameters.AddWithValue("@msg","Maintainence");
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@bin",bin);
            cmd.ExecuteNonQuery();
        }
        private void MessageUser(string bin, string user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            string message = $"Bin {bin} requires maintenance. Please assist.";
            conn.Open();
            string query = $"INSERT INTO CHAT (datetime, sender, receiver, message) VALUES (@datetime, 0, @user, @message)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@message", message);

            cmd.ExecuteNonQuery();
           

        }

        private string who()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
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


        // Helper method to create or retrieve a label
        private Label GetOrCreateLabel(Control parent, string name, Point location, Color? foreColor = null)
        {
            Label label = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == name);

            if (label == null)
            {
                label = new Label
                {
                    Name = name,
                    Location = location,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = foreColor ?? Color.Black // Default color black
                };
                parent.Controls.Add(label);
            }

            return label;
        }

        private void ErrorMsg()
        {
            if (error == true)
            {
                labelErrorMsg.Visible = true;
                buttonSchedule.Visible = true;
                panelRedLED.BackColor = System.Drawing.Color.Red;
                panelGreenLED.BackColor = System.Drawing.Color.Gray;

                
                //set LED_RED to TRUE, LED_GREEN TO FALSE
            }
            else
            {
                panelRedLED.BackColor = System.Drawing.Color.Gray;
                panelGreenLED.BackColor = System.Drawing.Color.Green;
            }
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

        private void linkLabelBins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Bin bin = new admin.Bin();
            bin.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();
        }
    }

}
