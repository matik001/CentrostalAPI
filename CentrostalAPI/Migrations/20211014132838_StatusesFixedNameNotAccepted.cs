using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class StatusesFixedNameNotAccepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "niezatwierdzone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "nie zatwierdzone");
        }
    }
}
