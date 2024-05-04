using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class fsghjjjk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fcf1aa4-12cc-412f-a3f7-2f54117b6dd5", null, "hr", "HR" },
                    { "852ed800-00d0-45af-a593-ebab47ba8f92", null, "admin", "ADMIN" },
                    { "85ad34e2-439f-49c7-aee2-beab6c9433e7", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fcf1aa4-12cc-412f-a3f7-2f54117b6dd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "852ed800-00d0-45af-a593-ebab47ba8f92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ad34e2-439f-49c7-aee2-beab6c9433e7");

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
    }
}
