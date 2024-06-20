using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.MessageDtos
{
    public record ResultSendboxMessageDto
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
