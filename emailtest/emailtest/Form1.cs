using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//vvv THIS IS NEEDED vvv
using System.Net.Mail;
///^^^ THIS IS NEEDED ^^^
using System.Windows.Forms;

namespace emailtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    //email details
                    //who is sending the email
                    mail.From = new MailAddress("username@gmail.com");
                    //who the email is being sent to
                    mail.To.Add("target@address.com");
                    //the email subject
                    mail.Subject = "test email is working";
                    //email content
                    mail.Body = "<h1>This is body</h1>";
                    mail.IsBodyHtml = true;

                    //adds attachment to email
                    System.Net.Mail.Attachment attachment;
                    //path to attachment
                    attachment = new System.Net.Mail.Attachment("path/to/file");
                    mail.Attachments.Add(attachment);

                    //connects to google smtp servers
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        //user details        
                        //when using google smtp servers you'll have to turn "less secure app access" in security settings
                        smtp.Credentials = new System.Net.NetworkCredential("username@gmail.com", "password");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        //changes label text
                        label1.Text = "mail sent";

                    }

                }

            }
            catch(Exception ex)
            {
                label1.Text = ex.Message;
            }

        }
    }
}
