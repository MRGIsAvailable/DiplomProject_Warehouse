using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PremiseId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "PremiseId" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 14, 35, 348, DateTimeKind.Local).AddTicks(1577), 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderDate", "PremiseId" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 14, 35, 348, DateTimeKind.Local).AddTicks(1586), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { " Длина\r\n40 мм\r\nrТип резьбы\r\nполная\r\nrДиаметр резьбы\r\nМ10\r\nrШаг резьбы\r\n1.5 мм\r\nrНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nrТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nrКомплектация\r\nболт+гайка+шайба\r\nrВид головки\r\nшестигранная\r\nrКласс прочности\r\n8.8\r\nrРазмер под ключ\r\n17\r\nDIN\r\n933\r\nrГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nrМатериал\r\nсталь\r\nrПокрытие\r\nоцинкованное\r\n", "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 r" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PremiseId",
                table: "Orders",
                column: "PremiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Premises_PremiseId",
                table: "Orders",
                column: "PremiseId",
                principalTable: "Premises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Premises_PremiseId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PremiseId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PremiseId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "OrderDate" },
                values: new object[] { "Г. Коломна, Ул. Калинина, Д. 23", new DateTime(2024, 6, 11, 17, 50, 18, 959, DateTimeKind.Local).AddTicks(7851) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "OrderDate" },
                values: new object[] { "Г. Коломна, Ул. Краскова, Д. 33", new DateTime(2024, 6, 11, 17, 50, 18, 959, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { " Длина\r\n40 мм\r\nТип резьбы\r\nполная\r\nДиаметр резьбы\r\nМ10\r\nШаг резьбы\r\n1.5 мм\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nКомплектация\r\nболт+гайка+шайба\r\nВид головки\r\nшестигранная\r\nКласс прочности\r\n8.8\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nМатериал\r\nсталь\r\nПокрытие\r\nоцинкованное\r\n", "Болт с шестигранной головкой, оцинкованный М10х40 + гайка + шайба 2 шт - пакет 114055 " });
        }
    }
}
