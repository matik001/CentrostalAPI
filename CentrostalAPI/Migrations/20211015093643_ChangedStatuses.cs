using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class ChangedStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "shouldShowPrize",
                value: true);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "shouldShowPrize",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "shouldShowPrize",
                value: false);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "shouldShowPrize",
                value: false);
        }
    }
}
