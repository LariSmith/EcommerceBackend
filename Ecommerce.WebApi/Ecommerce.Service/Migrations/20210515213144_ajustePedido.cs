using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Service.Migrations
{
    public partial class ajustePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    dataPedido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pedidoid = table.Column<int>(type: "int", nullable: true),
                    Produtoid = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_item_produto_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_pedidoid",
                table: "item",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_item_Produtoid",
                table: "item",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_clienteid",
                table: "pedido",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
