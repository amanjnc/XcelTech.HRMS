using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XcelTech.HRMS.Repo.Migrations
{
    /// <inheritdoc />
    public partial class trainingtableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Training",
                newName: "TrainingId");

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Training",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "Training",
                newName: "Id");
        }
    }
}
