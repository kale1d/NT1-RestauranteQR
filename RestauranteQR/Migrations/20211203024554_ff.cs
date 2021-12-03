using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePlato_Ingredientes_IngredientesId",
                table: "IngredientePlato");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePlato_Platos_PlatosId",
                table: "IngredientePlato");

            migrationBuilder.DropTable(
                name: "IngredientesPorPlatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientePlato",
                table: "IngredientePlato");

            migrationBuilder.DropIndex(
                name: "IX_IngredientePlato_PlatosId",
                table: "IngredientePlato");

            migrationBuilder.RenameColumn(
                name: "PlatosId",
                table: "IngredientePlato",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IngredientesId",
                table: "IngredientePlato",
                newName: "PlatoId");

            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "IngredientePlato",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientePlato",
                table: "IngredientePlato",
                columns: new[] { "IngredienteId", "PlatoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Platos_IngredienteId",
                table: "Platos",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePlato_PlatoId",
                table: "IngredientePlato",
                column: "PlatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePlato_Ingredientes_IngredienteId",
                table: "IngredientePlato",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePlato_Platos_PlatoId",
                table: "IngredientePlato",
                column: "PlatoId",
                principalTable: "Platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Ingredientes_IngredienteId",
                table: "Platos",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePlato_Ingredientes_IngredienteId",
                table: "IngredientePlato");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePlato_Platos_PlatoId",
                table: "IngredientePlato");

            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Ingredientes_IngredienteId",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_IngredienteId",
                table: "Platos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientePlato",
                table: "IngredientePlato");

            migrationBuilder.DropIndex(
                name: "IX_IngredientePlato_PlatoId",
                table: "IngredientePlato");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "IngredientePlato");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IngredientePlato",
                newName: "PlatosId");

            migrationBuilder.RenameColumn(
                name: "PlatoId",
                table: "IngredientePlato",
                newName: "IngredientesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientePlato",
                table: "IngredientePlato",
                columns: new[] { "IngredientesId", "PlatosId" });

            migrationBuilder.CreateTable(
                name: "IngredientesPorPlatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlatoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesPorPlatos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePlato_PlatosId",
                table: "IngredientePlato",
                column: "PlatosId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePlato_Ingredientes_IngredientesId",
                table: "IngredientePlato",
                column: "IngredientesId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePlato_Platos_PlatosId",
                table: "IngredientePlato",
                column: "PlatosId",
                principalTable: "Platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
