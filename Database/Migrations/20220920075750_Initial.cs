using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentGUID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherGUID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCode = table.Column<int>(type: "int", nullable: false),
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookGUID);
                    table.ForeignKey(
                        name: "FK_Book_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    HomeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.HomeGUID);
                    table.ForeignKey(
                        name: "FK_Home_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentGUID, x.TeacherGUID });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teachers_TeacherGUID",
                        column: x => x.TeacherGUID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_StudentGUID",
                table: "Book",
                column: "StudentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Home_StudentGUID",
                table: "Home",
                column: "StudentGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeacherGUID",
                table: "StudentTeacher",
                column: "TeacherGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
