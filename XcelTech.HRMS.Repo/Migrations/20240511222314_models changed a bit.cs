using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class modelschangedabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19394a9b-d518-4aaa-9ff7-344e72a8f16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "429983d2-9664-4a9f-88e1-384a91ae0863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "618cc361-770e-407c-bb2e-d21f086f3f20");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeePhone",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "EmployeePhone",
                table: "Employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19394a9b-d518-4aaa-9ff7-344e72a8f16a", null, "hr", "HR" },
                    { "429983d2-9664-4a9f-88e1-384a91ae0863", null, "employee", "EMPLOYEE" },
                    { "618cc361-770e-407c-bb2e-d21f086f3f20", null, "admin", "ADMIN" }
                });
        }
    }
}
