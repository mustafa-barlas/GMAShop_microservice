﻿using GMAShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Comment.Context;

public class CommentContext : DbContext
{
    public DbSet<UserComment> UserComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433; Initial Catalog=GMAShopCommentDb; User Id=sa; Password=201203011Aa.; Encrypt=false; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserComment>().HasKey(x => x.CommentId);
    }
}