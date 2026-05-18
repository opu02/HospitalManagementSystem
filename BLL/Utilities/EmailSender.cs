using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


namespace BLL.Utilities
{
    public class EmailSender : IEmailSender
    {
        private readonly string _gmailAddress = "jahidurrahmanopu3527@gmail.com";
        private readonly string _gmailAppPassword = "mcvxegvxfjukuelv";

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Hospital Management System", _gmailAddress));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_gmailAddress, _gmailAppPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
