using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class UpdatesStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "odebrane");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "wydane");
        }
    }
}
