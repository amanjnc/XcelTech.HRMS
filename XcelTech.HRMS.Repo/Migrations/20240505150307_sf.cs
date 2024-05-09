using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class sf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a1c422-bad9-4c02-822b-fdfc1eea4c73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce14eb87-8362-4baa-871a-93e0f6774e8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbdf94b8-1b06-4b83-b42c-f8253368b365");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13191802-958f-4ad5-b3c7-34aebdf387d5", null, "hr", "HR" },
                    { "718510c5-062b-4049-986b-70f3820ee9d9", null, "admin", "ADMIN" },
                    { "c641cdab-bba8-497a-a164-99a9c45da510", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13191802-958f-4ad5-b3c7-34aebdf387d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "718510c5-062b-4049-986b-70f3820ee9d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c641cdab-bba8-497a-a164-99a9c45da510");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33a1c422-bad9-4c02-822b-fdfc1eea4c73", null, "hr", "HR" },
                    { "ce14eb87-8362-4baa-871a-93e0f6774e8c", null, "employee", "EMPLOYEE" },
                    { "dbdf94b8-1b06-4b83-b42c-f8253368b365", null, "admin", "ADMIN" }
                });
        }
    }
}
