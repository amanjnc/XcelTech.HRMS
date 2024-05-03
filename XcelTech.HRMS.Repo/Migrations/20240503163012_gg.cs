using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class gg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "760947e0-fd78-4fb7-aa0b-389715fc8a3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d0af03d-73ff-4c2c-a4e0-46188d72e083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd32da64-5a8c-4244-aa83-f8a573554972");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "760947e0-fd78-4fb7-aa0b-389715fc8a3d", null, "employee", "EMPLOYEE" },
                    { "7d0af03d-73ff-4c2c-a4e0-46188d72e083", null, "hr", "HR" },
                    { "cd32da64-5a8c-4244-aa83-f8a573554972", null, "admin", "ADMIN" }
                });
        }
    }
}
