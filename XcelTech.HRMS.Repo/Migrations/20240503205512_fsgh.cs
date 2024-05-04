using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class fsgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f196e9-c9a8-402a-a78f-89d85094fcde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85420270-ae8e-4628-ae65-0f55d1cfda7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41eb6d0-55c7-4d5f-b763-89f33ec3f56c");

            migrationBuilder.AddColumn<byte[]>(
                name: "EmployeeImage",
                table: "Employees",
                type: "bytea",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EmployeeImage",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83f196e9-c9a8-402a-a78f-89d85094fcde", null, "admin", "ADMIN" },
                    { "85420270-ae8e-4628-ae65-0f55d1cfda7c", null, "employee", "EMPLOYEE" },
                    { "e41eb6d0-55c7-4d5f-b763-89f33ec3f56c", null, "hr", "HR" }
                });
        }
    }
}
