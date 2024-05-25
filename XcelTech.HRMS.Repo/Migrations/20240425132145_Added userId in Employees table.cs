using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddeduserIdinEmployeestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41852cb9-c952-4753-be39-01e25edd2677");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98d97fed-8947-495e-a10b-499db8a13eea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce9de0c0-f0ea-4a62-9d17-20f4b1161f5e");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ccae5ee-2b0b-47e4-82c4-3e80cceb250e", null, "seller", "SELLER" },
                    { "5e9b3ec1-2cbf-4c33-aec0-c72f3f1363e5", null, "admin", "ADMIN" },
                    { "a89cb214-b6e0-47d1-b24e-e4c34e41eb1d", null, "buyer", "BUYER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AppUserId",
                table: "Employees",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AppUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ccae5ee-2b0b-47e4-82c4-3e80cceb250e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e9b3ec1-2cbf-4c33-aec0-c72f3f1363e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a89cb214-b6e0-47d1-b24e-e4c34e41eb1d");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41852cb9-c952-4753-be39-01e25edd2677", null, "admin", "ADMIN" },
                    { "98d97fed-8947-495e-a10b-499db8a13eea", null, "seller", "SELLER" },
                    { "ce9de0c0-f0ea-4a62-9d17-20f4b1161f5e", null, "buyer", "BUYER" }
                });
        }
    }
}
