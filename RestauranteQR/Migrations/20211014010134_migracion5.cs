using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class migracion5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platos_PedidoId",
                table: "Platos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Pedidos_PedidoId",
                table: "Platos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Pedidos_PedidoId",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_PedidoId",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Platos");
        }
    }
}
