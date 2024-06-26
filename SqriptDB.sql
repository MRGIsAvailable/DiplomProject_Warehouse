USE [master]
GO
/****** Object:  Database [WarehouseAPI]    Script Date: 20.06.2024 15:33:59 ******/
CREATE DATABASE [WarehouseAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WarehouseAPI', FILENAME = N'C:\SQL2022\MSSQL16.MSSQLSERVER\MSSQL\DATA\WarehouseAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WarehouseAPI_log', FILENAME = N'C:\SQL2022\MSSQL16.MSSQLSERVER\MSSQL\DATA\WarehouseAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WarehouseAPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WarehouseAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WarehouseAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WarehouseAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WarehouseAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WarehouseAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WarehouseAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [WarehouseAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WarehouseAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WarehouseAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WarehouseAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WarehouseAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WarehouseAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WarehouseAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WarehouseAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WarehouseAPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WarehouseAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WarehouseAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WarehouseAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WarehouseAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WarehouseAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WarehouseAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WarehouseAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WarehouseAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [WarehouseAPI] SET  MULTI_USER 
GO
ALTER DATABASE [WarehouseAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WarehouseAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WarehouseAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WarehouseAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WarehouseAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WarehouseAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WarehouseAPI', N'ON'
GO
ALTER DATABASE [WarehouseAPI] SET QUERY_STORE = ON
GO
ALTER DATABASE [WarehouseAPI] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WarehouseAPI]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PremiseId] [int] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalUsers]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[UserRole] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LocalUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[DeliveryStatusId] [int] NOT NULL,
	[PremiseId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Premises]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Premises](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PremiseName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Premises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Products_API] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierProducts]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_SupplierProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.06.2024 15:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[UserRole] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240524014740_AddProductTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240524024441_SeedProductTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240524031220_SeedProductTable2', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240526224523_AddOrderTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240526230953_SeedOrderTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240527020645_AddForeignKeyToOrderTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240527023655_AddCategoryTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240527035418_AddInventoryTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240527044650_AddSupplierProductTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240527045513_AddSupplierTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528145741_AddSupplierProductNewTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528152629_AddStatusTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528165356_AddUserTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240602123027_UpdateProductTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240611145019_AddPremiseTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240612001435_UpdateOrderTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240613172749_AddLocalUsersToDb', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615192525_UpdateUserTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615193821_UpdateOrderTableNew', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618225037_SeedProductTable3', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618225603_SeedOrderTable2', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618225811_SeedInventoryTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618230046_SeedSupplierTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618230247_SeedSupplierProductTable', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618230415_SeedUserTable', N'8.0.5')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (1, N'Крепежные изделия')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (2, N'Инструменты')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (3, N'Материалы')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([Id], [ProductId], [Quantity], [PremiseId]) VALUES (1, 1, 10, 1)
INSERT [dbo].[Inventory] ([Id], [ProductId], [Quantity], [PremiseId]) VALUES (2, 2, 12, 1)
INSERT [dbo].[Inventory] ([Id], [ProductId], [Quantity], [PremiseId]) VALUES (3, 3, 1, 2)
INSERT [dbo].[Inventory] ([Id], [ProductId], [Quantity], [PremiseId]) VALUES (4, 4, 1, 2)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[LocalUsers] ON 

INSERT [dbo].[LocalUsers] ([Id], [FullName], [Email], [Password], [UserRole]) VALUES (1, N'Лельков В. А.', N'vik@ya.ru', N'123', N'Администратор')
INSERT [dbo].[LocalUsers] ([Id], [FullName], [Email], [Password], [UserRole]) VALUES (2, N'Сажин С. В.', N'szh@gmail.com', N'321', N'Администратор')
INSERT [dbo].[LocalUsers] ([Id], [FullName], [Email], [Password], [UserRole]) VALUES (3, N'Еремин А. М.', N'min@ya.ru', N'231', N'Администратор')
SET IDENTITY_INSERT [dbo].[LocalUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [ProductId], [Quantity], [CustomerId], [Phone], [OrderDate], [DeliveryStatusId], [PremiseId]) VALUES (1, 1, 10, 1, N'+78005553535', CAST(N'2024-06-19T02:04:15.6477260' AS DateTime2), 1, 1)
INSERT [dbo].[Orders] ([Id], [ProductId], [Quantity], [CustomerId], [Phone], [OrderDate], [DeliveryStatusId], [PremiseId]) VALUES (2, 2, 15, 1, N'+78012615441', CAST(N'2024-06-19T02:04:15.6477269' AS DateTime2), 1, 1)
INSERT [dbo].[Orders] ([Id], [ProductId], [Quantity], [CustomerId], [Phone], [OrderDate], [DeliveryStatusId], [PremiseId]) VALUES (3, 3, 1, 2, N'+78012615441', CAST(N'2024-06-19T02:04:15.6477270' AS DateTime2), 3, 2)
INSERT [dbo].[Orders] ([Id], [ProductId], [Quantity], [CustomerId], [Phone], [OrderDate], [DeliveryStatusId], [PremiseId]) VALUES (4, 4, 1, 1, N'+78005553535', CAST(N'2024-06-19T02:04:15.6477272' AS DateTime2), 3, 2)
INSERT [dbo].[Orders] ([Id], [ProductId], [Quantity], [CustomerId], [Phone], [OrderDate], [DeliveryStatusId], [PremiseId]) VALUES (5, 5, 10, 1, N'+78005553535', CAST(N'2024-06-19T02:04:15.6477273' AS DateTime2), 2, 3)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Premises] ON 

INSERT [dbo].[Premises] ([Id], [PremiseName]) VALUES (1, N'Складское помещение №1 - Крепжные изделия')
INSERT [dbo].[Premises] ([Id], [PremiseName]) VALUES (2, N'Складское помещение №2 - Инструменты')
INSERT [dbo].[Premises] ([Id], [PremiseName]) VALUES (3, N'Складское помещение №3 - Материалы')
SET IDENTITY_INSERT [dbo].[Premises] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Details], [CategoryID], [Price]) VALUES (1, N'Гвозди по бетону 3,05х19 мм, 1000 шт.', N'Гвозди по бетону усиленные выполнены из качественной стали.

 Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его.

 Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов:

 фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к

 металлическим изделиям, в том числе к двутавровым балкам.', 1, 1437)
INSERT [dbo].[Products] ([Id], [ProductName], [Details], [CategoryID], [Price]) VALUES (2, N'Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 ', N' Длина
40 мм

Тип резьбы
полная

Диаметр резьбы
М10

Шаг резьбы
1.5 мм

Направление резьбы
правая
Фасовка, шт
2 шт

Тип фасовки
шт.
Фасовка
0.09 кг

Комплектация
болт+гайка+шайба

Вид головки
шестигранная

Класс прочности
8.8

Размер под ключ
17
DIN
933

ГОСТ
7805-70/7798-70
ISO
4017

Материал
сталь

Покрытие
оцинкованное', 1, 71)
INSERT [dbo].[Products] ([Id], [ProductName], [Details], [CategoryID], [Price]) VALUES (3, N'Молоток гвоздодер с магнитным держателем гвоздя ', N'Молоток для различных строительно-монтажных работ. Используется в работе с деревянными конструкциями. Предназначен для забивания гвоздей при проведении строительно-монтажных работ с использованием различных материалов', 2, 2499)
INSERT [dbo].[Products] ([Id], [ProductName], [Details], [CategoryID], [Price]) VALUES (4, N'Ножницы комбинированные правые', N'Комбинированные (идеальные) ножницы для прямых и криволинейных резов.

Используется в работе с материалами:

    двойной стоячий фальц

    кликфальц

    плоский металлический лист

Назначение:

    предназначены для прямых и криволинейных резов металла

    применяются при монтаже всех узлов фальцевой кровли, благодаря своей универсальности
', 2, 2699)
INSERT [dbo].[Products] ([Id], [ProductName], [Details], [CategoryID], [Price]) VALUES (5, N'Карниз П19 Де-Багет 50/35', N'Карниз П19 50/35 Де-Багет предназначен для декорирования потолка: украшает помещение, придает потолку законченный вид, позволяя скрыть стыки и неровности.', 2, 57)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([Id], [StatusName]) VALUES (1, N'В обработке')
INSERT [dbo].[Statuses] ([Id], [StatusName]) VALUES (2, N'В пути')
INSERT [dbo].[Statuses] ([Id], [StatusName]) VALUES (3, N'Доставлено')
INSERT [dbo].[Statuses] ([Id], [StatusName]) VALUES (4, N'Не доставлено')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierProducts] ON 

INSERT [dbo].[SupplierProducts] ([Id], [ProductId], [SupplierId]) VALUES (1, 1, 2)
INSERT [dbo].[SupplierProducts] ([Id], [ProductId], [SupplierId]) VALUES (2, 2, 1)
INSERT [dbo].[SupplierProducts] ([Id], [ProductId], [SupplierId]) VALUES (3, 3, 1)
INSERT [dbo].[SupplierProducts] ([Id], [ProductId], [SupplierId]) VALUES (4, 4, 3)
INSERT [dbo].[SupplierProducts] ([Id], [ProductId], [SupplierId]) VALUES (5, 5, 3)
SET IDENTITY_INSERT [dbo].[SupplierProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [SupplierName], [ContactName], [Phone], [Email]) VALUES (1, N'ООО ''СтройМаш''', N'Иванов В. И.', N'+75553438383', N'ivn@gmail.com')
INSERT [dbo].[Suppliers] ([Id], [SupplierName], [ContactName], [Phone], [Email]) VALUES (2, N'ООО ''Строительная Техника''', N'Гуськов Е. В.', N'+75473411283', N'gus@gmail.com')
INSERT [dbo].[Suppliers] ([Id], [SupplierName], [ContactName], [Phone], [Email]) VALUES (3, N'ООО ''СтройМомент''', N'Воробьев И. В.', N'+77312395715', N'vob@yandex.ru')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [UserRole]) VALUES (1, N'Королев В. А.', N'Менеджер')
INSERT [dbo].[Users] ([Id], [FullName], [UserRole]) VALUES (2, N'Петренко Е. В.', N'Менеджер')
INSERT [dbo].[Users] ([Id], [FullName], [UserRole]) VALUES (3, N'Белкин И. В.', N'Менеджер')
INSERT [dbo].[Users] ([Id], [FullName], [UserRole]) VALUES (4, N'Вишневский М. П.', N'Менеджер')
INSERT [dbo].[Users] ([Id], [FullName], [UserRole]) VALUES (5, N'Богданов К. М.', N'Менеджер')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Inventory_PremiseId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_PremiseId] ON [dbo].[Inventory]
(
	[PremiseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventory_ProductId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_ProductId] ON [dbo].[Inventory]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CustomerId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DeliveryStatusId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveryStatusId] ON [dbo].[Orders]
(
	[DeliveryStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_PremiseId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_PremiseId] ON [dbo].[Orders]
(
	[PremiseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierProducts_ProductId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_SupplierProducts_ProductId] ON [dbo].[SupplierProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierProducts_SupplierId]    Script Date: 20.06.2024 15:33:59 ******/
CREATE NONCLUSTERED INDEX [IX_SupplierProducts_SupplierId] ON [dbo].[SupplierProducts]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [PremiseId]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [PremiseId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Price]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Premises_PremiseId] FOREIGN KEY([PremiseId])
REFERENCES [dbo].[Premises] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Premises_PremiseId]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Premises_PremiseId] FOREIGN KEY([PremiseId])
REFERENCES [dbo].[Premises] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Premises_PremiseId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Statuses_DeliveryStatusId] FOREIGN KEY([DeliveryStatusId])
REFERENCES [dbo].[Statuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Statuses_DeliveryStatusId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_CustomerId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryID]
GO
ALTER TABLE [dbo].[SupplierProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierProducts] CHECK CONSTRAINT [FK_SupplierProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[SupplierProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProducts_Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupplierProducts] CHECK CONSTRAINT [FK_SupplierProducts_Suppliers_SupplierId]
GO
USE [master]
GO
ALTER DATABASE [WarehouseAPI] SET  READ_WRITE 
GO
