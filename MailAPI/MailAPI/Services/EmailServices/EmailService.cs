using MailAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MailAPI.Services.EmailServices;

public class EmailService:IEmailService
{
    private readonly EmailSettings emailSettings;
    
    public EmailService(IOptions<EmailSettings> options)
    {
        this.emailSettings = options.Value;
    }
    public void SendEmail(EmailDto emailDto)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailSettings.Email));
        email.To.Add(MailboxAddress.Parse(emailDto.To));
        email.Subject = emailDto.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = emailDto.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        smtp.Connect(emailSettings.Host,emailSettings.Port,SecureSocketOptions.StartTls);
        smtp.Authenticate(emailSettings.UserName,emailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);

    }
}