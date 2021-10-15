using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class StatusWithPropShowPrize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "shouldShowPrize",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "shouldShowPrize",
                value: true);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "shouldShowPrize",
                value: true);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 7,
                column: "shouldShowPrize",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shouldShowPrize",
                table: "statuses");
        }
    }
}
