using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using YouTennis.Base.Model.Helpers;
using YouTennis.Base.Service;

namespace YouTennis.Core.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _config;
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _fromMailAddress;

        public EmailService(EmailConfig config)
        {
            _config = config;
            var credentials = new NetworkCredential(_config.Login, _config.Password);

            _smtpClient = new SmtpClient
            {
                Host = _config.Server,
                Credentials = credentials
            };
            if (_config.Port != default) _smtpClient.Port = _config.Port;

            _fromMailAddress = new MailAddress(_config.FromAddress, _config.FromDisplayName);
        }
        public async Task SendEmailAsync(string to, string topic, string message, bool isBodyHtml = true)
        {
            var reciever = new MailAddress(to);

            var mailMessage = new MailMessage(_fromMailAddress, reciever)
            {
                Subject = topic,
                Body = message,
                IsBodyHtml = isBodyHtml
            };

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
