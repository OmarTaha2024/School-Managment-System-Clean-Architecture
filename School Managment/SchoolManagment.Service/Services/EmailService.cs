using MailKit.Net.Smtp;
using MimeKit;
using SchoolManagment.Data.Helpers;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    internal class EmailService : IEmailService
    {

        #region Fields
        private readonly EmailSettings _emailSettings;
        #endregion
        #region Ctor
        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        #endregion
        #region Handle Function

        public async Task<string> SendEmailAsync(string email, string msg, string? reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{msg}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Tahtoh", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "Submitted" : reason; ;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }


        #endregion

    }
}
