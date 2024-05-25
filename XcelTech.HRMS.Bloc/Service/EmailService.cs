using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmailService :IEmailService
    {
        private readonly IFluentEmail _iFluentEmail;
        public EmailService(IFluentEmail iFluentEmail)
        {
            _iFluentEmail = iFluentEmail;
            //_iFluentEmail = iFluentEmail ?? throw new ArgumentNullException(nameof(iFluentEmail));
        }
        public async Task SendEmail(EmailFormatData emailFormatData)
        {
            await _iFluentEmail.To(emailFormatData.ToAddress)
                .Subject(emailFormatData.Subject)
                //.UsingTemplateFromFile(file,model,true)
                .Body(emailFormatData.Body)
                .SendAsync();
        }
       public async Task sendEmailAsHtmlTemplate(EmailFormatData emaiFormatData,ProfileInfoDto profileInfoDto,string EmailTemplatePath)
        {
            
                await _iFluentEmail.To(emaiFormatData.ToAddress)
                    .Subject(emaiFormatData.Subject)
                    .UsingTemplateFromFile(EmailTemplatePath, profileInfoDto , true)
                    .SendAsync();
            
        }

    }
}
