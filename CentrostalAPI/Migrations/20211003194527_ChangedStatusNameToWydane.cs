using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class ChangedStatusNameToWydane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "wydane");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "zrealizowane");
        }
    }
}
