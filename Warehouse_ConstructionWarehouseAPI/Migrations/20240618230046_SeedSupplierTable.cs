using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "ivn@gmail.com");

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "ContactName", "Email", "Phone", "SupplierName" },
                values: new object[] { 3, "Воробьев И. В.", "vob@yandex.ru", "+77312395715", "ООО 'СтройМомент'" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "vik@gmail.com");
        }
    }
}
