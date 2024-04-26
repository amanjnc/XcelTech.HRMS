using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class Removedaspnetinherentvaliationrequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6e5764-c540-45c3-ba89-580a2c1688c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7616d68e-6e14-4714-a6fd-44a9b969f5ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc39d52-7a1c-495a-bd43-eab3cb318aea");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3b6e5764-c540-45c3-ba89-580a2c1688c0", null, "buyer", "BUYER" },
                    { "7616d68e-6e14-4714-a6fd-44a9b969f5ed", null, "admin", "ADMIN" },
                    { "8cc39d52-7a1c-495a-bd43-eab3cb318aea", null, "seller", "SELLER" }
                });
        }
    }
}
