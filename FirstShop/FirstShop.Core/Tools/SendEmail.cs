using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FirstShop.Core.Tools
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //    mail.From = new MailAddress("newgenitsolutioncompany@gmail.com", "شرکت نسل جدید آی تی");
            //    mail.To.Add(to);
            //    mail.Subject = subject;
            //    mail.Body = body;
            //    mail.IsBodyHtml = true;

            //    //System.Net.Mail.Attachment attachment;
            //    // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            //    // mail.Attachments.Add(attachment);

            //    SmtpServer.Port = 587;
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("newgenitsolutioncompany@gmail.com", "Hika!2024.");
            //    SmtpServer.EnableSsl = false;

            //    SmtpServer.Send(mail);
            //}
            //catch { }

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to.Trim());
                mail.From = new MailAddress("goldenscorpion3@gmail.com", "حاج محمود");
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("goldenscorpion3@gmail.com", "scorpion_2558");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //Or your Smtp Email ID and Password
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch {}
        }
    }
}
