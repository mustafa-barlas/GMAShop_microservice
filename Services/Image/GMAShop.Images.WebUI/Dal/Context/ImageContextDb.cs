using GMAShop.Images.WebUI.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Images.WebUI.Dal.Context;

public class ImageContextDb : DbContext
{
    public DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433; Initial Catalog=GMAShopImageDb; User Id=sa; Password=201203011Aa.; Encrypt=false; TrustServerCertificate=True;");    }
}