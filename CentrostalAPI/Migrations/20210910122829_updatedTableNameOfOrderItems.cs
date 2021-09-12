using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class updatedTableNameOfOrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_items_itemId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_orders_orderId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_orderId",
                table: "orderItems",
                newName: "IX_orderItems_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_itemId",
                table: "orderItems",
                newName: "IX_orderItems_itemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_items_itemId",
                table: "orderItems",
                column: "itemId",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_items_itemId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_orderId",
                table: "OrderItem",
                newName: "IX_OrderItem_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_itemId",
                table: "OrderItem",
                newName: "IX_OrderItem_itemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_items_itemId",
                table: "OrderItem",
                column: "itemId",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_orders_orderId",
                table: "OrderItem",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
