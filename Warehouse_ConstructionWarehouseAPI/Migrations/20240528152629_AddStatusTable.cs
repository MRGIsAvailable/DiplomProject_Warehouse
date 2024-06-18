using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 28, 18, 26, 28, 752, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 28, 18, 26, 28, 752, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "В обработке" },
                    { 2, "В пути" },
                    { 3, "Доставлено" },
                    { 4, "Не доставлено" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryStatus",
                table: "Orders",
                column: "DeliveryStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatus",
                table: "Orders",
                column: "DeliveryStatus",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatus",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 28, 17, 57, 40, 936, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 28, 17, 57, 40, 936, DateTimeKind.Local).AddTicks(9557));
        }
    }
}
