using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class BrandIDForeigKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brands_IdBrand",
                table: "Beers");

            migrationBuilder.RenameColumn(
                name: "IdBrand",
                table: "Beers",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Beers_IdBrand",
                table: "Beers",
                newName: "IX_Beers_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brands_BrandId",
                table: "Beers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "IdBrand",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brands_BrandId",
                table: "Beers");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Beers",
                newName: "IdBrand");

            migrationBuilder.RenameIndex(
                name: "IX_Beers_BrandId",
                table: "Beers",
                newName: "IX_Beers_IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brands_IdBrand",
                table: "Beers",
                column: "IdBrand",
                principalTable: "Brands",
                principalColumn: "IdBrand",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
