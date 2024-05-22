using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IEmailsender
    {

        public void SendEmail(string toEmail, string subject);


    }
}
