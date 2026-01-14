namespace admin
{
    partial class UsersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelBins = new System.Windows.Forms.LinkLabel();
            this.ChatLinkLabel = new System.Windows.Forms.LinkLabel();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelUsers = new System.Windows.Forms.Label();
            this.labelFilterBy = new System.Windows.Forms.Label();
            this.labelFilterID = new System.Windows.Forms.Label();
            this.labelFilterUsername = new System.Windows.Forms.Label();
            this.labelFilterRole = new System.Windows.Forms.Label();
            this.labelFilterRFID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.textBoxRFID = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdateDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelAddUser = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.linkLabelBins);
            this.panel2.Controls.Add(this.ChatLinkLabel);
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
            this.linkLabelBins.Location = new System.Drawing.Point(24, 287);
            this.linkLabelBins.Name = "linkLabelBins";
            this.linkLabelBins.Size = new System.Drawing.Size(47, 28);
            this.linkLabelBins.TabIndex = 10;
            this.linkLabelBins.TabStop = true;
            this.linkLabelBins.Text = "Bins";
            this.linkLabelBins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBins_LinkClicked);
            // 
            // ChatLinkLabel
            // 
            this.ChatLinkLabel.AutoSize = true;
            this.ChatLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ChatLinkLabel.ForeColor = System.Drawing.Color.White;
            this.ChatLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ChatLinkLabel.LinkColor = System.Drawing.Color.White;
            this.ChatLinkLabel.Location = new System.Drawing.Point(24, 325);
            this.ChatLinkLabel.Name = "ChatLinkLabel";
            this.ChatLinkLabel.Size = new System.Drawing.Size(52, 28);
            this.ChatLinkLabel.TabIndex = 9;
            this.ChatLinkLabel.TabStop = true;
            this.ChatLinkLabel.Text = "Chat";
            this.ChatLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChatLinkLabel_LinkClicked);
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
            this.linkLabelSettings.Location = new System.Drawing.Point(24, 367);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(775, 241);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(487, 413);
            this.dataGridView1.TabIndex = 4;
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsers.Location = new System.Drawing.Point(467, 148);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(107, 46);
            this.labelUsers.TabIndex = 5;
            this.labelUsers.Text = "Users";
            // 
            // labelFilterBy
            // 
            this.labelFilterBy.AutoSize = true;
            this.labelFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelFilterBy.ForeColor = System.Drawing.Color.Gray;
            this.labelFilterBy.Location = new System.Drawing.Point(470, 241);
            this.labelFilterBy.Name = "labelFilterBy";
            this.labelFilterBy.Size = new System.Drawing.Size(82, 28);
            this.labelFilterBy.TabIndex = 6;
            this.labelFilterBy.Text = "Filter By";
            // 
            // labelFilterID
            // 
            this.labelFilterID.AutoSize = true;
            this.labelFilterID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFilterID.Location = new System.Drawing.Point(471, 278);
            this.labelFilterID.Name = "labelFilterID";
            this.labelFilterID.Size = new System.Drawing.Size(70, 23);
            this.labelFilterID.TabIndex = 7;
            this.labelFilterID.Text = "User ID:";
            // 
            // labelFilterUsername
            // 
            this.labelFilterUsername.AutoSize = true;
            this.labelFilterUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFilterUsername.Location = new System.Drawing.Point(471, 320);
            this.labelFilterUsername.Name = "labelFilterUsername";
            this.labelFilterUsername.Size = new System.Drawing.Size(91, 23);
            this.labelFilterUsername.TabIndex = 8;
            this.labelFilterUsername.Text = "Username:";
            // 
            // labelFilterRole
            // 
            this.labelFilterRole.AutoSize = true;
            this.labelFilterRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFilterRole.Location = new System.Drawing.Point(472, 399);
            this.labelFilterRole.Name = "labelFilterRole";
            this.labelFilterRole.Size = new System.Drawing.Size(47, 23);
            this.labelFilterRole.TabIndex = 9;
            this.labelFilterRole.Text = "Role:";
            // 
            // labelFilterRFID
            // 
            this.labelFilterRFID.AutoSize = true;
            this.labelFilterRFID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFilterRFID.Location = new System.Drawing.Point(473, 441);
            this.labelFilterRFID.Name = "labelFilterRFID";
            this.labelFilterRFID.Size = new System.Drawing.Size(49, 23);
            this.labelFilterRFID.TabIndex = 10;
            this.labelFilterRFID.Text = "RFID:";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxUserID.Location = new System.Drawing.Point(547, 275);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(166, 30);
            this.textBoxUserID.TabIndex = 12;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxUsername.Location = new System.Drawing.Point(547, 320);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(166, 30);
            this.textBoxUsername.TabIndex = 13;
            // 
            // textBoxRole
            // 
            this.textBoxRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxRole.Location = new System.Drawing.Point(548, 399);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.Size = new System.Drawing.Size(166, 30);
            this.textBoxRole.TabIndex = 14;
            // 
            // textBoxRFID
            // 
            this.textBoxRFID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxRFID.Location = new System.Drawing.Point(547, 441);
            this.textBoxRFID.Name = "textBoxRFID";
            this.textBoxRFID.Size = new System.Drawing.Size(166, 30);
            this.textBoxRFID.TabIndex = 15;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(639, 502);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 38);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(474, 502);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(77, 38);
            this.buttonSearch.TabIndex = 11;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonUpdateDelete
            // 
            this.buttonUpdateDelete.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonUpdateDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUpdateDelete.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateDelete.Location = new System.Drawing.Point(474, 598);
            this.buttonUpdateDelete.Name = "buttonUpdateDelete";
            this.buttonUpdateDelete.Size = new System.Drawing.Size(146, 44);
            this.buttonUpdateDelete.TabIndex = 17;
            this.buttonUpdateDelete.Text = "Update/Delete";
            this.buttonUpdateDelete.UseVisualStyleBackColor = true;
            this.buttonUpdateDelete.Click += new System.EventHandler(this.buttonUpdateDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(470, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Update/Delete";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(1268, 242);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(94, 41);
            this.buttonRefresh.TabIndex = 19;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelAddUser
            // 
            this.labelAddUser.AutoSize = true;
            this.labelAddUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelAddUser.ForeColor = System.Drawing.Color.Gray;
            this.labelAddUser.Location = new System.Drawing.Point(470, 645);
            this.labelAddUser.Name = "labelAddUser";
            this.labelAddUser.Size = new System.Drawing.Size(93, 28);
            this.labelAddUser.TabIndex = 20;
            this.labelAddUser.Text = "Add User";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAddUser.ForeColor = System.Drawing.Color.White;
            this.buttonAddUser.Location = new System.Drawing.Point(474, 682);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(108, 37);
            this.buttonAddUser.TabIndex = 21;
            this.buttonAddUser.Text = "Add User";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEmail.Location = new System.Drawing.Point(472, 361);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(55, 23);
            this.labelEmail.TabIndex = 22;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxEmail.Location = new System.Drawing.Point(548, 361);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(166, 30);
            this.textBoxEmail.TabIndex = 23;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(28, 413);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 28);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Device Log";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UsersForm
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.labelAddUser);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdateDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxRFID);
            this.Controls.Add(this.textBoxRole);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelFilterRFID);
            this.Controls.Add(this.labelFilterRole);
            this.Controls.Add(this.labelFilterUsername);
            this.Controls.Add(this.labelFilterID);
            this.Controls.Add(this.labelFilterBy);
            this.Controls.Add(this.labelUsers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Label labelFilterBy;
        private System.Windows.Forms.Label labelFilterID;
        private System.Windows.Forms.Label labelFilterUsername;
        private System.Windows.Forms.Label labelFilterRole;
        private System.Windows.Forms.Label labelFilterRFID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.TextBox textBoxRFID;
        private System.Windows.Forms.Button buttonClear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonUpdateDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelAddUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.LinkLabel linkLabelBins;
        private System.Windows.Forms.LinkLabel ChatLinkLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}