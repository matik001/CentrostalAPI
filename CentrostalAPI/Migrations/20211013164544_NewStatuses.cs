using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class NewStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "edytowalne");

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 5, "utworzone" },
                    { 6, "zapytane" },
                    { 7, "nie zatwierdzone" },
                    { 8, "zatwierdzone" },
                    { 9, "zamówione" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "zlecone");
        }
    }
}
