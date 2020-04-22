using AllCoreInOne.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Email
{
    public class EmailService: IEmailService
    {
        private EmailSettings _email { get; }
        private IWebHostEnvironment _env { get; }

        public EmailService(IOptions<EmailSettings> email, IWebHostEnvironment env)
        {
            _email = email.Value;
            _env = env;
        }


        public async Task SendAsync(string EmailDisplayName, string Subject, string Body, string From, string To)
        {
            using (var client = new SmtpClient(_email.SMTPServer, _email.Port))
            using (var mailMessage = new MailMessage())
            {
                if (!_email.DefaultCredentials)
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_email.UserName, _email.Password);
                }

                PrepareMailMessage(EmailDisplayName, Subject, Body, From, To, mailMessage);

                await client.SendMailAsync(mailMessage);
            }
        }

        private void PrepareMailMessage(string EmailDisplayName, string Subject, string Body, string From, string To, MailMessage mailMessage)
        {
            mailMessage.From = new MailAddress(From, EmailDisplayName);
            mailMessage.To.Add(To);
            mailMessage.Body = Body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = Subject;
        }
    }
}
