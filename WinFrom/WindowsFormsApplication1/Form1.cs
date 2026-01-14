using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApplication1 // Replace 'WindowsFormsApplication1' with your actual namespace
{
    public partial class Form1 : Form // Removed CustomForm inheritance for simplicity, adjust if needed
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false; // Ensure label4 is initially hidden
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // You can add any specific logic for username text change here if needed
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // You can add any specific logic for label1 click here if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            LoginHandler loginHandler = new LoginHandler(); // Instantiate LoginHandler
            LoginHandler.LoginResult loginResult = loginHandler.Login(username, password); // Call the Login method

            if (loginResult.IsSuccess)
            {
                alerts.ShowAlert("thou hath loggeth in", alerts.AlertType.Success);

                Session.UserID = loginResult.UserId.ToString(); // Assuming Session.UserID is meant to store UserId as string

                Form2 mainForm = new Form2();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Login Failed
                label4.Text = loginResult.ErrorMessage; // Display error message from LoginResult
                label4.ForeColor = Color.Red;
                label4.Visible = true;
                alerts.ShowAlert("why u hack how dare u", alerts.AlertType.Warning);
            }


            Console.WriteLine(username);
            Console.WriteLine(password);
            Console.WriteLine(loginResult.IsSuccess); // Output the login result to console
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // You can add any specific logic for label3 click here if needed
        }
    }
}