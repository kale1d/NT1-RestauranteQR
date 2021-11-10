using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class migate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombrePlato",
                table: "PlatosPorPedido",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecioPlato",
                table: "PlatosPorPedido",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombrePlato",
                table: "PlatosPorPedido");

            migrationBuilder.DropColumn(
                name: "PrecioPlato",
                table: "PlatosPorPedido");
        }
    }
}
