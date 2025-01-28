using GMAShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Order.Persistence.Contexts;

public class OrderContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440; Initial Catalog=GMAShopOrderDb; User Id=sa; Password=201203011Aa.; Encrypt=True; TrustServerCertificate=True;",
            options => options.EnableRetryOnFailure());
    }

}