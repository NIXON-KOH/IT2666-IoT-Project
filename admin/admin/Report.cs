using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;


namespace admin
{
    public partial class Report: Form
    {
        private DataGridView dataGridView1;
        private ToolTip reportTooltip = new ToolTip();
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        private Form previewForm;
        private PictureBox previewPictureBox;

        public Report()
        {
            InitializeComponent();
            LoadLightSensorData();
           
            Create();
        }
        private void Create()
        {
            dataGridView1 = new DataGridView
            {
                Size = new Size(800,300),
                Location = new Point(300, 500),
                AutoGenerateColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            // Add event handlers
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.RowLeave += DataGridView1_RowLeave;
            dataGridView1.MouseLeave += DataGridView1_MouseLeave;
            InitializeImagePreview();
            // Add the DataGridView to the form
            this.Controls.Add(dataGridView1);

            // Load data into the grid
            LoadReports();

        }
        
        private void LoadReports()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ReportID, User_Id, SubmittedAt, ReportText, ImagePath, Active FROM Reports WHERE Active = 1";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear any existing bindings and columns to avoid duplicates
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();

                    dataGridView1.DataSource = dt;

                    // Hide columns not needed in the grid

                    if (dataGridView1.Columns.Contains("ImagePath"))
                        dataGridView1.Columns["ImagePath"].Visible = false;
                    if (dataGridView1.Columns.Contains("Active"))
                        dataGridView1.Columns["Active"].Visible = false;

                    // Add the Resolve button column
                    DataGridViewButtonColumn resolveButton = new DataGridViewButtonColumn
                    {
                        Name = "ResolveButton",
                        Text = "Resolve",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(resolveButton);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reports: " + ex.Message);
                }
            }
        }

        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure valid cell is hovered
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string reportText = row.Cells["ReportText"].Value?.ToString();
                string imagePath = row.Cells["ImagePath"].Value?.ToString();
                string reportId = row.Cells["ReportID"].Value?.ToString();

                // Set tooltip text with report details
                string tooltipText = $"Report ID: {reportId}\n{reportText}";
                reportTooltip.SetToolTip(dataGridView1, tooltipText);

                // If an image exists, load and show it; otherwise hide the preview form
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        // Dispose of the previous image if any to avoid memory leaks
                        if (previewPictureBox.Image != null)
                        {
                            previewPictureBox.Image.Dispose();
                        }

                        Image img = Image.FromFile(imagePath);
                        previewPictureBox.Image = img;

                        // Position the preview form near the cursor with an offset of 20 pixels
                        previewForm.Location = new Point(Control.MousePosition.X + 10, Control.MousePosition.Y + 10);
                        previewForm.Show();
                    }
                    catch
                    {
                        previewForm.Hide();
                    }
                }
                else
                {
                    previewForm.Hide();
                }
            }
        }
        private void InitializeImagePreview()
        {
            previewForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                Size = new Size(300, 300),
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                TopMost = true
            };

            previewPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            previewForm.Controls.Add(previewPictureBox);
            previewForm.Hide();
        }
        private void ShowImagePreview(Image img)
        {
            Form preview = new Form
            {
                StartPosition = FormStartPosition.Manual,
               Location = new Point(300,300),
                Size = new Size(300, 300),
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = img,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            preview.Controls.Add(pictureBox);
            preview.Show();
        }

        private void DataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Hide the preview when leaving the row
            previewForm.Hide();
        }

        private void DataGridView1_MouseLeave(object sender, EventArgs e)
        {
            // Hide the preview when the mouse leaves the grid entirely
            previewForm.Hide();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the Resolve button column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ResolveButton" && e.RowIndex >= 0)
            {
                int reportId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ReportID"].Value);
                ResolveReport(reportId);
                LoadReports(); // Refresh the grid after resolving
            }
        }

        private void ResolveReport(int reportId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Reports SET Active = 0 WHERE ReportID = @ReportID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", reportId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Report resolved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error resolving report: " + ex.Message);
                }
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database2DataSet.Reports' table. You can move, or remove it, as needed.
            timer1.Interval = 1000;
            timer1.Start();
            labelUsername.Text = $"Welcome, {Session.Username}!";
            
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

        private void LoadLightSensorData()
        {
            // SQL query to aggregate light sensor readings by hour
            string query = @"
        SELECT DATEPART(HOUR, Datetime) AS [Hour], AVG(Light) AS AvgLight
        FROM Hardware
        GROUP BY DATEPART(HOUR, Datetime)
        ORDER BY [Hour];";

            DataTable dt = new DataTable();

            // Retrieve data from the database
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }

            // Clear existing series and titles
            chartLightSensor.Series.Clear();
            chartLightSensor.Titles.Clear();

            // Create and configure the series for the chart
            Series series = new Series("Open")
            {
                ChartType = SeriesChartType.Column, // Use Column chart to highlight peak hours
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Double,
                Color = Color.CornflowerBlue // Default series color
            };

            // Create a Title with custom font and color, then add it to the chart
            Title chartTitle = new Title("Light Sensor Insights - Bin Usage Peak Hours")
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            chartLightSensor.Titles.Add(chartTitle);

            // Populate the series with data from the DataTable
            foreach (DataRow row in dt.Rows)
            {
                int hour = Convert.ToInt32(row["Hour"]);
                double avgLight = Convert.ToDouble(row["AvgLight"]);
                series.Points.AddXY(hour, avgLight);
            }
            
            // Change the color for points where the average light value is below 400
            foreach (DataPoint pt in series.Points)
            {
                // Assuming that the average light value is stored in the first YValue of each point
                if (pt.YValues[0] < 400)
                {
                    pt.Color = Color.OrangeRed;
                }
            }


            // Add the series to the chart
            chartLightSensor.Series.Add(series);

            // Configure ChartArea aesthetics
            if (chartLightSensor.ChartAreas.Count > 0)
            {
                ChartArea area = chartLightSensor.ChartAreas[0];
                // Set background and border styling
                area.BackColor = Color.WhiteSmoke;
                area.BorderColor = Color.LightGray;
                area.BorderWidth = 1;

                // Set gridline colors
                area.AxisX.MajorGrid.LineColor = Color.LightGray;
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                // Adjust inner plot margins: left, top, width, height as percentage values
                area.InnerPlotPosition = new ElementPosition(10, 5, 90, 60);

                // Configure axis titles and label styles
                area.AxisX.Title = "Hour of Day";
                area.AxisY.Title = "Average Light Reading";
                area.AxisX.TitleFont = new Font("Segoe UI", 9, FontStyle.Regular);
                area.AxisY.TitleFont = new Font("Segoe UI", 8, FontStyle.Regular);
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
                area.AxisX.LabelStyle.ForeColor = Color.DimGray;
                area.AxisY.LabelStyle.ForeColor = Color.DimGray;
                area.AxisX.Interval = 1;
            }

            // Enable anti-aliasing for smoother rendering
            chartLightSensor.AntiAliasing = AntiAliasingStyles.All;

           
            Legend legend = chartLightSensor.Legends[0];
            legend.CustomItems.Clear();

            LegendItem closedItem = new LegendItem
            {
                Color = Color.OrangeRed,
                Name = "Closed"
            };
            
            legend.CustomItems.Add(closedItem);
        }
      

        private void linkLabelDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new admin.MainForm();
            mainForm.Show();
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

        private void linkLabelThresholds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Threshold th = new admin.Threshold();
            th.Show();
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

        private void linkLabelUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsersForm uf = new admin.UsersForm();
            uf.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            DeviceLog dl = new admin.DeviceLog();
            dl.Show();

        }
    }
}
