using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class fsghk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12cdf91b-a94d-4247-8f95-792a2ea72cfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d31269-25fd-46a7-b9d1-f2171d317a2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f48d8dc1-0c58-4ba6-90d2-0c3084df3f5a");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAge",
                table: "Employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dc81b55-70f3-4a79-b02c-e38a6d03cc79", null, "admin", "ADMIN" },
                    { "574a5567-5efa-4e74-9268-910fc6bfb978", null, "employee", "EMPLOYEE" },
                    { "fe648f5b-9ba3-4c56-bbd7-978552468b24", null, "hr", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dc81b55-70f3-4a79-b02c-e38a6d03cc79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "574a5567-5efa-4e74-9268-910fc6bfb978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe648f5b-9ba3-4c56-bbd7-978552468b24");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeAge",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12cdf91b-a94d-4247-8f95-792a2ea72cfe", null, "employee", "EMPLOYEE" },
                    { "17d31269-25fd-46a7-b9d1-f2171d317a2f", null, "hr", "HR" },
                    { "f48d8dc1-0c58-4ba6-90d2-0c3084df3f5a", null, "admin", "ADMIN" }
                });
        }
    }
}
