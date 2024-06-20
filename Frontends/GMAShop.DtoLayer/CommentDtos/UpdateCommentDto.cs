﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CommentDtos
{
    public record UpdateCommentDto
    {
        public int UserCommentId { get; init; }
        public string FullName { get; init; }
        
        public string Mail { get; init; }
        public string? ImageUrl { get; init; }
        public string CommentDetail { get; init; }
        public int Rating { get; init; }
        public DateTime CreatedDate { get; init; }
        public bool Status { get; set; }
        public string ProductId { get; init; }
    }
}
