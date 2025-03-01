using GMAShop.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace GMAShop.WebUI.Controllers;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult SendMail()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMail(MailRequest request)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("GMAShop", "mustafa.barlas1146@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", request.Receiver);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = request.MessageContent;
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = request.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("mustafa.barlas1146@gmail.com", "cqjvkjbnnoybqfxf");
        client.Send(mimeMessage);
        client.Disconnect(true);


        return RedirectToAction("SendMail");
    }
}