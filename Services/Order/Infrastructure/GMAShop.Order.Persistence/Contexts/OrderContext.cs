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
        optionsBuilder.UseSqlServer("Server=MUSTAFABRLS; initial Catalog=GMAShopOrderDb; integrated security=true;");
    }
}