using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class ChangePrizeToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shouldShowPrize",
                table: "statuses",
                newName: "shouldShowPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shouldShowPrice",
                table: "statuses",
                newName: "shouldShowPrize");
        }
    }
}
