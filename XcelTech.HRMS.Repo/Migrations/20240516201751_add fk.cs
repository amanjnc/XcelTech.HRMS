using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class addfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances");

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

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Attendances");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "656a0d92-4282-4d19-beb7-9ee97f584c0f", null, "employee", "EMPLOYEE" },
                    { "b89b12e1-f4b9-42d3-b6e8-0bb5c0c1d21f", null, "admin", "ADMIN" },
                    { "ca68b4cb-74cd-43d4-9f74-3f26be2e2726", null, "hr", "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "656a0d92-4282-4d19-beb7-9ee97f584c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b89b12e1-f4b9-42d3-b6e8-0bb5c0c1d21f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca68b4cb-74cd-43d4-9f74-3f26be2e2726");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Attendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "995f4cfa-e620-4f74-a4bd-2c0b912da63d", null, "admin", "ADMIN" },
                    { "9d581a9b-ced6-4b54-a7ff-e187b8158c6e", null, "employee", "EMPLOYEE" },
                    { "ed0af295-140e-4b6f-9088-49d8bac28f2a", null, "hr", "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
