using Microsoft.Extensions.Configuration;
using Rovers4.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Rovers4.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string fixTypeString, string homeOrAwayString, DateTime kickOff, string opponent, string meetLocation, DateTime meetTime);
    }

    public class SendGridMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string fixTypeString, string homeOrAwayString, DateTime kickOff, string opponent, string meetLocation, DateTime meetTime)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("X00152190@mytudublin.ie", "Rathfarnham Rovers");
            sendGridMessage.AddTo(toEmail);
            sendGridMessage.SetSubject(subject);
            sendGridMessage.SetTemplateId("d-6fb1d9954f9e49e2a62f5e67385bbbb9");
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
            await client.SendEmailAsync(sendGridMessage).ConfigureAwait(true);
        }
    }
}
