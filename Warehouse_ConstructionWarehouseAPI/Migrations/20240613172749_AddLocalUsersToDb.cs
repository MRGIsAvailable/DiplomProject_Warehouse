using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 13, 20, 27, 49, 576, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 13, 20, 27, 49, 576, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { " Длина\r\n40 мм\r\nТип резьбы\r\nполная\r\nДиаметр резьбы\r\nМ10\r\nШаг резьбы\r\n1.5 мм\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nКомплектация\r\nболт+гайка+шайба\r\nВид головки\r\nшестигранная\r\nКласс прочности\r\n8.8\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nМатериал\r\nсталь\r\nПокрытие\r\nоцинкованное\r\n", "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 12, 3, 14, 35, 348, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 12, 3, 14, 35, 348, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { " Длина\r\n40 мм\r\nrТип резьбы\r\nполная\r\nrДиаметр резьбы\r\nМ10\r\nrШаг резьбы\r\n1.5 мм\r\nrНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nrТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nrКомплектация\r\nболт+гайка+шайба\r\nrВид головки\r\nшестигранная\r\nrКласс прочности\r\n8.8\r\nrРазмер под ключ\r\n17\r\nDIN\r\n933\r\nrГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nrМатериал\r\nсталь\r\nrПокрытие\r\nоцинкованное\r\n", "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 r" });
        }
    }
}
