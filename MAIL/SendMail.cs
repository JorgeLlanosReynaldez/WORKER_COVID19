using MailKit.Security;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MODEL.MODEL;
using Microsoft.Extensions.Configuration;
namespace MAIL
{
    public class SendMail : ISendMail
    {
        private readonly Mail _mail;
        private readonly string _sectionMail = "Mail";
        public SendMail(IConfiguration configuration)
        {
            _mail = new Mail();
            configuration.GetSection(_sectionMail).Bind(_mail);
        } 
        public void SendEmail(string pdfFilePath)
        {
            string toEmail = _mail.toEmail;
            string subject = _mail.subject;
            string body = _mail.body;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mail.subject, _mail.UserMail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };
            if (File.Exists(pdfFilePath))
            {
                bodyBuilder.Attachments.Add(pdfFilePath);
            }
            else
            {
                Console.WriteLine("PDF NOT");
                return;
            }
            message.Body = bodyBuilder.ToMessageBody();
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_mail.smtp);
                    client.Authenticate(_mail.UserMail, _mail.PasswordMail);
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
