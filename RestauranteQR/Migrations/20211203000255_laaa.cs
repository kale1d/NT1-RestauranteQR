using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class laaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IngredientePlato",
                columns: table => new
                {
                    IngredientesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlatosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePlato", x => new { x.IngredientesId, x.PlatosId });
                    table.ForeignKey(
                        name: "FK_IngredientePlato_Ingredientes_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePlato_Platos_PlatosId",
                        column: x => x.PlatosId,
                        principalTable: "Platos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePlato_PlatosId",
                table: "IngredientePlato",
                column: "PlatosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePlato");

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
    }
}
