using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class alerts
    {
        public enum AlertType
        {
            Success,
            Warning,
            Error,
            Info
        }

        public static void ShowAlert(string message, AlertType type)
        {
            AlertForm alertForm = new AlertForm(message, type);
            alertForm.Show();
        }

        private class AlertForm : Form
        {
            private Label messageLabel;
            private Timer fadeTimer;
            private int fadeStep = 5; // Adjust for fade speed

            public AlertForm()
            {
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.Manual;
                this.ShowInTaskbar = false;
                this.TopMost = true;
                this.Opacity = 1; // Start fully opaque
            }

            public AlertForm(string message, AlertType type) : this()
            {
                messageLabel.Text = message;
                SetAlertType(type);
            }

            private void InitializeComponent()
            {
                this.messageLabel = new Label();
                this.fadeTimer = new Timer();
                this.SuspendLayout();
                //
                // messageLabel
                //
                this.messageLabel.Dock = DockStyle.Fill;
                this.messageLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                this.messageLabel.ForeColor = Color.White;
                this.messageLabel.TextAlign = ContentAlignment.MiddleCenter;
                //
                // fadeTimer
                //
                this.fadeTimer.Interval = 50; // Fade interval (milliseconds)
                this.fadeTimer.Tick += new EventHandler(this.FadeTimer_Tick);
                this.fadeTimer.Enabled = false;
                //
                // AlertForm
                //
                this.AutoScaleDimensions = new SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new Size(300, 100); // Default size, adjust as needed
                this.Controls.Add(this.messageLabel);
                this.Name = "AlertForm";
                this.Padding = new Padding(10);
                this.ResumeLayout(false);
            }


            private void SetAlertType(AlertType type)
            {
                switch (type)
                {
                    case AlertType.Success:
                        this.BackColor = Color.SeaGreen;
                        break;
                    case AlertType.Warning:
                        this.BackColor = Color.Goldenrod;
                        break;
                    case AlertType.Error:
                        this.BackColor = Color.Firebrick;
                        break;
                    case AlertType.Info:
                    default:
                        this.BackColor = Color.RoyalBlue;
                        break;
                }
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                // Position the alert at the bottom right of the screen
                Screen screen = Screen.PrimaryScreen;
                int x = screen.WorkingArea.Width - this.Width - 20; // 20px from right edge
                int y = screen.WorkingArea.Height - this.Height - 20; // 20px from bottom edge
                this.Location = new Point(x, y);

                Task.Delay(3000).ContinueWith(t =>
                {
                    if (!IsDisposed) // Check if the form is already disposed before accessing timer
                    {
                        BeginInvoke(new Action(() =>
                        {
                            fadeTimer.Enabled = true; // Start fading after 3 seconds
                        }));
                    }
                });
            }


            private void FadeTimer_Tick(object sender, EventArgs e)
            {
                this.Opacity -= (double)fadeStep / 100; // Reduce opacity

                if (this.Opacity <= 0)
                {
                    fadeTimer.Enabled = false;
                    this.Close();
                    this.Dispose();
                }
            }
        }
    }
}
