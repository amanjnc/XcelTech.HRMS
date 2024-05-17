using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class fixedsomebs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dace14b-39e6-4ef0-8da5-2818f46598b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96feb066-2cce-4ba8-8fb3-2a34c1c73f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90a75db-fd28-4422-b988-49f54d3b788d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45c00e74-7372-4879-827f-ac496a1257fd", null, "admin", "ADMIN" },
                    { "872cd6f5-1599-4da2-bf06-b2b161c4cce5", null, "employee", "EMPLOYEE" },
                    { "a448a5b6-04e9-46e1-8b63-289a664fb58e", null, "hr", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45c00e74-7372-4879-827f-ac496a1257fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "872cd6f5-1599-4da2-bf06-b2b161c4cce5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a448a5b6-04e9-46e1-8b63-289a664fb58e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dace14b-39e6-4ef0-8da5-2818f46598b9", null, "employee", "EMPLOYEE" },
                    { "96feb066-2cce-4ba8-8fb3-2a34c1c73f56", null, "admin", "ADMIN" },
                    { "d90a75db-fd28-4422-b988-49f54d3b788d", null, "hr", "HR" }
                });
        }
    }
}
