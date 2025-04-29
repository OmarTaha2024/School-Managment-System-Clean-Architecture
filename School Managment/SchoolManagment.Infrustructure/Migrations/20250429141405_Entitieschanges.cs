using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Entitieschanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Departments",
                newName: "Name");
        }
    }
}
