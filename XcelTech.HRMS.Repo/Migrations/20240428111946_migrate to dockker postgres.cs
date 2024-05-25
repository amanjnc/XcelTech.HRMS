using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class migratetodockkerpostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6272e728-ef50-4b31-8264-c36dde6c998b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "655c46ac-1139-468c-924d-5c2afecf21dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d4d3ae0-2a58-42d8-8656-61d19a0f97b9");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6272e728-ef50-4b31-8264-c36dde6c998b", null, "admin", "ADMIN" },
                    { "655c46ac-1139-468c-924d-5c2afecf21dc", null, "buyer", "BUYER" },
                    { "8d4d3ae0-2a58-42d8-8656-61d19a0f97b9", null, "seller", "SELLER" }
                });
        }
    }
}
