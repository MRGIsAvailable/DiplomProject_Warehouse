using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 50, 37, 411, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 50, 37, 411, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductName",
                value: "Гвозди по бетону 3,05х19 мм, 1000 шт.");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Details", "Price", "ProductName" },
                values: new object[,]
                {
                    { 3, 2, "Молоток для различных строительно-монтажных работ. Используется в работе с деревянными конструкциями. Предназначен для забивания гвоздей при проведении строительно-монтажных работ с использованием различных материалов", 2499.0, "Молоток гвоздодер с магнитным держателем гвоздя " },
                    { 4, 2, "Комбинированные (идеальные) ножницы для прямых и криволинейных резов.\r\n\r\nИспользуется в работе с материалами:\r\n\r\n    двойной стоячий фальц\r\n\r\n    кликфальц\r\n\r\n    плоский металлический лист\r\n\r\nНазначение:\r\n\r\n    предназначены для прямых и криволинейных резов металла\r\n\r\n    применяются при монтаже всех узлов фальцевой кровли, благодаря своей универсальности\r\n", 2699.0, "Ножницы комбинированные правые" },
                    { 5, 2, "Карниз П19 50/35 Де-Багет предназначен для декорирования потолка: украшает помещение, придает потолку законченный вид, позволяя скрыть стыки и неровности.", 57.0, "Карниз П19 Де-Багет 50/35" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 15, 22, 38, 20, 863, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 15, 22, 38, 20, 863, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductName",
                value: "Гвозди по бетону 3,05х19 мм, 1000 шт.\r\n\r\n ");
        }
    }
}
