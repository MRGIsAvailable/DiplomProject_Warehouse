using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTableNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Email", "FullName", "Password", "UserRole" },
                values: new object[,]
                {
                    { 1, "vik@ya.ru", "Лельков В. А.", "123", "Администратор" },
                    { 2, "szh@gmail.com", "Сажин С. В.", "321", "Администратор" },
                    { 3, "min@ya.ru", "Еремин А. М.", "231", "Администратор" }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocalUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocalUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocalUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 15, 22, 25, 25, 373, DateTimeKind.Local).AddTicks(5368), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 15, 22, 25, 25, 373, DateTimeKind.Local).AddTicks(5377), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
