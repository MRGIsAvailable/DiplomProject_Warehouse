using Microsoft.EntityFrameworkCore;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Premise> Premises { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductName = "Гвозди по бетону 3,05х19 мм, 1000 шт.",
                    Details = "Гвозди по бетону усиленные выполнены из качественной стали.\r\n\r\n " +
                    "Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его.\r\n\r\n " +
                    "Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов:\r\n\r\n " +
                    "фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к\r\n\r\n " +
                    "металлическим изделиям, в том числе к двутавровым балкам.",
                    CategoryID = 1,
                    Price = 1437
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 ",
                    Details = " Длина\r\n40 мм\r\n\r\n" +
                    "Тип резьбы\r\nполная\r\n\r\n" +
                    "Диаметр резьбы\r\nМ10\r\n\r\n" +
                    "Шаг резьбы\r\n1.5 мм\r\n\r\n" +
                    "Направление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\n\r\n" +
                    "Тип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\n\r\n" +
                    "Комплектация\r\nболт+гайка+шайба\r\n\r\n" +
                    "Вид головки\r\nшестигранная\r\n\r\n" +
                    "Класс прочности\r\n8.8\r\n\r\n" +
                    "Размер под ключ\r\n17\r\nDIN\r\n933\r\n\r\n" +
                    "ГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\n\r\n" +
                    "Материал\r\nсталь\r\n\r\n" +
                    "Покрытие\r\nоцинкованное",
                    CategoryID = 1,
                    Price = 71
                },
                new Product()
                {
                    Id = 3,
                    ProductName = "Молоток гвоздодер с магнитным держателем гвоздя ",
                    Details = "Молоток для различных строительно-монтажных работ. " +
                    "Используется в работе с деревянными конструкциями. Предназначен " +
                    "для забивания гвоздей при проведении строительно-монтажных работ " +
                    "с использованием различных материалов",
                    CategoryID = 2,
                    Price = 2499
                },
                new Product()
                {
                    Id = 4,
                    ProductName = "Ножницы комбинированные правые",
                    Details = "Комбинированные (идеальные) ножницы для прямых и криволинейных " +
                    "резов.\r\n\r\nИспользуется в работе с материалами:\r\n\r\n    двойной " +
                    "стоячий фальц\r\n\r\n    кликфальц\r\n\r\n    плоский металлический " +
                    "лист\r\n\r\nНазначение:\r\n\r\n    предназначены для прямых и криволинейных " +
                    "резов металла\r\n\r\n    применяются при монтаже всех узлов фальцевой кровли, " +
                    "благодаря своей универсальности\r\n",
                    CategoryID = 2,
                    Price = 2699
                },
                new Product()
                {
                    Id = 5,
                    ProductName = "Карниз П19 Де-Багет 50/35",
                    Details = "Карниз П19 50/35 Де-Багет предназначен для декорирования потолка: " +
                    "украшает помещение, придает потолку законченный вид, позволяя скрыть стыки и неровности.",
                    CategoryID = 2,
                    Price = 57,
                }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    ProductId = 1,
                    Quantity = 10,
                    CustomerId = 1,
                    PremiseId = 1,
                    Phone = "+78005553535",
                    OrderDate = DateTime.Now,
                    DeliveryStatusId = 1
                },
                new Order()
                {
                    Id = 2,
                    ProductId = 2,
                    Quantity = 15,
                    CustomerId = 1,
                    PremiseId = 1,
                    Phone = "+78012615441",
                    OrderDate = DateTime.Now,
                    DeliveryStatusId = 1
                },
                new Order()
                {
                    Id = 3,
                    ProductId = 3,
                    Quantity = 1,
                    CustomerId = 2,
                    PremiseId = 2,
                    Phone = "+78012615441",
                    OrderDate = DateTime.Now,
                    DeliveryStatusId = 3
                },
                new Order()
                {
                    Id = 4,
                    ProductId = 4,
                    Quantity = 1,
                    CustomerId = 1,
                    PremiseId = 2,
                    Phone = "+78005553535",
                    OrderDate = DateTime.Now,
                    DeliveryStatusId = 3
                },
                new Order()
                {
                    Id = 5,
                    ProductId = 5,
                    Quantity = 10,
                    CustomerId = 1,
                    PremiseId = 3,
                    Phone = "+78005553535",
                    OrderDate = DateTime.Now,
                    DeliveryStatusId = 2
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "Крепежные изделия",
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "Инструменты"
                },
                new Category()
                {
                    Id = 3,
                    CategoryName = "Материалы"
                }
                );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory()
                {
                    Id = 1,
                    ProductId = 1,
                    Quantity = 10,
                    PremiseId = 1,
                },
                new Inventory()
                {
                    Id = 2,
                    ProductId = 2,
                    Quantity = 12,
                    PremiseId = 1,
                },
                new Inventory()
                {
                    Id = 3,
                    ProductId = 3,
                    Quantity = 1,
                    PremiseId = 2,
                },
                new Inventory()
                {
                    Id = 4,
                    ProductId = 4,
                    Quantity = 1,
                    PremiseId = 2,
                }

                );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier()
                {
                    Id = 1,
                    SupplierName = "ООО 'СтройМаш'",
                    ContactName = "Иванов В. И.",
                    Phone = "+75553438383",
                    Email = "ivn@gmail.com"
                },
                new Supplier()
                {
                    Id = 2,
                    SupplierName = "ООО 'Строительная Техника'",
                    ContactName = "Гуськов Е. В.",
                    Phone = "+75473411283",
                    Email = "gus@gmail.com"
                },
                new Supplier()
                {
                    Id = 3,
                    SupplierName = "ООО 'СтройМомент'",
                    ContactName = "Воробьев И. В.",
                    Phone = "+77312395715",
                    Email = "vob@yandex.ru"
                }
                );
            modelBuilder.Entity<SupplierProduct>().HasData(
                new SupplierProduct()
                {
                    Id = 1,
                    ProductId = 1,
                    SupplierId = 2
                },
                new SupplierProduct()
                {
                    Id = 2,
                    ProductId = 2,
                    SupplierId = 1
                },
                new SupplierProduct()
                {
                    Id = 3,
                    ProductId = 3,
                    SupplierId = 1
                },
                new SupplierProduct()
                {
                    Id = 4,
                    ProductId = 4,
                    SupplierId = 3
                },
                new SupplierProduct()
                {
                    Id = 5,
                    ProductId = 5,
                    SupplierId = 3
                }
                );
            modelBuilder.Entity<Status>().HasData(
                new Status()
                {
                    Id = 1,
                    StatusName = "В обработке"
                },
                new Status()
                {
                    Id = 2,
                    StatusName = "В пути"
                },
                new Status()
                {
                    Id = 3,
                    StatusName = "Доставлено"
                },
                new Status()
                {
                    Id = 4,
                    StatusName = "Не доставлено"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FullName = "Королев В. А.",
                    UserRole = "Менеджер"
                },
                new User()
                {
                    Id = 2,
                    FullName = "Петренко Е. В.",
                    UserRole = "Менеджер"
                },
                new User()
                {
                    Id = 3,
                    FullName = "Белкин И. В.",
                    UserRole = "Менеджер"
                },
                new User()
                {
                    Id = 4,
                    FullName = "Вишневский М. П.",
                    UserRole = "Менеджер"
                },
                new User()
                {
                    Id = 5,
                    FullName = "Богданов К. М.",
                    UserRole = "Менеджер"
                }
                );
            modelBuilder.Entity<Premise>().HasData(
                new Premise()
                {
                    Id = 1,
                    PremiseName = "Складское помещение №1 - Крепжные изделия"
                },
                new Premise()
                {
                    Id = 2,
                    PremiseName = "Складское помещение №2 - Инструменты"
                },
                new Premise()
                {
                    Id = 3,
                    PremiseName = "Складское помещение №3 - Материалы"
                }
                );
            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser()
                {
                    Id = 1,
                    FullName = "Лельков В. А.",
                    Email = "vik@ya.ru",
                    Password = "123",
                    UserRole = "Администратор"
                },
                new LocalUser()
                {
                    Id = 2,
                    FullName = "Сажин С. В.",
                    Email = "szh@gmail.com",
                    Password = "321",
                    UserRole = "Администратор"
                },
                new LocalUser()
                {
                    Id = 3,
                    FullName = "Еремин А. М.",
                    Email = "min@ya.ru",
                    Password = "231",
                    UserRole = "Администратор"
                }
                );
        }
    }
}
