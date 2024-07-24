using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class TbCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdNation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_City_Nation_IdNation",
                        column: x => x.IdNation,
                        principalTable: "Nation",
                        principalColumn: "IdNation");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_IdNation",
                table: "City",
                column: "IdNation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

        }
    }
}
