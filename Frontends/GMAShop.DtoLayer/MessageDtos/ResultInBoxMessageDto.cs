

namespace GMAShop.DtoLayer.MessageDtos
{
    public record ResultInBoxMessageDto
    {
        public int UserMessageId { get; init; }
        public string SenderId { get; init; }
        public string ReceiverId { get; init; }
        public string Subject { get; init; }
        public string MessageDetail { get; init; }
        public bool IsRead { get; init; }
        public DateTime MessageDate { get; init; }
    }
}
