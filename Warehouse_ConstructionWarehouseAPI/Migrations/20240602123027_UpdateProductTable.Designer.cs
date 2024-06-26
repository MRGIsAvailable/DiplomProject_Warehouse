﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse_ConstructionWarehouseAPI.Data;

#nullable disable

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240602123027_UpdateProductTable")]
    partial class UpdateProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Крепежные изделия"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Инструменты"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Материалы"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Западное крыло",
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Location = "Западное крыло",
                            ProductId = 2,
                            Quantity = 12
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryStatus");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Г. Коломна, Ул. Калинина, Д. 23",
                            CustomerId = 1,
                            DeliveryStatus = 1,
                            OrderDate = new DateTime(2024, 6, 2, 15, 30, 27, 376, DateTimeKind.Local).AddTicks(1487),
                            Phone = "+78005553535",
                            ProductId = 1,
                            Quantity = 10,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Г. Коломна, Ул. Краскова, Д. 33",
                            CustomerId = 1,
                            DeliveryStatus = 1,
                            OrderDate = new DateTime(2024, 6, 2, 15, 30, 27, 376, DateTimeKind.Local).AddTicks(1496),
                            Phone = "+78012615441",
                            ProductId = 2,
                            Quantity = 15,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Details = "",
                            ImageUrl = "",
                            Price = 1500.0,
                            ProductName = "Гвозди x100"
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Details = "",
                            ImageUrl = "",
                            Price = 2000.0,
                            ProductName = "Болты x100"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "В обработке"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "В пути"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Доставлено"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Не доставлено"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactName = "Иванов В. И.",
                            Email = "vik@gmail.com",
                            Phone = "+75553438383",
                            SupplierName = "ООО 'СтройМаш'"
                        },
                        new
                        {
                            Id = 2,
                            ContactName = "Гуськов Е. В.",
                            Email = "gus@gmail.com",
                            Phone = "+75473411283",
                            SupplierName = "ООО 'Строительная Техника'"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.SupplierProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            SupplierId = 1
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "krl@gmail.com",
                            FullName = "Королев В. А.",
                            Password = "1234",
                            UserRole = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ptr@gmail.com",
                            FullName = "Петренко Е. В.",
                            Password = "321",
                            UserRole = "Администратор"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Inventory", b =>
                {
                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Order", b =>
                {
                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("DeliveryStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Product", b =>
                {
                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.SupplierProduct", b =>
                {
                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
