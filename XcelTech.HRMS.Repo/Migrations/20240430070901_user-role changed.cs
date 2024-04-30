using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class userrolechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6272e728-ef50-4b31-8264-c36dde6c998b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "655c46ac-1139-468c-924d-5c2afecf21dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d4d3ae0-2a58-42d8-8656-61d19a0f97b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "760947e0-fd78-4fb7-aa0b-389715fc8a3d", null, "employee", "EMPLOYEE" },
                    { "7d0af03d-73ff-4c2c-a4e0-46188d72e083", null, "hr", "HR" },
                    { "cd32da64-5a8c-4244-aa83-f8a573554972", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "760947e0-fd78-4fb7-aa0b-389715fc8a3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d0af03d-73ff-4c2c-a4e0-46188d72e083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd32da64-5a8c-4244-aa83-f8a573554972");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6272e728-ef50-4b31-8264-c36dde6c998b", null, "admin", "ADMIN" },
                    { "655c46ac-1139-468c-924d-5c2afecf21dc", null, "buyer", "BUYER" },
                    { "8d4d3ae0-2a58-42d8-8656-61d19a0f97b9", null, "seller", "SELLER" }
                });
        }
    }
}
