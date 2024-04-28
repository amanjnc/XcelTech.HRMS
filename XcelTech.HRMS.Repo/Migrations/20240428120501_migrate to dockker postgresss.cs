using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class migratetodockkerpostgresss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36a73835-d02f-4206-8a33-fd81eb9e2ea5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b1ce70-cc66-42e0-9a56-e7033cbfc46b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b18dced5-03dc-4ec3-b971-766da791b069");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30270594-8731-4c93-932f-9ab6cdd561a3", null, "seller", "SELLER" },
                    { "4409415f-fddf-4350-b8ba-e64120dd9564", null, "buyer", "BUYER" },
                    { "b775375f-8ceb-48f7-85e4-7bd4ffadfbca", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30270594-8731-4c93-932f-9ab6cdd561a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4409415f-fddf-4350-b8ba-e64120dd9564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b775375f-8ceb-48f7-85e4-7bd4ffadfbca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36a73835-d02f-4206-8a33-fd81eb9e2ea5", null, "buyer", "BUYER" },
                    { "37b1ce70-cc66-42e0-9a56-e7033cbfc46b", null, "seller", "SELLER" },
                    { "b18dced5-03dc-4ec3-b971-766da791b069", null, "admin", "ADMIN" }
                });
        }
    }
}
