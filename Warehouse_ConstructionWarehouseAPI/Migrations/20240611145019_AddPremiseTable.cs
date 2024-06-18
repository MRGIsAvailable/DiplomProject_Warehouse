using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPremiseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 11, 17, 50, 18, 959, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 11, 17, 50, 18, 959, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.InsertData(
                table: "Premises",
                columns: new[] { "Id", "PremiseName" },
                values: new object[,]
                {
                    { 1, "Складское помещение №1 - Крепжные изделия" },
                    { 2, "Складское помещение №2 - Инструменты" },
                    { 3, "Складское помещение №3 - Материалы" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "Price", "ProductName" },
                values: new object[] { "Гвозди по бетону усиленные выполнены из качественной стали. Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его. Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов: фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к металлическим изделиям, в том числе к двутавровым балкам.", 1437.0, "Гвозди по бетону 3,05х19 мм, 1000 шт." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "Price", "ProductName" },
                values: new object[] { " Длина\r\n40 мм\r\nТип резьбы\r\nполная\r\nДиаметр резьбы\r\nМ10\r\nШаг резьбы\r\n1.5 мм\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nКомплектация\r\nболт+гайка+шайба\r\nВид головки\r\nшестигранная\r\nКласс прочности\r\n8.8\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nМатериал\r\nсталь\r\nПокрытие\r\nоцинкованное\r\n", 71.0, "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Premises");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 2, 15, 30, 27, 376, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 2, 15, 30, 27, 376, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "ImageUrl", "Price", "ProductName" },
                values: new object[] { "", "", 1500.0, "Гвозди x100" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "ImageUrl", "Price", "ProductName" },
                values: new object[] { "", "", 2000.0, "Болты x100" });
        }
    }
}
