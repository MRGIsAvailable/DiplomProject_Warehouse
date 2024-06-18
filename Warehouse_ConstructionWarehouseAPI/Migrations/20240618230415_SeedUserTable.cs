using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 4, 15, 647, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 4, 15, 647, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 4, 15, 647, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 4, 15, 647, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 6, 19, 2, 4, 15, 647, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "UserRole" },
                values: new object[,]
                {
                    { 3, "Белкин И. В.", "Менеджер" },
                    { 4, "Вишневский М. П.", "Менеджер" },
                    { 5, "Богданов К. М.", "Менеджер" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
