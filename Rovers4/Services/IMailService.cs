﻿using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }

    public class SendGridMailService: IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("X00152190@mytudublin.ie", "Rathfarnham Rovers");
            var to = new EmailAddress(toEmail);
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
