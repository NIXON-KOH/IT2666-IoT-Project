namespace admin
{
    partial class Chat
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
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelOpenClose = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelWaterLevel = new System.Windows.Forms.Label();
            this.labelFullness = new System.Windows.Forms.Label();
            this.labelOnOff = new System.Windows.Forms.Label();
            this.labelOnOffText = new System.Windows.Forms.Label();
            this.labelBindLidText = new System.Windows.Forms.Label();
            this.labelTemperatureText = new System.Windows.Forms.Label();
            this.labelWaterLevelText = new System.Windows.Forms.Label();
            this.labelFillLevelText = new System.Windows.Forms.Label();
            this.labelErrorMsg = new System.Windows.Forms.Label();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.panelGreenLED = new System.Windows.Forms.Panel();
            this.panelRedLED = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            // linkLabelThresholds
            // 
            this.linkLabelThresholds.AutoSize = true;
            this.linkLabelThresholds.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelThresholds.ForeColor = System.Drawing.Color.White;
            this.linkLabelThresholds.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelThresholds.LinkColor = System.Drawing.Color.White;
            this.linkLabelThresholds.Location = new System.Drawing.Point(20, 250);
            this.linkLabelThresholds.Name = "linkLabelThresholds";
            this.linkLabelThresholds.Size = new System.Drawing.Size(106, 28);
            this.linkLabelThresholds.TabIndex = 6;
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
            this.linkLabelDashboard.Location = new System.Drawing.Point(20, 50);
            this.linkLabelDashboard.Name = "linkLabelDashboard";
            this.linkLabelDashboard.Size = new System.Drawing.Size(108, 28);
            this.linkLabelDashboard.TabIndex = 5;
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
            this.linkLabelSettings.Location = new System.Drawing.Point(20, 290);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Size = new System.Drawing.Size(83, 28);
            this.linkLabelSettings.TabIndex = 4;
            this.linkLabelSettings.TabStop = true;
            this.linkLabelSettings.Text = "Settings";
            this.linkLabelSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSettings_LinkClicked);
            // 
            // linkLabelLogs
            // 
            this.linkLabelLogs.AutoSize = true;
            this.linkLabelLogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelLogs.ForeColor = System.Drawing.Color.White;
            this.linkLabelLogs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelLogs.LinkColor = System.Drawing.Color.White;
            this.linkLabelLogs.Location = new System.Drawing.Point(20, 210);
            this.linkLabelLogs.Name = "linkLabelLogs";
            this.linkLabelLogs.Size = new System.Drawing.Size(53, 28);
            this.linkLabelLogs.TabIndex = 3;
            this.linkLabelLogs.TabStop = true;
            this.linkLabelLogs.Text = "Logs";
            this.linkLabelLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogs_LinkClicked);
            // 
            // linkLabelSchedule
            // 
            this.linkLabelSchedule.AutoSize = true;
            this.linkLabelSchedule.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelSchedule.ForeColor = System.Drawing.Color.White;
            this.linkLabelSchedule.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelSchedule.LinkColor = System.Drawing.Color.White;
            this.linkLabelSchedule.Location = new System.Drawing.Point(20, 170);
            this.linkLabelSchedule.Name = "linkLabelSchedule";
            this.linkLabelSchedule.Size = new System.Drawing.Size(91, 28);
            this.linkLabelSchedule.TabIndex = 2;
            this.linkLabelSchedule.TabStop = true;
            this.linkLabelSchedule.Text = "Schedule";
            this.linkLabelSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSchedule_LinkClicked);
            // 
            // linkLabelUsers
            // 
            this.linkLabelUsers.AutoSize = true;
            this.linkLabelUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelUsers.ForeColor = System.Drawing.Color.White;
            this.linkLabelUsers.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelUsers.LinkColor = System.Drawing.Color.White;
            this.linkLabelUsers.Location = new System.Drawing.Point(20, 130);
            this.linkLabelUsers.Name = "linkLabelUsers";
            this.linkLabelUsers.Size = new System.Drawing.Size(59, 28);
            this.linkLabelUsers.TabIndex = 1;
            this.linkLabelUsers.TabStop = true;
            this.linkLabelUsers.Text = "Users";
            this.linkLabelUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUsers_LinkClicked);
            // 
            // linkLabelReport
            // 
            this.linkLabelReport.AutoSize = true;
            this.linkLabelReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelReport.ForeColor = System.Drawing.Color.White;
            this.linkLabelReport.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelReport.LinkColor = System.Drawing.Color.White;
            this.linkLabelReport.Location = new System.Drawing.Point(20, 90);
            this.linkLabelReport.Name = "linkLabelReport";
            this.linkLabelReport.Size = new System.Drawing.Size(71, 28);
            this.linkLabelReport.TabIndex = 0;
            this.linkLabelReport.TabStop = true;
            this.linkLabelReport.Text = "Report";
            this.linkLabelReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReport_LinkClicked);
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
            this.labelOpenClose.AutoSize = true;
            this.labelOpenClose.Location = new System.Drawing.Point(160, 99);
            this.labelOpenClose.Name = "labelOpenClose";
            this.labelOpenClose.Size = new System.Drawing.Size(70, 19);
            this.labelOpenClose.TabIndex = 0;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(160, 134);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(114, 19);
            this.labelTemperature.TabIndex = 1;
            // 
            // labelWaterLevel
            // 
            this.labelWaterLevel.AutoSize = true;
            this.labelWaterLevel.Location = new System.Drawing.Point(160, 173);
            this.labelWaterLevel.Name = "labelWaterLevel";
            this.labelWaterLevel.Size = new System.Drawing.Size(108, 19);
            this.labelWaterLevel.TabIndex = 2;
            // 
            // labelFullness
            // 
            this.labelFullness.AutoSize = true;
            this.labelFullness.Location = new System.Drawing.Point(160, 206);
            this.labelFullness.Name = "labelFullness";
            this.labelFullness.Size = new System.Drawing.Size(83, 19);
            this.labelFullness.TabIndex = 3;
            // 
            // labelOnOff
            // 
            this.labelOnOff.AutoSize = true;
            this.labelOnOff.Location = new System.Drawing.Point(160, 57);
            this.labelOnOff.Name = "labelOnOff";
            this.labelOnOff.Size = new System.Drawing.Size(66, 19);
            this.labelOnOff.TabIndex = 4;
            // 
            // labelOnOffText
            // 
            this.labelOnOffText.AutoSize = true;
            this.labelOnOffText.Location = new System.Drawing.Point(24, 57);
            this.labelOnOffText.Name = "labelOnOffText";
            this.labelOnOffText.Size = new System.Drawing.Size(66, 19);
            this.labelOnOffText.TabIndex = 5;
            // 
            // labelBindLidText
            // 
            this.labelBindLidText.AutoSize = true;
            this.labelBindLidText.Location = new System.Drawing.Point(24, 99);
            this.labelBindLidText.Name = "labelBindLidText";
            this.labelBindLidText.Size = new System.Drawing.Size(70, 19);
            this.labelBindLidText.TabIndex = 6;
            // 
            // labelTemperatureText
            // 
            this.labelTemperatureText.AutoSize = true;
            this.labelTemperatureText.Location = new System.Drawing.Point(24, 134);
            this.labelTemperatureText.Name = "labelTemperatureText";
            this.labelTemperatureText.Size = new System.Drawing.Size(114, 19);
            this.labelTemperatureText.TabIndex = 7;
            // 
            // labelWaterLevelText
            // 
            this.labelWaterLevelText.AutoSize = true;
            this.labelWaterLevelText.Location = new System.Drawing.Point(24, 173);
            this.labelWaterLevelText.Name = "labelWaterLevelText";
            this.labelWaterLevelText.Size = new System.Drawing.Size(108, 19);
            this.labelWaterLevelText.TabIndex = 8;
            // 
            // labelFillLevelText
            // 
            this.labelFillLevelText.AutoSize = true;
            this.labelFillLevelText.Location = new System.Drawing.Point(24, 206);
            this.labelFillLevelText.Name = "labelFillLevelText";
            this.labelFillLevelText.Size = new System.Drawing.Size(83, 19);
            this.labelFillLevelText.TabIndex = 9;
            // 
            // labelErrorMsg
            // 
            this.labelErrorMsg.AutoSize = true;
            this.labelErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMsg.Location = new System.Drawing.Point(24, 249);
            this.labelErrorMsg.Name = "labelErrorMsg";
            this.labelErrorMsg.Size = new System.Drawing.Size(215, 19);
            this.labelErrorMsg.TabIndex = 10;
            this.labelErrorMsg.Visible = false;
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(352, 239);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(129, 44);
            this.buttonSchedule.TabIndex = 11;
            this.buttonSchedule.Text = "Schedule";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Visible = false;
            // 
            // panelGreenLED
            // 
            this.panelGreenLED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGreenLED.Location = new System.Drawing.Point(259, 99);
            this.panelGreenLED.Name = "panelGreenLED";
            this.panelGreenLED.Size = new System.Drawing.Size(75, 75);
            this.panelGreenLED.TabIndex = 11;
            // 
            // panelRedLED
            // 
            this.panelRedLED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRedLED.Location = new System.Drawing.Point(59, 99);
            this.panelRedLED.Name = "panelRedLED";
            this.panelRedLED.Size = new System.Drawing.Size(75, 75);
            this.panelRedLED.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(344, 138);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 476);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(20, 330);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 28);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Device log";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Chat
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabelSettings;
        private System.Windows.Forms.LinkLabel linkLabelLogs;
        private System.Windows.Forms.LinkLabel linkLabelSchedule;
        private System.Windows.Forms.LinkLabel linkLabelUsers;
        private System.Windows.Forms.LinkLabel linkLabelReport;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabelDashboard;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.LinkLabel linkLabelLogOut;
        private System.Windows.Forms.LinkLabel linkLabelThresholds;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelOpenClose;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelWaterLevel;
        private System.Windows.Forms.Label labelFullness;
        private System.Windows.Forms.Label labelOnOff;
        private System.Windows.Forms.Label labelOnOffText;
        private System.Windows.Forms.Label labelBindLidText;
        private System.Windows.Forms.Label labelTemperatureText;
        private System.Windows.Forms.Label labelWaterLevelText;
        private System.Windows.Forms.Label labelFillLevelText;
        private System.Windows.Forms.Label labelErrorMsg;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Panel panelGreenLED;
        private System.Windows.Forms.Panel panelRedLED;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}