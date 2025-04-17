using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Did);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Did = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Departments_Did",
                        column: x => x.Did,
                        principalTable: "Departments",
                        principalColumn: "Did");
                });

            migrationBuilder.CreateTable(
                name: "DepartmetSubject",
                columns: table => new
                {
                    DeptSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmetSubject", x => x.DeptSubID);
                    table.ForeignKey(
                        name: "FK_DepartmetSubject_Departments_DID",
                        column: x => x.DID,
                        principalTable: "Departments",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmetSubject_Subjects_SubID",
                        column: x => x.SubID,
                        principalTable: "Subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudSubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.StudSubID);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_StudID",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects_SubID",
                        column: x => x.SubID,
                        principalTable: "Subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubject_DID",
                table: "DepartmetSubject",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubject_SubID",
                table: "DepartmetSubject",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudID",
                table: "StudentSubject",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubID",
                table: "StudentSubject",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Did",
                table: "Students",
                column: "Did");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmetSubject");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
