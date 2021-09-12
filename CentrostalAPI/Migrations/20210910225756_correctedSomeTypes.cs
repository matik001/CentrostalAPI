using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class correctedSomeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemTemplateCurrents_itemTemplates_itemTemplateId",
                table: "itemTemplateCurrents");

            migrationBuilder.DropForeignKey(
                name: "FK_itemTemplateSteelTypes_itemTemplates_itemTemplateId",
                table: "itemTemplateSteelTypes");

            migrationBuilder.AlterColumn<bool>(
                name: "isOriginal",
                table: "items",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_itemTemplateCurrents_itemTemplates_itemTemplateId",
                table: "itemTemplateCurrents",
                column: "itemTemplateId",
                principalTable: "itemTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_itemTemplateSteelTypes_itemTemplates_itemTemplateId",
                table: "itemTemplateSteelTypes",
                column: "itemTemplateId",
                principalTable: "itemTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemTemplateCurrents_itemTemplates_itemTemplateId",
                table: "itemTemplateCurrents");

            migrationBuilder.DropForeignKey(
                name: "FK_itemTemplateSteelTypes_itemTemplates_itemTemplateId",
                table: "itemTemplateSteelTypes");

            migrationBuilder.AlterColumn<int>(
                name: "isOriginal",
                table: "items",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_itemTemplateCurrents_itemTemplates_itemTemplateId",
                table: "itemTemplateCurrents",
                column: "itemTemplateId",
                principalTable: "itemTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_itemTemplateSteelTypes_itemTemplates_itemTemplateId",
                table: "itemTemplateSteelTypes",
                column: "itemTemplateId",
                principalTable: "itemTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
