using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IEmailsender
    {
        Task SendEmailAsync(string email, string subject, String message);

    }
}
