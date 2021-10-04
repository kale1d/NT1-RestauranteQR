using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteQR.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientePorPlatos",
                table: "IngredientePorPlatos");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "IngredientePorPlatos",
                newName: "IngredientesPorPlatos");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_MesaId",
                table: "Pedidos",
                newName: "IX_Pedidos_MesaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientesPorPlatos",
                table: "IngredientesPorPlatos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesa_MesaId",
                table: "Pedidos",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesa_MesaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientesPorPlatos",
                table: "IngredientesPorPlatos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "IngredientesPorPlatos",
                newName: "IngredientePorPlatos");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedido",
                newName: "IX_Pedido_MesaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientePorPlatos",
                table: "IngredientePorPlatos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
