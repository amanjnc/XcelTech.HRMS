using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class addedfilesandimagesplusotherbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13191802-958f-4ad5-b3c7-34aebdf387d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "718510c5-062b-4049-986b-70f3820ee9d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c641cdab-bba8-497a-a164-99a9c45da510");

            migrationBuilder.DropColumn(
                name: "EmployeeAge",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "EmployeeLastName");

            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeImage",
                table: "Employees",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "employeeCredentailFile",
                table: "Employees",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0171358f-03ea-4d22-97cd-373c4ead0492", null, "hr", "HR" },
                    { "4cc3b233-4243-41e7-9f0b-f784edcb39d5", null, "employee", "EMPLOYEE" },
                    { "b694ab23-e9a7-4c9a-b1eb-5953a3da617e", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "EmployeeFirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "employeeCredentailFile",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeLastName",
                table: "Employees",
                newName: "EmployeeName");

            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeImage",
                table: "Employees",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeAge",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13191802-958f-4ad5-b3c7-34aebdf387d5", null, "hr", "HR" },
                    { "718510c5-062b-4049-986b-70f3820ee9d9", null, "admin", "ADMIN" },
                    { "c641cdab-bba8-497a-a164-99a9c45da510", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
