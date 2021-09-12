using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class correctedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_orderingUserId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_orderingUserId",
                table: "orders",
                column: "orderingUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_orderingUserId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_orderId",
                table: "orderItems",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_orderingUserId",
                table: "orders",
                column: "orderingUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
