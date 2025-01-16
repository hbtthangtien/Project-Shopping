using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                oldDefaultValue: new DateTime(2025, 1, 16, 16, 29, 29, 526, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Account",
                columns: new[] { "account_id", "concurrency_stamp", "email", "email_confirmed", "latest_login", "lockout_enabled", "lockout_end", "normalized_email", "normalized_username", "password_hash", "phone_number", "phone_number_confirmed", "sercurity_stamp", "two_factor_enabled", "username" },
                values: new object[] { "1", "0229e33c-b6f0-475a-a041-b23ac428c9d7", "admin@example.com", true, new DateTime(2025, 1, 16, 21, 55, 42, 285, DateTimeKind.Local).AddTicks(6794), false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEDJwcH/2oeea013iPXwS2pbUP/pZWhgpObINSPOCTVstkFm2COJlTQUc/2wSmXVo+g==", null, false, "abb5cd43-fcfb-41a1-a539-f7cf41444d02", false, "admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "concurrency_stamp", "role_name", "normalized_name" },
                values: new object[,]
                {
                    { "1", null, "ADMIN", "ADMIN" },
                    { "2", null, "SELLER", "SELLER" },
                    { "3", null, "MARKETING", "MARKETING" },
                    { "4", null, "CUSTOMER", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "role_is", "user_id" },
                values: new object[] { "1", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserRole",
                keyColumns: new[] { "role_is", "user_id" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Account",
                keyColumn: "account_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "feedback_date",
                schema: "dbo",
                table: "Feedbacks",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 16, 16, 29, 29, 526, DateTimeKind.Local).AddTicks(1681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 16, 21, 55, 42, 265, DateTimeKind.Local).AddTicks(3601));
        }
    }
}
