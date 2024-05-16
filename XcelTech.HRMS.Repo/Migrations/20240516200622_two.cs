using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32aa8ba-c8f8-4be5-adad-1cbcd4bac8a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7364df7-806b-405e-9c04-6595e07c7e91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd6c4945-4a42-44d5-9924-2c07df9d78e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "995f4cfa-e620-4f74-a4bd-2c0b912da63d", null, "admin", "ADMIN" },
                    { "9d581a9b-ced6-4b54-a7ff-e187b8158c6e", null, "employee", "EMPLOYEE" },
                    { "ed0af295-140e-4b6f-9088-49d8bac28f2a", null, "hr", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "995f4cfa-e620-4f74-a4bd-2c0b912da63d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d581a9b-ced6-4b54-a7ff-e187b8158c6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0af295-140e-4b6f-9088-49d8bac28f2a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c32aa8ba-c8f8-4be5-adad-1cbcd4bac8a8", null, "hr", "HR" },
                    { "c7364df7-806b-405e-9c04-6595e07c7e91", null, "employee", "EMPLOYEE" },
                    { "fd6c4945-4a42-44d5-9924-2c07df9d78e9", null, "admin", "ADMIN" }
                });
        }
    }
}
