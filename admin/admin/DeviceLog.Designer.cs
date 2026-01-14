namespace admin
{
    partial class DeviceLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabelThresholds = new System.Windows.Forms.LinkLabel();
            this.linkLabelDashboard = new System.Windows.Forms.LinkLabel();
            this.linkLabelSettings = new System.Windows.Forms.LinkLabel();
            this.linkLabelLogs = new System.Windows.Forms.LinkLabel();
            this.linkLabelSchedule = new System.Windows.Forms.LinkLabel();
            this.linkLabelUsers = new System.Windows.Forms.LinkLabel();
            this.linkLabelReport = new System.Windows.Forms.LinkLabel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabelLogOut = new System.Windows.Forms.LinkLabel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelOpenClose = new System.Windows.Forms.Label();
            this.chartRFID = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCarbon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDeviceLog = new System.Windows.Forms.DataGridView();
            this.lblTotalCarbonSaved = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRFID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCarbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.linkLabelThresholds);
            this.panel2.Controls.Add(this.linkLabelDashboard);
            this.panel2.Controls.Add(this.linkLabelSettings);
            this.panel2.Controls.Add(this.linkLabelLogs);
            this.panel2.Controls.Add(this.linkLabelSchedule);
            this.panel2.Controls.Add(this.linkLabelUsers);
            this.panel2.Controls.Add(this.linkLabelReport);
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 985);
            this.panel2.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(22, 329);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 28);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Device Log ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // linkLabelThresholds
            // 
            this.linkLabelThresholds.AutoSize = true;
            this.linkLabelThresholds.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelThresholds.ForeColor = System.Drawing.Color.White;
            this.linkLabelThresholds.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelThresholds.LinkColor = System.Drawing.Color.White;
            this.linkLabelThresholds.Location = new System.Drawing.Point(22, 246);
            this.linkLabelThresholds.Name = "linkLabelThresholds";
            this.linkLabelThresholds.Size = new System.Drawing.Size(106, 28);
            this.linkLabelThresholds.TabIndex = 13;
            this.linkLabelThresholds.TabStop = true;
            this.linkLabelThresholds.Text = "Thresholds";
            this.linkLabelThresholds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelThresholds_LinkClicked);
            // 
            // linkLabelDashboard
            // 
            this.linkLabelDashboard.AutoSize = true;
            this.linkLabelDashboard.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelDashboard.ForeColor = System.Drawing.Color.White;
            this.linkLabelDashboard.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelDashboard.LinkColor = System.Drawing.Color.White;
            this.linkLabelDashboard.Location = new System.Drawing.Point(22, 46);
            this.linkLabelDashboard.Name = "linkLabelDashboard";
            this.linkLabelDashboard.Size = new System.Drawing.Size(108, 28);
            this.linkLabelDashboard.TabIndex = 12;
            this.linkLabelDashboard.TabStop = true;
            this.linkLabelDashboard.Text = "Dashboard";
            this.linkLabelDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDashboard_LinkClicked);
            // 
            // linkLabelSettings
            // 
            this.linkLabelSettings.AutoSize = true;
            this.linkLabelSettings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelSettings.ForeColor = System.Drawing.Color.White;
            this.linkLabelSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelSettings.LinkColor = System.Drawing.Color.White;
            this.linkLabelSettings.Location = new System.Drawing.Point(22, 286);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Size = new System.Drawing.Size(83, 28);
            this.linkLabelSettings.TabIndex = 11;
            this.linkLabelSettings.TabStop = true;
            this.linkLabelSettings.Text = "Settings";
            this.linkLabelSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSettings_LinkClicked_1);
            // 
            // linkLabelLogs
            // 
            this.linkLabelLogs.AutoSize = true;
            this.linkLabelLogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelLogs.ForeColor = System.Drawing.Color.White;
            this.linkLabelLogs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelLogs.LinkColor = System.Drawing.Color.White;
            this.linkLabelLogs.Location = new System.Drawing.Point(22, 206);
            this.linkLabelLogs.Name = "linkLabelLogs";
            this.linkLabelLogs.Size = new System.Drawing.Size(53, 28);
            this.linkLabelLogs.TabIndex = 10;
            this.linkLabelLogs.TabStop = true;
            this.linkLabelLogs.Text = "Logs";
            this.linkLabelLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogs_LinkClicked_1);
            // 
            // linkLabelSchedule
            // 
            this.linkLabelSchedule.AutoSize = true;
            this.linkLabelSchedule.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelSchedule.ForeColor = System.Drawing.Color.White;
            this.linkLabelSchedule.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelSchedule.LinkColor = System.Drawing.Color.White;
            this.linkLabelSchedule.Location = new System.Drawing.Point(22, 166);
            this.linkLabelSchedule.Name = "linkLabelSchedule";
            this.linkLabelSchedule.Size = new System.Drawing.Size(91, 28);
            this.linkLabelSchedule.TabIndex = 9;
            this.linkLabelSchedule.TabStop = true;
            this.linkLabelSchedule.Text = "Schedule";
            this.linkLabelSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSchedule_LinkClicked_1);
            // 
            // linkLabelUsers
            // 
            this.linkLabelUsers.AutoSize = true;
            this.linkLabelUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelUsers.ForeColor = System.Drawing.Color.White;
            this.linkLabelUsers.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelUsers.LinkColor = System.Drawing.Color.White;
            this.linkLabelUsers.Location = new System.Drawing.Point(22, 126);
            this.linkLabelUsers.Name = "linkLabelUsers";
            this.linkLabelUsers.Size = new System.Drawing.Size(59, 28);
            this.linkLabelUsers.TabIndex = 8;
            this.linkLabelUsers.TabStop = true;
            this.linkLabelUsers.Text = "Users";
            this.linkLabelUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUsers_LinkClicked_1);
            // 
            // linkLabelReport
            // 
            this.linkLabelReport.AutoSize = true;
            this.linkLabelReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelReport.ForeColor = System.Drawing.Color.White;
            this.linkLabelReport.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelReport.LinkColor = System.Drawing.Color.White;
            this.linkLabelReport.Location = new System.Drawing.Point(22, 86);
            this.linkLabelReport.Name = "linkLabelReport";
            this.linkLabelReport.Size = new System.Drawing.Size(71, 28);
            this.linkLabelReport.TabIndex = 7;
            this.linkLabelReport.TabStop = true;
            this.linkLabelReport.Text = "Report";
            this.linkLabelReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReport_LinkClicked_1);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(821, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(273, 41);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Admin Dashboard";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.panel3.Controls.Add(this.linkLabelLogOut);
            this.panel3.Controls.Add(this.labelUsername);
            this.panel3.Controls.Add(this.labelTime);
            this.panel3.Controls.Add(this.labelTitle);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2047, 73);
            this.panel3.TabIndex = 3;
            // 
            // linkLabelLogOut
            // 
            this.linkLabelLogOut.AutoSize = true;
            this.linkLabelLogOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.linkLabelLogOut.ForeColor = System.Drawing.Color.Red;
            this.linkLabelLogOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelLogOut.LinkColor = System.Drawing.Color.Red;
            this.linkLabelLogOut.Location = new System.Drawing.Point(1817, 37);
            this.linkLabelLogOut.Name = "linkLabelLogOut";
            this.linkLabelLogOut.Size = new System.Drawing.Size(65, 20);
            this.linkLabelLogOut.TabIndex = 4;
            this.linkLabelLogOut.TabStop = true;
            this.linkLabelLogOut.Text = "Log Out";
            this.linkLabelLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogOut_LinkClicked);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelUsername.Location = new System.Drawing.Point(1348, 37);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(113, 20);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "labelUsername";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTime.Location = new System.Drawing.Point(1610, 37);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(75, 20);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "labelTime";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelOpenClose
            // 
            this.labelOpenClose.Location = new System.Drawing.Point(0, 0);
            this.labelOpenClose.Name = "labelOpenClose";
            this.labelOpenClose.Size = new System.Drawing.Size(100, 23);
            this.labelOpenClose.TabIndex = 0;
            // 
            // chartRFID
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRFID.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRFID.Legends.Add(legend1);
            this.chartRFID.Location = new System.Drawing.Point(270, 96);
            this.chartRFID.Name = "chartRFID";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRFID.Series.Add(series1);
            this.chartRFID.Size = new System.Drawing.Size(529, 300);
            this.chartRFID.TabIndex = 4;
            this.chartRFID.Text = "chart1";
            // 
            // chartCarbon
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCarbon.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCarbon.Legends.Add(legend2);
            this.chartCarbon.Location = new System.Drawing.Point(828, 96);
            this.chartCarbon.Name = "chartCarbon";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCarbon.Series.Add(series2);
            this.chartCarbon.Size = new System.Drawing.Size(508, 300);
            this.chartCarbon.TabIndex = 5;
            this.chartCarbon.Text = "chart1";
            // 
            // dgvDeviceLog
            // 
            this.dgvDeviceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceLog.Location = new System.Drawing.Point(270, 457);
            this.dgvDeviceLog.Name = "dgvDeviceLog";
            this.dgvDeviceLog.RowTemplate.Height = 24;
            this.dgvDeviceLog.Size = new System.Drawing.Size(1053, 198);
            this.dgvDeviceLog.TabIndex = 6;
            // 
            // lblTotalCarbonSaved
            // 
            this.lblTotalCarbonSaved.AutoSize = true;
            this.lblTotalCarbonSaved.Location = new System.Drawing.Point(1432, 107);
            this.lblTotalCarbonSaved.Name = "lblTotalCarbonSaved";
            this.lblTotalCarbonSaved.Size = new System.Drawing.Size(46, 17);
            this.lblTotalCarbonSaved.TabIndex = 7;
            this.lblTotalCarbonSaved.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1435, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeviceLog
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTotalCarbonSaved);
            this.Controls.Add(this.dgvDeviceLog);
            this.Controls.Add(this.chartCarbon);
            this.Controls.Add(this.chartRFID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "DeviceLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.Schedule_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRFID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCarbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label labelTime;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label labelUsername;
    private System.Windows.Forms.LinkLabel linkLabelLogOut;
    private System.Windows.Forms.Label labelOpenClose;
        private System.Windows.Forms.LinkLabel linkLabelThresholds;
        private System.Windows.Forms.LinkLabel linkLabelDashboard;
        private System.Windows.Forms.LinkLabel linkLabelSettings;
        private System.Windows.Forms.LinkLabel linkLabelLogs;
        private System.Windows.Forms.LinkLabel linkLabelSchedule;
        private System.Windows.Forms.LinkLabel linkLabelUsers;
        private System.Windows.Forms.LinkLabel linkLabelReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRFID;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCarbon;
        private System.Windows.Forms.DataGridView dgvDeviceLog;
        private System.Windows.Forms.Label lblTotalCarbonSaved;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
    }
}