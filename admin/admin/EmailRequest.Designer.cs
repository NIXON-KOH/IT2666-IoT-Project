namespace admin
{
    partial class EmailRequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 


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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();


            this.SuspendLayout();

            // Form Properties
            this.ClientSize = new System.Drawing.Size(530, 366);
            this.Text = "Forgot Password";
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Label1 (Title)
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(180, 50);
            this.label1.Text = "Forgot Password";

            // TextBox Email
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEmail.Text = "Enter Account Email";
            this.textBoxEmail.Size = new System.Drawing.Size(250, 30);
            this.textBoxEmail.Location = new System.Drawing.Point(140, 120);

            // Submit Button
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSubmit.Size = new System.Drawing.Size(100, 35);
            this.buttonSubmit.Location = new System.Drawing.Point(210, 180);
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);

            // Error Label
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(145, 154);
            this.labelError.Text = "Invalid Email";
            this.labelError.Visible = false;

            // Adding Controls
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelError);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelError;
    }
}