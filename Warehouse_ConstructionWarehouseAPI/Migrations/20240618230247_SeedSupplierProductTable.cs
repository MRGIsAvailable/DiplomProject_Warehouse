using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedSupplierProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 2, 47, 652, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 2, 47, 652, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 2, 47, 652, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 2, 47, 652, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 2, 47, 652, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.InsertData(
                table: "SupplierProducts",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { 3, 3, 1 },
                    { 4, 4, 3 },
                    { 5, 5, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 0, 46, 494, DateTimeKind.Local).AddTicks(2480));
        }
    }
}
