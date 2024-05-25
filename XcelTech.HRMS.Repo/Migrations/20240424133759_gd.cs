using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class gd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeFullName",
                table: "Employees",
                newName: "EmployeeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "EmployeeFullName");
        }
    }
}
