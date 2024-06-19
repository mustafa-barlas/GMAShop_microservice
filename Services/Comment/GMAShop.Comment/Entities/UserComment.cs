namespace GMAShop.Comment.Entities;

public class UserComment
{
    public int CommentId { get; set; }
    public string FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string Mail { get; set; }
    public string CommentDetail { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Status { get; set; }
    public string ProductId { get; set; }
}