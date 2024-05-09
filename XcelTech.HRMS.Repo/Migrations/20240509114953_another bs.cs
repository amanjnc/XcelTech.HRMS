using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class anotherbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0171358f-03ea-4d22-97cd-373c4ead0492");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc3b233-4243-41e7-9f0b-f784edcb39d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b694ab23-e9a7-4c9a-b1eb-5953a3da617e");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentID");

            migrationBuilder.AddColumn<string>(
                name: "departmentName",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56ef61d0-22be-4d9a-87d8-7cbfadcebcb1", null, "employee", "EMPLOYEE" },
                    { "6aa5fcaf-250d-4969-b98f-ea3a01acf03d", null, "admin", "ADMIN" },
                    { "6e543710-1847-4d57-bce4-63a5530d9be1", null, "hr", "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees");

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

            migrationBuilder.DropColumn(
                name: "departmentName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0171358f-03ea-4d22-97cd-373c4ead0492", null, "hr", "HR" },
                    { "4cc3b233-4243-41e7-9f0b-f784edcb39d5", null, "employee", "EMPLOYEE" },
                    { "b694ab23-e9a7-4c9a-b1eb-5953a3da617e", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
