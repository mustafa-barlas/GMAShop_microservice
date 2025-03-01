namespace GMAShop.WebUI.Models;

public class MailRequest
{
    public string Receiver { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
}