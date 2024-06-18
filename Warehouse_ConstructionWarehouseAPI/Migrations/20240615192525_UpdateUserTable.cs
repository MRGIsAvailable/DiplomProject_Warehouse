using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_ConstructionWarehouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatus",
                table: "Orders",
                newName: "DeliveryStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryStatus",
                table: "Orders",
                newName: "IX_Orders_DeliveryStatusId");

            migrationBuilder.AddColumn<int>(
                name: "PremiseId",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "PremiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "PremiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 15, 22, 25, 25, 373, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 15, 22, 25, 25, 373, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { "Гвозди по бетону усиленные выполнены из качественной стали.\r\n\r\n Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его.\r\n\r\n Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов:\r\n\r\n фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к\r\n\r\n металлическим изделиям, в том числе к двутавровым балкам.", "Гвозди по бетону 3,05х19 мм, 1000 шт.\r\n\r\n " });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Details",
                value: " Длина\r\n40 мм\r\n\r\nТип резьбы\r\nполная\r\n\r\nДиаметр резьбы\r\nМ10\r\n\r\nШаг резьбы\r\n1.5 мм\r\n\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\n\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\n\r\nКомплектация\r\nболт+гайка+шайба\r\n\r\nВид головки\r\nшестигранная\r\n\r\nКласс прочности\r\n8.8\r\n\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\n\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\n\r\nМатериал\r\nсталь\r\n\r\nПокрытие\r\nоцинкованное");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserRole",
                value: "Менеджер");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserRole",
                value: "Менеджер");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PremiseId",
                table: "Inventory",
                column: "PremiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Premises_PremiseId",
                table: "Inventory",
                column: "PremiseId",
                principalTable: "Premises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatusId",
                table: "Orders",
                column: "DeliveryStatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Premises_PremiseId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_PremiseId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "PremiseId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatusId",
                table: "Orders",
                newName: "DeliveryStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryStatusId",
                table: "Orders",
                newName: "IX_Orders_DeliveryStatus");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Западное крыло");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Западное крыло");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 6, 13, 20, 27, 49, 576, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 6, 13, 20, 27, 49, 576, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "ProductName" },
                values: new object[] { "Гвозди по бетону усиленные выполнены из качественной стали. Удобная форма дюбеля позволяет легко разместить гвоздь в пазу и прочно закрепить его. Комплект включает в себя 1000 гвоздей. Изделие применяется для крепления к бетону различных материалов: фанеры, пластика, металлического профлиста. Материал гвоздей прочен: допускается монтаж изделий к металлическим изделиям, в том числе к двутавровым балкам.", "Гвозди по бетону 3,05х19 мм, 1000 шт." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Details",
                value: " Длина\r\n40 мм\r\nТип резьбы\r\nполная\r\nДиаметр резьбы\r\nМ10\r\nШаг резьбы\r\n1.5 мм\r\nНаправление резьбы\r\nправая\r\nФасовка, шт\r\n2 шт\r\nТип фасовки\r\nшт.\r\nФасовка\r\n0.09 кг\r\nКомплектация\r\nболт+гайка+шайба\r\nВид головки\r\nшестигранная\r\nКласс прочности\r\n8.8\r\nРазмер под ключ\r\n17\r\nDIN\r\n933\r\nГОСТ\r\n7805-70/7798-70\r\nISO\r\n4017\r\nМатериал\r\nсталь\r\nПокрытие\r\nоцинкованное\r\n");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password", "UserRole" },
                values: new object[] { "krl@gmail.com", "1234", "Администратор" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password", "UserRole" },
                values: new object[] { "ptr@gmail.com", "321", "Администратор" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_DeliveryStatus",
                table: "Orders",
                column: "DeliveryStatus",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
