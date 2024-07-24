using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class TbDistrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Nation_IdNation",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "IdNation",
                table: "City",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    IdDistrict = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleDistrict = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.IdDistrict);
                    table.ForeignKey(
                        name: "FK_District_City_IdCity",
                        column: x => x.IdCity,
                        principalTable: "City",
                        principalColumn: "IdCity");
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_IdCity",
                table: "District",
                column: "IdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Nation_IdNation",
                table: "City",
                column: "IdNation",
                principalTable: "Nation",
                principalColumn: "IdNation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Nation_IdNation",
                table: "City");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.AlterColumn<int>(
                name: "IdNation",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Nation_IdNation",
                table: "City",
                column: "IdNation",
                principalTable: "Nation",
                principalColumn: "IdNation",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
