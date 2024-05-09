using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class anotherbsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56ef61d0-22be-4d9a-87d8-7cbfadcebcb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aa5fcaf-250d-4969-b98f-ea3a01acf03d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e543710-1847-4d57-bce4-63a5530d9be1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f74753e-546c-458c-86f7-cc9246c7988d", null, "hr", "HR" },
                    { "470d9b4d-d8ab-485c-827b-5a63b8f9048b", null, "admin", "ADMIN" },
                    { "c670115f-41b9-4e9c-bb0c-f6fc7584ec40", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f74753e-546c-458c-86f7-cc9246c7988d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "470d9b4d-d8ab-485c-827b-5a63b8f9048b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c670115f-41b9-4e9c-bb0c-f6fc7584ec40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56ef61d0-22be-4d9a-87d8-7cbfadcebcb1", null, "employee", "EMPLOYEE" },
                    { "6aa5fcaf-250d-4969-b98f-ea3a01acf03d", null, "admin", "ADMIN" },
                    { "6e543710-1847-4d57-bce4-63a5530d9be1", null, "hr", "HR" }
                });
        }
    }
}
