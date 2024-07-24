using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class TbWard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    IdWard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameWard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleWard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdDistrict = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.IdWard);
                    table.ForeignKey(
                        name: "FK_Ward_District_IdDistrict",
                        column: x => x.IdDistrict,
                        principalTable: "District",
                        principalColumn: "IdDistrict");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ward_IdDistrict",
                table: "Ward",
                column: "IdDistrict");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ward");
        }
    }
}
