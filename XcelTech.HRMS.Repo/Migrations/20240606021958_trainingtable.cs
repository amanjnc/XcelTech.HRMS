using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class trainingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Employees_TraineeId",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Employees_TrainerId",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_TraineeId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_TrainerId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "MyProperty1",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "TypeDescription",
                table: "Training",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "TrainingName",
                table: "Training",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TrainingDescription",
                table: "Training",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Training",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Training",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Training",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Training",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Training",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Training",
                newName: "TypeDescription");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Training",
                newName: "TrainingName");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Training",
                newName: "TrainingDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Training",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Training",
                newName: "TrainerId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Training",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Training",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "Training",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "MyProperty1",
                table: "Training",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Training",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                table: "Training",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TraineeId",
                table: "Training",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerId",
                table: "Training",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Employees_TraineeId",
                table: "Training",
                column: "TraineeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Employees_TrainerId",
                table: "Training",
                column: "TrainerId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
