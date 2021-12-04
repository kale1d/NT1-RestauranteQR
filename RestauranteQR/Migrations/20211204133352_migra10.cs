using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class migra10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredienteId1",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "IngredienteId2",
                table: "Platos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredienteId1",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredienteId2",
                table: "Platos",
                type: "INTEGER",
                nullable: true);
        }
    }
}
