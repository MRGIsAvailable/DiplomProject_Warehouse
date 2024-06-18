using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "PremiseId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 3, 2, 3, 1 },
                    { 4, 2, 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 58, 11, 372, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 58, 11, 372, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 58, 11, 372, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 58, 11, 372, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 58, 11, 372, DateTimeKind.Local).AddTicks(8549));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9500));
        }
    }
}
