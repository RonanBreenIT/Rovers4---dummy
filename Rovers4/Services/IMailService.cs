using Microsoft.Extensions.Configuration;
using Rovers4.Models;
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
        Task SendEmailAsync(string toEmail, string subject, string fixTypeString, string homeOrAwayString, DateTime kickOff, string opponent, string meetLocation, DateTime meetTime);
    }

    public class SendGridMailService: IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string fixTypeString, string homeOrAwayString, DateTime kickOff, string opponent, string meetLocation, DateTime meetTime)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            //var sendGridClient = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("X00152190@mytudublin.ie", "Rathfarnham Rovers");
            sendGridMessage.AddTo(toEmail);
            sendGridMessage.SetSubject(subject);
            sendGridMessage.SetTemplateId("d-c7983fd7c01943a9be80c381c77db308");
            sendGridMessage.SetTemplateData(new EmailModel
            {
                Subject = subject,
                FixTypeString = fixTypeString,
                HomeOrAwayString = homeOrAwayString,
                KickOffTime = kickOff,
                Opponent = opponent,
                MeetLocation = meetLocation,
                MeetTime = meetTime

            });
            var response = await client.SendEmailAsync(sendGridMessage);
        }
    }
}
