using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class TbStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStudent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneStudent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailStudent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDayStudent = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IdNation = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    IdDistrict = table.Column<int>(type: "int", nullable: false),
                    IdWard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Student_City_IdCity",
                        column: x => x.IdCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_District_IdDistrict",
                        column: x => x.IdDistrict,
                        principalTable: "District",
                        principalColumn: "IdDistrict",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Nation_IdNation",
                        column: x => x.IdNation,
                        principalTable: "Nation",
                        principalColumn: "IdNation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Ward_IdWard",
                        column: x => x.IdWard,
                        principalTable: "Ward",
                        principalColumn: "IdWard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdCity",
                table: "Student",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdDistrict",
                table: "Student",
                column: "IdDistrict");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdNation",
                table: "Student",
                column: "IdNation");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdWard",
                table: "Student",
                column: "IdWard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
