using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;


namespace admin
{
    class EmailService
    {
        

        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, 
                    Credentials = new NetworkCredential("garethlin44@gmail.com", "ncqo unwu gvmp vpll"),
                    EnableSsl = true
                };


                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("garethlin44@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to false if sending plain text
                };

                mailMessage.To.Add(toEmail); 
                
                smtpClient.Send(mailMessage);

               
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
