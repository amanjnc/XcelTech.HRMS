//using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmailSender : IEmailsender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var myEmail = "amanuelbeyene662@gmail.com";
            var password = "Portal_0";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(myEmail, password)
            };

            return client.SendMailAsync(new MailMessage(from: myEmail, to: email, subject, message));
        }

       
    }
}