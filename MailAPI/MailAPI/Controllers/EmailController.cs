using MailAPI.Models;
using MailAPI.Services.EmailServices;
using Microsoft.AspNetCore.Mvc;

namespace MailAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class EmailController : ControllerBase
{
   private readonly IEmailService _emailService;

   public EmailController(IEmailService emailService)
   {
      _emailService = emailService;
   }
   
   [HttpPost]
   public IActionResult SendEmail(EmailDto emailDto)
   {
      _emailService.SendEmail(emailDto);
      return Ok();
   }
}