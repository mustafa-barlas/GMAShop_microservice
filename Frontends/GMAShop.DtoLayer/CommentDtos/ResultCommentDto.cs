namespace GMAShop.DtoLayer.CommentDtos
{
    public record ResultCommentDto
    {
        public int UserCommentId { get; init; }
        public string FullName { get; init; }
        
        public string Mail { get; init; }
        public string? ImageUrl { get; init; }
        public string CommentDetail { get; init; }
        public int Rating { get; init; }
        public DateTime CreatedDate { get; init; }
        public bool Status { get; init; }
        public string ProductId { get; init; }
    }
}
