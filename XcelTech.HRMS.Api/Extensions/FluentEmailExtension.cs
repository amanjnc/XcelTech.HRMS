﻿namespace XcelTech.HRMS.Api.Extensions
{
    public static class FluentEmailExtension
    {
        public static void AddFluentEmail(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");
            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["SMTPSetting:Host"];
            var port = emailSettings.GetValue<int>("Port");
            var userName = emailSettings["UserName"];
            var password = emailSettings["Password"];
            services.AddFluentEmail(defaultFromEmail)
            .AddSmtpSender(host, port, userName, password)
            .AddRazorRenderer();

        }
    }
}
