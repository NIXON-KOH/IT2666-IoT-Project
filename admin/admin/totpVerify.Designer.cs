namespace admin
{
    partial class totpVerify
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTOTPCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInvalid = new System.Windows.Forms.Label();
            this.buttontotpVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(203, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTP Verification";
            // 
            // textBoxTOTPCode
            // 
            this.textBoxTOTPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxTOTPCode.Location = new System.Drawing.Point(172, 153);
            this.textBoxTOTPCode.MaxLength = 6;
            this.textBoxTOTPCode.Name = "textBoxTOTPCode";
            this.textBoxTOTPCode.Size = new System.Drawing.Size(257, 26);
            this.textBoxTOTPCode.TabIndex = 1;
            this.textBoxTOTPCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(190, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please Enter TOTP Code From App";
            // 
            // labelInvalid
            // 
            this.labelInvalid.AutoSize = true;
            this.labelInvalid.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelInvalid.ForeColor = System.Drawing.Color.Red;
            this.labelInvalid.Location = new System.Drawing.Point(252, 244);
            this.labelInvalid.Name = "labelInvalid";
            this.labelInvalid.Size = new System.Drawing.Size(99, 16);
            this.labelInvalid.TabIndex = 3;
            this.labelInvalid.Text = "Invalid TOTP!";
            this.labelInvalid.Visible = false;
            // 
            // buttontotpVerify
            // 
            this.buttontotpVerify.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttontotpVerify.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.buttontotpVerify.ForeColor = System.Drawing.Color.White;
            this.buttontotpVerify.Location = new System.Drawing.Point(172, 189);
            this.buttontotpVerify.Name = "buttontotpVerify";
            this.buttontotpVerify.Size = new System.Drawing.Size(257, 35);
            this.buttontotpVerify.TabIndex = 4;
            this.buttontotpVerify.Text = "Submit";
            this.buttontotpVerify.UseVisualStyleBackColor = false;
            this.buttontotpVerify.Click += new System.EventHandler(this.buttontotpVerify_Click);
            // 
            // totpVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 372);
            this.Controls.Add(this.buttontotpVerify);
            this.Controls.Add(this.labelInvalid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTOTPCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "totpVerify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOTP Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTOTPCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInvalid;
        private System.Windows.Forms.Button buttontotpVerify;
    }
}