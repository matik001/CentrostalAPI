using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations {
    public partial class AddedMinStock : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int>(
                name: "minStock",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "minStock",
                table: "items");
        }
    }
}
