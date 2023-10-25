using MailAPI.Models;

namespace MailAPI.Services.EmailServices;

public interface IEmailService
{
    void SendEmail(EmailDto emailDto); 
}