using GMAShop.Cargo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Cargo.DataAccess.Concrete.Context;

public class CargoContextDb : DbContext
{
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MUSTAFABRLS,1441; Initial Catalog=GMAShopCargoDb; User Id=sa; Password=201203011Aa.; Encrypt=True; TrustServerCertificate=True;");
    }
}