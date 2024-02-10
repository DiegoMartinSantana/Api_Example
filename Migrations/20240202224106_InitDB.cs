using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    IdBrand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    IdBeer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBeer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.IdBeer);
                    table.ForeignKey(
                        name: "FK_Beers_Brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brands",
                        principalColumn: "IdBrand",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_IdBrand",
                table: "Beers",
                column: "IdBrand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
