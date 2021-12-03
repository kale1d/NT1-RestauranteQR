using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class miraOtra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlatoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PlatoId",
                table: "Ingredientes",
                column: "PlatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes",
                column: "PlatoId",
                principalTable: "Platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_PlatoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "PlatoId",
                table: "Ingredientes");
        }
    }
}
