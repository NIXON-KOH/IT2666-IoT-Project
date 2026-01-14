using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.IO;

namespace admin
{
    public partial class DeviceLog : Form
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        public DeviceLog()
        {
            InitializeComponent();
            LoadRFIDChart();
            LoadDeviceLogAndCarbonData();
        }
        private void LoadRFIDChart()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                // Query groups by hour using DATEPART
                string query = @"
                    SELECT DATEPART(HOUR, Datetime) AS ScanHour, COUNT(*) AS ScanCount 
                    FROM Hardware 
                    WHERE RFID IS NOT NULL AND RFID <> ''
                    GROUP BY DATEPART(HOUR, Datetime)
                    ORDER BY ScanHour;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // Configure the chart for RFID scans
            chartRFID.Series.Clear();
            Series series = new Series("RFID Scans")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (DataRow row in dt.Rows)
            {
                int hour = Convert.ToInt32(row["ScanHour"]);
                int count = Convert.ToInt32(row["ScanCount"]);
                series.Points.AddXY(hour, count);
            }
            chartRFID.Series.Add(series);
            chartRFID.ChartAreas[0].AxisX.Title = "Hour of Day";
            chartRFID.ChartAreas[0].AxisY.Title = "Scan Count";
            chartRFID.Titles.Clear();
            chartRFID.Titles.Add("RFID Scans Grouped by Hour");
        }
        private void LoadDeviceLogAndCarbonData()
        {
            DataTable dtDeviceLog = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Datetime, Device, Quantity FROM Device_Log ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtDeviceLog);
                }
            }

            // Bind the Device_Log data to the grid view
            dgvDeviceLog.DataSource = dtDeviceLog;

            // Define multipliers for each device type (values are in metric units)
            Dictionary<string, double> multipliers = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "laptop", 2.0 },
                { "phone", 1.0 },
                { "battery", 0.5 }
            };

            // Calculate carbon footprint saved per record and group them by date.
            Dictionary<DateTime, double> carbonByDate = new Dictionary<DateTime, double>();
            double totalCarbonSaved = 0.0;

            foreach (DataRow row in dtDeviceLog.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["Datetime"]);
                string device = row["Device"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);

                // Get the multiplier; if the device type isn’t found, the multiplier defaults to 0.
                double multiplier = multipliers.ContainsKey(device) ? multipliers[device] : 0.0;
                double carbonSaved = quantity * multiplier;
                totalCarbonSaved += carbonSaved;

                // Group by the date component (local Singapore date)
                DateTime dateKey = dt.Date;
                if (carbonByDate.ContainsKey(dateKey))
                {
                    carbonByDate[dateKey] += carbonSaved;
                }
                else
                {
                    carbonByDate.Add(dateKey, carbonSaved);
                }
            }

            // Display the total carbon footprint saved
            lblTotalCarbonSaved.Text = $"Total Carbon Footprint Saved: {totalCarbonSaved:F2} units";

            // Plot the carbon footprint saved over time in chartCarbon
            chartCarbon.Series.Clear();
            Series seriesCarbon = new Series("Carbon Footprint Saved")
            {
                ChartType = SeriesChartType.Line
            };

            // Order the grouped data by date before adding to the chart
            foreach (var kvp in carbonByDate.OrderBy(k => k.Key))
            {
                // Format the date string (using a standard format)
                seriesCarbon.Points.AddXY(kvp.Key.ToString("yyyy-MM-dd"), kvp.Value);
            }
            chartCarbon.Series.Add(seriesCarbon);
            chartCarbon.ChartAreas[0].AxisX.Title = "Date";
            chartCarbon.ChartAreas[0].AxisY.Title = "Carbon Footprint Saved";
            chartCarbon.Titles.Clear();
            chartCarbon.Titles.Add("Carbon Footprint Saved Over Time");
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




        public void ExportDeviceLogToExcel()
        {


            // Query the Device_Log table
            DataTable dtDeviceLog = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Datetime, Device, Quantity FROM Device_Log ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtDeviceLog);
                    }
                }
            }

            // Define device multipliers (metric units)
            Dictionary<string, double> multipliers = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
                {
                    { "laptop", 2.0 },
                    { "phone", 1.0 },
                    { "battery", 0.5 }
                };

            // Set the path where the Excel file will be saved (e.g., Desktop)
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DeviceLog.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create the Excel package and worksheet using EPPlus
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("DeviceLog");

                // Write header row
                worksheet.Cells[1, 1].Value = "Datetime";
                worksheet.Cells[1, 2].Value = "Device";
                worksheet.Cells[1, 3].Value = "Quantity";
                worksheet.Cells[1, 4].Value = "Carbon Footprint Saved";

                // Write data rows with carbon footprint calculation
                int row = 2;
                foreach (DataRow dr in dtDeviceLog.Rows)
                {
                    DateTime dt = Convert.ToDateTime(dr["Datetime"]);
                    string device = dr["Device"].ToString();
                    int quantity = Convert.ToInt32(dr["Quantity"]);

                    // Calculate carbon footprint saved; default multiplier is 0 if the device type is unrecognized.
                    double multiplier = multipliers.ContainsKey(device) ? multipliers[device] : 0.0;
                    double carbonSaved = quantity * multiplier;

                    worksheet.Cells[row, 1].Value = dt;
                    worksheet.Cells[row, 2].Value = device;
                    worksheet.Cells[row, 3].Value = quantity;
                    worksheet.Cells[row, 4].Value = carbonSaved;

                    row++;
                }

                // Auto-fit columns for readability
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save the Excel file to disk
                FileInfo fileInfo = new FileInfo(filePath);
                excelPackage.SaveAs(fileInfo);
            }

            // Open the Excel file using the default associated application (e.g., Microsoft Excel)
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportDeviceLogToExcel();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
