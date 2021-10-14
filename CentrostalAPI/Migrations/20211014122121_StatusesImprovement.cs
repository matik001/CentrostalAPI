using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class StatusesImprovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "canAdminCancel",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canAdminChangeStatus",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canAdminEdit",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canAnyoneCancel",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canAnyoneChangeStatus",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canAnyoneEdit",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canChairmanCancel",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canChairmanChangeStatus",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "canChairmanEdit",
                table: "statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "statuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nextStatusId",
                table: "statuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nextStatusMsg",
                table: "statuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "canAnyoneCancel", "canAnyoneChangeStatus", "canAnyoneEdit", "canChairmanCancel", "canChairmanChangeStatus", "canChairmanEdit", "color", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, true, true, true, true, true, true, "#999966", 2, "Przekaż dalej" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, "#99cc00", "utworzone", 3, "Oznacz jako zapytane" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, "#cc66ff", "zapytane", 4, "Przekaż do zatwierdzenia" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "canAdminCancel", "canAdminEdit", "canChairmanCancel", "canChairmanChangeStatus", "canChairmanEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, true, true, "#ff6600", "nie zatwierdzone", 5, "Zatwierdź" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, "#33cc33", "zatwierdzone", 6, "Oznacz jako zamówione" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, "#0066cc", "zamówione", 7, "Przyjmuję towar" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "color", "name" },
                values: new object[] { "#009933", "zrealizowane" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "color", "name" },
                values: new object[] { "#cc0000", "anulowane" });

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "canAnyoneCancel", "canAnyoneChangeStatus", "canAnyoneEdit", "canChairmanCancel", "canChairmanChangeStatus", "canChairmanEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { true, true, true, true, true, true, true, true, true, "#999966", "edytowalne", 10, "Wydaj" });

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "id", "canAdminCancel", "canAdminChangeStatus", "canAdminEdit", "canAnyoneCancel", "canAnyoneChangeStatus", "canAnyoneEdit", "canChairmanCancel", "canChairmanChangeStatus", "canChairmanEdit", "color", "name", "nextStatusId", "nextStatusMsg" },
                values: new object[] { 10, false, false, false, false, false, false, false, false, false, "#009933", "wydane", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "canAdminCancel",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canAdminChangeStatus",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canAdminEdit",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canAnyoneCancel",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canAnyoneChangeStatus",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canAnyoneEdit",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canChairmanCancel",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canChairmanChangeStatus",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "canChairmanEdit",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "color",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "nextStatusId",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "nextStatusMsg",
                table: "statuses");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "wydane");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "anulowane");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "zrealizowane");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "utworzone");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "zapytane");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "nie zatwierdzone");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "zatwierdzone");

            migrationBuilder.UpdateData(
                table: "statuses",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "zamówione");
        }
    }
}
