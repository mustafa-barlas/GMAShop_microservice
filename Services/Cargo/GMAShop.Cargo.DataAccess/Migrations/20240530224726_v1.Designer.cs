﻿// <auto-generated />
using System;
using GMAShop.Cargo.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GMAShop.Cargo.DataAccess.Migrations
{
    [DbContext(typeof(CargoContextDb))]
    [Migration("20240530224726_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GMAShop.Cargo.Entities.Concrete.CargoCompany", b =>
                {
                    b.Property<int>("CargoCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoCompanyId"));

                    b.Property<string>("CargoCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoCompanyId");

                    b.ToTable("CargoCompanies");
                });

            modelBuilder.Entity("GMAShop.Cargo.Entities.Concrete.CargoCustomer", b =>
                {
                    b.Property<int>("CargoCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoCustomerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoCustomerId");

                    b.ToTable("CargoCustomers");
                });

            modelBuilder.Entity("GMAShop.Cargo.Entities.Concrete.CargoDetail", b =>
                {
                    b.Property<int>("CargoDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoDetailId"));

                    b.Property<int>("Barcode")
                        .HasColumnType("int");

                    b.Property<int>("CargoCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoDetailId");

                    b.HasIndex("CargoCompanyId");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("GMAShop.Cargo.Entities.Concrete.CargoOperation", b =>
                {
                    b.Property<int>("CargoOperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoOperationId"));

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CargoOperationId");

                    b.ToTable("CargoOperations");
                });

            modelBuilder.Entity("GMAShop.Cargo.Entities.Concrete.CargoDetail", b =>
                {
                    b.HasOne("GMAShop.Cargo.Entities.Concrete.CargoCompany", "CargoCompany")
                        .WithMany()
                        .HasForeignKey("CargoCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoCompany");
                });
#pragma warning restore 612, 618
        }
    }
}