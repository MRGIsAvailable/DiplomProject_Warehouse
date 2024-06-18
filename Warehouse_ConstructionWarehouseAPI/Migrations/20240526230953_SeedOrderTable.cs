using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CustomerId", "DeliveryStatus", "OrderDate", "Phone", "ProductId", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Г. Коломна, Ул. Калинина, Д. 23", 1, 1, new DateTime(2024, 5, 27, 2, 9, 53, 284, DateTimeKind.Local).AddTicks(6801), "+78005553535", 1, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Г. Коломна, Ул. Краскова, Д. 33", 1, 1, new DateTime(2024, 5, 27, 2, 9, 53, 284, DateTimeKind.Local).AddTicks(6814), "+78012615441", 2, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
