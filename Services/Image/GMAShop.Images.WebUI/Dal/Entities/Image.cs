using System.ComponentModel.DataAnnotations.Schema;

namespace GMAShop.Images.WebUI.Dal.Entities;

public class Image
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [NotMapped]
    public IFormFile? Photo { get; set; }
    public string? SavedUrl { get; set; }
    public string? SignedUrl { get; set; }
    public string? SavedFileName { get; set; }
}