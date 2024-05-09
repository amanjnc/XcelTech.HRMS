using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class anotherbsssasdfasdfjalsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

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

            migrationBuilder.DropColumn(
                name: "departmentName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67fadb69-fd08-4366-b023-39088b3282d9", null, "admin", "ADMIN" },
                    { "908dd869-05a3-403a-b792-e6a18c574564", null, "employee", "EMPLOYEE" },
                    { "b5ccb7a1-3f43-435c-863c-763c6100dbf3", null, "hr", "HR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67fadb69-fd08-4366-b023-39088b3282d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "908dd869-05a3-403a-b792-e6a18c574564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5ccb7a1-3f43-435c-863c-763c6100dbf3");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentID");

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
                    { "0f74753e-546c-458c-86f7-cc9246c7988d", null, "hr", "HR" },
                    { "470d9b4d-d8ab-485c-827b-5a63b8f9048b", null, "admin", "ADMIN" },
                    { "c670115f-41b9-4e9c-bb0c-f6fc7584ec40", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
