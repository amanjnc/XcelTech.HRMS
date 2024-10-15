using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Helper
{
    public class EmailBody
    {
        public static string GetEmailBody(string password)
        {
            string EmailBody = "Subject: Test Email \n \n"
                + " Dear [Recipient's Name], \n"
                + " I hope this email finds you well. \n \n"
                + " Login using this password: " + password + "\n\n"
                + " have a nice day. \n \n"
                + " Best regards, \n"
                + " amanuel beyene \n"
                + " Xceltech solutions \n"
                + " bole, addis ababa \n";
            return EmailBody;
        }
    }
}