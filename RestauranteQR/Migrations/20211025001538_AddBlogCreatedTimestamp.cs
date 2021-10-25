using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ingrediente1Id",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ingrediente2Id",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ingrediente1Id",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "ingrediente2Id",
                table: "Platos");
        }
    }
}
