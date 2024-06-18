using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryStatusId", "OrderDate", "Phone", "PremiseId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 3, 2, 3, new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9498), "+78012615441", 2, 3, 1 },
                    { 4, 1, 3, new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9499), "+78005553535", 2, 4, 1 },
                    { 5, 1, 2, new DateTime(2024, 6, 19, 1, 56, 2, 767, DateTimeKind.Local).AddTicks(9500), "+78005553535", 3, 5, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
