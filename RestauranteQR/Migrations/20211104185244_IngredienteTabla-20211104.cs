using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class IngredienteTabla20211104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Ingredientes_ingrediente1Id",
                table: "Platos");

            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Ingredientes_ingrediente2Id",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_ingrediente1Id",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_ingrediente2Id",
                table: "Platos");

            migrationBuilder.RenameColumn(
                name: "ingrediente2Id",
                table: "Platos",
                newName: "IngredienteId2");

            migrationBuilder.RenameColumn(
                name: "ingrediente1Id",
                table: "Platos",
                newName: "IngredienteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredienteId2",
                table: "Platos",
                newName: "ingrediente2Id");

            migrationBuilder.RenameColumn(
                name: "IngredienteId1",
                table: "Platos",
                newName: "ingrediente1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Platos_ingrediente1Id",
                table: "Platos",
                column: "ingrediente1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Platos_ingrediente2Id",
                table: "Platos",
                column: "ingrediente2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Ingredientes_ingrediente1Id",
                table: "Platos",
                column: "ingrediente1Id",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Ingredientes_ingrediente2Id",
                table: "Platos",
                column: "ingrediente2Id",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
