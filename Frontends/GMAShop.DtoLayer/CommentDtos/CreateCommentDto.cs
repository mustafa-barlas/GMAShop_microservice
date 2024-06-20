using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CommentDtos
{
    public record CreateCommentDto
    {
        public string FullName { get; init; }
        
        public string Mail { get; init; }
        public string? ImageUrl { get; set; }
        public string CommentDetail { get; init; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
