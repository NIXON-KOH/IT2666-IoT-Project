namespace admin
{
    partial class SettingsForm
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
            this.linkLabelBins = new System.Windows.Forms.LinkLabel();
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
            this.labelSettings = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelSettingsUsername = new System.Windows.Forms.Label();
            this.textBoxSettingsUsername = new System.Windows.Forms.TextBox();
            this.buttonSettingsSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEnableTOTP = new System.Windows.Forms.Button();
            this.pictureBoxQrCode = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.linkLabelBins);
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
            // linkLabelBins
            // 
            this.linkLabelBins.AutoSize = true;
            this.linkLabelBins.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelBins.ForeColor = System.Drawing.Color.White;
            this.linkLabelBins.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelBins.LinkColor = System.Drawing.Color.White;
            this.linkLabelBins.Location = new System.Drawing.Point(21, 290);
            this.linkLabelBins.Name = "linkLabelBins";
            this.linkLabelBins.Size = new System.Drawing.Size(47, 28);
            this.linkLabelBins.TabIndex = 8;
            this.linkLabelBins.TabStop = true;
            this.linkLabelBins.Text = "Bins";
            this.linkLabelBins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBins_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(21, 324);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(52, 28);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Chat";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
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
            this.linkLabelSettings.Location = new System.Drawing.Point(21, 357);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Size = new System.Drawing.Size(83, 28);
            this.linkLabelSettings.TabIndex = 4;
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
            this.linkLabelSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSchedule_LinkClicked_1);
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
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelSettings.Location = new System.Drawing.Point(467, 148);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(150, 46);
            this.labelSettings.TabIndex = 5;
            this.labelSettings.Text = "Settings";
            // 
            // labelSettingsUsername
            // 
            this.labelSettingsUsername.AutoSize = true;
            this.labelSettingsUsername.Location = new System.Drawing.Point(472, 255);
            this.labelSettingsUsername.Name = "labelSettingsUsername";
            this.labelSettingsUsername.Size = new System.Drawing.Size(81, 17);
            this.labelSettingsUsername.TabIndex = 6;
            this.labelSettingsUsername.Text = "Username: ";
            // 
            // textBoxSettingsUsername
            // 
            this.textBoxSettingsUsername.Location = new System.Drawing.Point(591, 252);
            this.textBoxSettingsUsername.Name = "textBoxSettingsUsername";
            this.textBoxSettingsUsername.Size = new System.Drawing.Size(421, 22);
            this.textBoxSettingsUsername.TabIndex = 7;
            // 
            // buttonSettingsSave
            // 
            this.buttonSettingsSave.Location = new System.Drawing.Point(476, 302);
            this.buttonSettingsSave.Name = "buttonSettingsSave";
            this.buttonSettingsSave.Size = new System.Drawing.Size(75, 40);
            this.buttonSettingsSave.TabIndex = 10;
            this.buttonSettingsSave.Text = "Save";
            this.buttonSettingsSave.UseVisualStyleBackColor = true;
            this.buttonSettingsSave.Click += new System.EventHandler(this.buttonSettingsSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(467, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 46);
            this.label1.TabIndex = 11;
            this.label1.Text = "Multi Factor Authentication";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enable TOTP";
            // 
            // buttonEnableTOTP
            // 
            this.buttonEnableTOTP.Location = new System.Drawing.Point(474, 572);
            this.buttonEnableTOTP.Name = "buttonEnableTOTP";
            this.buttonEnableTOTP.Size = new System.Drawing.Size(75, 40);
            this.buttonEnableTOTP.TabIndex = 13;
            this.buttonEnableTOTP.Text = "Enable TOTP";
            this.buttonEnableTOTP.UseVisualStyleBackColor = true;
            this.buttonEnableTOTP.Click += new System.EventHandler(this.buttonEnableTOTP_Click);
            // 
            // pictureBoxQrCode
            // 
            this.pictureBoxQrCode.Location = new System.Drawing.Point(667, 547);
            this.pictureBoxQrCode.Name = "pictureBoxQrCode";
            this.pictureBoxQrCode.Size = new System.Drawing.Size(330, 229);
            this.pictureBoxQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQrCode.TabIndex = 14;
            this.pictureBoxQrCode.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel2.ForeColor = System.Drawing.Color.White;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(28, 403);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(108, 28);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Device Log";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pictureBoxQrCode);
            this.Controls.Add(this.buttonEnableTOTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSettingsSave);
            this.Controls.Add(this.textBoxSettingsUsername);
            this.Controls.Add(this.labelSettingsUsername);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label labelSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelSettingsUsername;
        private System.Windows.Forms.TextBox textBoxSettingsUsername;
        private System.Windows.Forms.Button buttonSettingsSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEnableTOTP;
        private System.Windows.Forms.PictureBox pictureBoxQrCode;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabelBins;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}