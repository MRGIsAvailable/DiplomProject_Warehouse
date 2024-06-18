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
    [Migration("20240618230046_SeedSupplierTable")]
    partial class SeedSupplierTable
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

                    b.Property<int>("PremiseId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PremiseId");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PremiseId = 1,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            PremiseId = 1,
                            ProductId = 2,
                            Quantity = 12
                        },
                        new
                        {
                            Id = 3,
                            PremiseId = 2,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            PremiseId = 2,
                            ProductId = 4,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.LocalUser", b =>
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

                    b.ToTable("LocalUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "vik@ya.ru",
                            FullName = "Лельков В. А.",
                            Password = "123",
                            UserRole = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Email = "szh@gmail.com",
                            FullName = "Сажин С. В.",
                            Password = "321",
                            UserRole = "Администратор"
                        },
                        new
                        {
                            Id = 3,
                            Email = "min@ya.ru",
                            FullName = "Еремин А. М.",
                            Password = "231",
                            UserRole = "Администратор"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PremiseId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryStatusId");

                    b.HasIndex("PremiseId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            DeliveryStatusId = 1,
                            OrderDate = new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2467),
                            Phone = "+78005553535",
                            PremiseId = 1,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            DeliveryStatusId = 1,
                            OrderDate = new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2476),
                            Phone = "+78012615441",
                            PremiseId = 1,
                            ProductId = 2,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            DeliveryStatusId = 3,
                            OrderDate = new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2478),
                            Phone = "+78012615441",
                            PremiseId = 2,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 1,
                            DeliveryStatusId = 3,
                            OrderDate = new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2479),
                            Phone = "+78005553535",
                            PremiseId = 2,
                            ProductId = 4,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 1,
                            DeliveryStatusId = 2,
                            OrderDate = new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2480),
                            Phone = "+78005553535",
                            PremiseId = 3,
                            ProductId = 5,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Premise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PremiseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Premises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PremiseName = "Складское помещение №1 - Крепжные изделия"
                        },
                        new
                        {
                            Id = 2,
                            PremiseName = "Складское помещение №2 - Инструменты"
                        },
                        new
                        {
                            Id = 3,
                            PremiseName = "Складское помещение №3 - Материалы"
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
                            Details = "Гвозди по бетону усиленные выполнены из качественной стали.\r\n\r\n Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его.\r\n\r\n Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов:\r\n\r\n фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к\r\n\r\n металлическим изделиям, в том числе к двутавровым балкам.",
                            Price = 1437.0,
                            ProductName = "Гвозди по бетону 3,05х19 мм, 1000 шт."
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Details = " Длина\r\n40 мм\r\n\r\nТип резьбы\r\nполная\r\n\r\nДиаметр резьбы\r\nМ10\r\n\r\nШаг резьбы\r\n1.5 мм\r\n\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\n\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\n\r\nКомплектация\r\nболт+гайка+шайба\r\n\r\nВид головки\r\nшестигранная\r\n\r\nКласс прочности\r\n8.8\r\n\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\n\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\n\r\nМатериал\r\nсталь\r\n\r\nПокрытие\r\nоцинкованное",
                            Price = 71.0,
                            ProductName = "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 "
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 2,
                            Details = "Молоток для различных строительно-монтажных работ. Используется в работе с деревянными конструкциями. Предназначен для забивания гвоздей при проведении строительно-монтажных работ с использованием различных материалов",
                            Price = 2499.0,
                            ProductName = "Молоток гвоздодер с магнитным держателем гвоздя "
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 2,
                            Details = "Комбинированные (идеальные) ножницы для прямых и криволинейных резов.\r\n\r\nИспользуется в работе с материалами:\r\n\r\n    двойной стоячий фальц\r\n\r\n    кликфальц\r\n\r\n    плоский металлический лист\r\n\r\nНазначение:\r\n\r\n    предназначены для прямых и криволинейных резов металла\r\n\r\n    применяются при монтаже всех узлов фальцевой кровли, благодаря своей универсальности\r\n",
                            Price = 2699.0,
                            ProductName = "Ножницы комбинированные правые"
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 2,
                            Details = "Карниз П19 50/35 Де-Багет предназначен для декорирования потолка: украшает помещение, придает потолку законченный вид, позволяя скрыть стыки и неровности.",
                            Price = 57.0,
                            ProductName = "Карниз П19 Де-Багет 50/35"
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
                            Email = "ivn@gmail.com",
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
                        },
                        new
                        {
                            Id = 3,
                            ContactName = "Воробьев И. В.",
                            Email = "vob@yandex.ru",
                            Phone = "+77312395715",
                            SupplierName = "ООО 'СтройМомент'"
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

                    b.Property<string>("FullName")
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
                            FullName = "Королев В. А.",
                            UserRole = "Менеджер"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Петренко Е. В.",
                            UserRole = "Менеджер"
                        });
                });

            modelBuilder.Entity("Warehouse_ConstructionWarehouseAPI.Models.Inventory", b =>
                {
                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Premise", "Premise")
                        .WithMany()
                        .HasForeignKey("PremiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Premise");

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
                        .HasForeignKey("DeliveryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Premise", "Premise")
                        .WithMany()
                        .HasForeignKey("PremiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_ConstructionWarehouseAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Premise");

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
