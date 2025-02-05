namespace GMAShop.Message.Dtos;

public class CreateMessageDto
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Subject { get; set; }
    public string MessageDetail { get; set; }
    public DateTime MessageDate { get; set; }
    public bool IsRead { get; set; }
}