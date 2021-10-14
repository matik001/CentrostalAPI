using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class StatusesAddedshouldUpdateAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "shouldUpdateAmount",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 7,
                column: "shouldUpdateAmount",
                value: true);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 10,
                column: "shouldUpdateAmount",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shouldUpdateAmount",
                table: "statuses");
        }
    }
}
