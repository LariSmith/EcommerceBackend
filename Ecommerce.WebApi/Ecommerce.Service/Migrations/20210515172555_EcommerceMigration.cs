using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Service.Migrations
{
    public partial class EcommerceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estoque",
                table: "produto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estoque",
                table: "produto");
        }
    }
}
