using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Service.Migrations
{
    public partial class chaveComposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_pedido_pedidoid",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_item_produto_Produtoid",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_clienteid",
                table: "pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropIndex(
                name: "IX_item_pedidoid",
                table: "item");

            migrationBuilder.DropColumn(
                name: "id",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "pedido",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_clienteid",
                table: "pedido",
                newName: "IX_pedido_clienteId");

            migrationBuilder.RenameColumn(
                name: "pedidoid",
                table: "item",
                newName: "pedidoId");

            migrationBuilder.RenameColumn(
                name: "Produtoid",
                table: "item",
                newName: "produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_item_Produtoid",
                table: "item",
                newName: "IX_item_produtoId");

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pedidoId",
                table: "pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "pedidoId",
                table: "item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "produtoId",
                table: "item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                columns: new[] { "pedidoId", "produtoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_item_pedido_pedidoId",
                table: "item",
                column: "pedidoId",
                principalTable: "pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_produto_produtoId",
                table: "item",
                column: "produtoId",
                principalTable: "produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_clienteId",
                table: "pedido",
                column: "clienteId",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_pedido_pedidoId",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_item_produto_produtoId",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_clienteId",
                table: "pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropColumn(
                name: "pedidoId",
                table: "pedido");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "pedido",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_clienteId",
                table: "pedido",
                newName: "IX_pedido_clienteid");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "item",
                newName: "Produtoid");

            migrationBuilder.RenameColumn(
                name: "pedidoId",
                table: "item",
                newName: "pedidoid");

            migrationBuilder.RenameIndex(
                name: "IX_item_produtoId",
                table: "item",
                newName: "IX_item_Produtoid");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Produtoid",
                table: "item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoid",
                table: "item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "item",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_item_pedidoid",
                table: "item",
                column: "pedidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_item_pedido_pedidoid",
                table: "item",
                column: "pedidoid",
                principalTable: "pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_item_produto_Produtoid",
                table: "item",
                column: "Produtoid",
                principalTable: "produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_clienteid",
                table: "pedido",
                column: "clienteid",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
