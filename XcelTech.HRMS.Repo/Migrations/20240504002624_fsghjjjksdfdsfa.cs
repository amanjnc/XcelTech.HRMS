using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class fsghjjjksdfdsfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f579ec7-cb88-4c7c-a35b-153632f856f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2055a0f3-279a-4459-8595-9a7ed2499b77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c586557-d997-4be3-9b5f-4156bb2b8c41");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0f579ec7-cb88-4c7c-a35b-153632f856f1", null, "admin", "ADMIN" },
                    { "2055a0f3-279a-4459-8595-9a7ed2499b77", null, "hr", "HR" },
                    { "2c586557-d997-4be3-9b5f-4156bb2b8c41", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
