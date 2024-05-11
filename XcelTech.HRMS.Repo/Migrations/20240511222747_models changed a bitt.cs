using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class modelschangedabitt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0755d891-fb83-441f-a4bc-1f5aa78c2260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "706f0415-a4f4-4ab4-8536-1060f7cf5a48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c27b2d91-9f84-4ab2-91fd-d70df897201c");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeLastName",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a96a59f5-1d34-4f5a-b7e6-3bbc747e1b4d", null, "hr", "HR" },
                    { "dcb705cf-45e3-4a66-bf1d-2b3280f5f276", null, "employee", "EMPLOYEE" },
                    { "efc1087c-15c1-4d14-9697-48bed055556b", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a96a59f5-1d34-4f5a-b7e6-3bbc747e1b4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb705cf-45e3-4a66-bf1d-2b3280f5f276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc1087c-15c1-4d14-9697-48bed055556b");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeLastName",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0755d891-fb83-441f-a4bc-1f5aa78c2260", null, "hr", "HR" },
                    { "706f0415-a4f4-4ab4-8536-1060f7cf5a48", null, "admin", "ADMIN" },
                    { "c27b2d91-9f84-4ab2-91fd-d70df897201c", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
