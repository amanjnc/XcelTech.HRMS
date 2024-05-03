using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "127e1c8b-9f86-4285-9831-0422bef2d6f4", null, "employee", "EMPLOYEE" },
                    { "4c431728-efed-4755-ac90-6606d1aaea63", null, "hr", "HR" },
                    { "4d5a7259-71d7-4287-af66-5c76237cae31", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "127e1c8b-9f86-4285-9831-0422bef2d6f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c431728-efed-4755-ac90-6606d1aaea63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d5a7259-71d7-4287-af66-5c76237cae31");

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
