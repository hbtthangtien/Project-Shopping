using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorePhone",
                schema: "dbo",
                table: "Stores",
                newName: "store_phone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "feedback_date",
                schema: "dbo",
                table: "Feedbacks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 13, 22, 42, 481, DateTimeKind.Local).AddTicks(5166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 16, 21, 55, 42, 265, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Account",
                keyColumn: "account_id",
                keyValue: "1",
                columns: new[] { "concurrency_stamp", "latest_login", "password_hash", "sercurity_stamp" },
                values: new object[] { "c4edcea2-f655-446f-96b0-61e93ff0cb0e", new DateTime(2025, 1, 24, 13, 22, 42, 498, DateTimeKind.Local).AddTicks(6159), "AQAAAAIAAYagAAAAEPS5WDGt6uDH1vBDGf/YBMFntQsmwPRzE7BdaD4cfc/NpTAU4hmUn+xO08Cex3VImw==", "a05d2c33-9c15-4b1d-b694-a653b81aeb43" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "store_phone",
                schema: "dbo",
                table: "Stores",
                newName: "StorePhone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "feedback_date",
                schema: "dbo",
                table: "Feedbacks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 16, 21, 55, 42, 265, DateTimeKind.Local).AddTicks(3601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 13, 22, 42, 481, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Account",
                keyColumn: "account_id",
                keyValue: "1",
                columns: new[] { "concurrency_stamp", "latest_login", "password_hash", "sercurity_stamp" },
                values: new object[] { "0229e33c-b6f0-475a-a041-b23ac428c9d7", new DateTime(2025, 1, 16, 21, 55, 42, 285, DateTimeKind.Local).AddTicks(6794), "AQAAAAIAAYagAAAAEDJwcH/2oeea013iPXwS2pbUP/pZWhgpObINSPOCTVstkFm2COJlTQUc/2wSmXVo+g==", "abb5cd43-fcfb-41a1-a539-f7cf41444d02" });
        }
    }
}
