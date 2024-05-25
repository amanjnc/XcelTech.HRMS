//using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmailSender : IEmailsender
    {
        public void SendEmail(string toEmail, string subject)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("amanuelbeyene662@gmail.com", "yuogkjxtlgxtjigh");

            Console.WriteLine(toEmail);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("amanuelbeyene662@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = mailBody.ToString();
            Console.WriteLine("last");
            client.Send(mailMessage);
            Console.WriteLine("afterlast");


        }


    }
}