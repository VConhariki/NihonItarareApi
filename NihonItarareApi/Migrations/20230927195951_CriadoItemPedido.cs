using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NihonItarareApi.Migrations
{
    /// <inheritdoc />
    public partial class CriadoItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Item_ItemId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ItemId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IsMateriaPrima",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Pedido",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FormaPagamento",
                table: "Pedido",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ItemId",
                table: "ItemPedido",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.AddColumn<bool>(
                name: "IsMateriaPrima",
                table: "Produto",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormaPagamento",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItemId",
                table: "Pedido",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Item_ItemId",
                table: "Pedido",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
