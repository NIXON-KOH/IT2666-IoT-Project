namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DailyStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.DailyStats)).BeginInit();
            this.SuspendLayout();
            // 
            // DailyStats
            // 
            this.DailyStats.AllowDrop = true;
            this.DailyStats.BorderlineColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "ChartArea1";
            this.DailyStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DailyStats.Legends.Add(legend1);
            this.DailyStats.Location = new System.Drawing.Point(53, 190);
            this.DailyStats.Name = "DailyStats";
            this.DailyStats.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.DailyStats.Series.Add(series1);
            this.DailyStats.Size = new System.Drawing.Size(523, 303);
            this.DailyStats.TabIndex = 1;
            this.DailyStats.Text = "chart1";
            this.DailyStats.Click += new System.EventHandler(this.DailyStats_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 566);
            this.Controls.Add(this.DailyStats);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Controls.SetChildIndex(this.DailyStats, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DailyStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart DailyStats;
    }
}