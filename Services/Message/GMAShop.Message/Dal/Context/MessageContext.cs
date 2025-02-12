using GMAShop.Message.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Message.Dal.Context;

public class MessageContext: DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433; Initial Catalog=GMAShopMessageDb; User Id=sa; Password=201203011Aa.; Encrypt=false; TrustServerCertificate=True;");
    }

    public DbSet<UserMessage> UserMessages { get; set; }
}