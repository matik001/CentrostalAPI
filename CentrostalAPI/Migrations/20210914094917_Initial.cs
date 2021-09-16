using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrostalAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "steelTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steelTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    current = table.Column<int>(type: "int", nullable: false),
                    isOriginal = table.Column<bool>(type: "bit", nullable: false),
                    steelTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_items_steelTypes_steelTypeId",
                        column: x => x.steelTypeId,
                        principalTable: "steelTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    executedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    orderingUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_statuses_statusId",
                        column: x => x.statusId,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_users_orderingUserId",
                        column: x => x.orderingUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    amountDelta = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderItems_items_itemId",
                        column: x => x.itemId,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "zlecone" },
                    { 2, "zrealizowane" },
                    { 3, "anulowane" }
                });

            migrationBuilder.InsertData(
                table: "steelTypes",
                columns: new[] { "id", "typeName" },
                values: new object[,]
                {
                    { 1, "Stal miękka" },
                    { 2, "Stal miękka - Bevel" },
                    { 3, "Stal nierdzewna" },
                    { 4, "Stal nierdzewna - Bevel" },
                    { 5, "Aluminium" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 1, 0, 30, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 255, 0, 400, true, "DYSZA", 220708, 3 },
                    { 254, 0, 400, false, "NASADKA DYSZY", 220712, 3 },
                    { 253, 0, 400, true, "NASADKA DYSZY", 220712, 3 },
                    { 252, 0, 400, false, "OSŁONA", 220707, 3 },
                    { 251, 0, 400, true, "OSŁONA", 220707, 3 },
                    { 250, 0, 400, false, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 249, 0, 400, true, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 248, 0, 260, false, "RURKA WODNA", 220340, 3 },
                    { 247, 0, 260, true, "RURKA WODNA", 220340, 3 },
                    { 246, 0, 260, false, "ELEKTRODA", 220307, 3 },
                    { 245, 0, 260, true, "ELEKTRODA", 220307, 3 },
                    { 244, 0, 260, false, "PIERŚCIEŃ ZAWIR.", 220405, 3 },
                    { 243, 0, 260, true, "PIERŚCIEŃ ZAWIR.", 220405, 3 },
                    { 242, 0, 260, false, "DYSZA", 220406, 3 },
                    { 241, 0, 260, true, "DYSZA", 220406, 3 },
                    { 240, 0, 260, false, "NASADKA DYSZY", 220758, 3 },
                    { 239, 0, 260, true, "NASADKA DYSZY", 220758, 3 },
                    { 238, 0, 260, false, "OSŁONA", 220763, 3 },
                    { 237, 0, 260, true, "OSŁONA", 220763, 3 },
                    { 256, 0, 400, false, "DYSZA", 220708, 3 },
                    { 236, 0, 260, false, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 257, 0, 400, true, "PIERŚCIEŃ ZAWIR.", 220405, 3 },
                    { 259, 0, 400, true, "ELEKTRODA", 220709, 3 },
                    { 278, 0, 260, false, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 277, 0, 260, true, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 276, 0, 130, false, "RURKA WODNA", 220571, 4 },
                    { 275, 0, 130, true, "RURKA WODNA", 220571, 4 },
                    { 274, 0, 130, false, "ELEKTRODA", 220606, 4 },
                    { 273, 0, 130, true, "ELEKTRODA", 220606, 4 },
                    { 272, 0, 130, false, "PIERŚCIEŃ ZAWIR.", 220179, 4 },
                    { 271, 0, 130, true, "PIERŚCIEŃ ZAWIR.", 220179, 4 },
                    { 270, 0, 130, false, "DYSZA", 220656, 4 },
                    { 269, 0, 130, true, "DYSZA", 220656, 4 },
                    { 268, 0, 130, false, "NASADKA DYSZY", 220739, 4 },
                    { 267, 0, 130, true, "NASADKA DYSZY", 220739, 4 },
                    { 266, 0, 130, false, "OSŁONA", 220738, 4 },
                    { 265, 0, 130, true, "OSŁONA", 220738, 4 },
                    { 264, 0, 130, false, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 263, 0, 130, true, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 262, 0, 400, false, "RURKA WODNA", 220571, 3 },
                    { 261, 0, 400, true, "RURKA WODNA", 220571, 3 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 260, 0, 400, false, "ELEKTRODA", 220709, 3 },
                    { 258, 0, 400, false, "PIERŚCIEŃ ZAWIR.", 220405, 3 },
                    { 235, 0, 260, true, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 234, 0, 200, false, "RURKA WODNA", 220340, 3 },
                    { 233, 0, 200, true, "RURKA WODNA", 220340, 3 },
                    { 208, 0, 130, false, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 207, 0, 130, true, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 206, 0, 80, false, "RURKA WODNA", 220340, 3 },
                    { 205, 0, 80, true, "RURKA WODNA", 220340, 3 },
                    { 204, 0, 80, false, "ELEKTRODA", 220339, 3 },
                    { 203, 0, 80, true, "ELEKTRODA", 220339, 3 },
                    { 202, 0, 80, false, "PIERŚCIEŃ ZAWIR.", 220179, 3 },
                    { 201, 0, 80, true, "PIERŚCIEŃ ZAWIR.", 220179, 3 },
                    { 200, 0, 80, false, "DYSZA", 220337, 3 },
                    { 199, 0, 80, true, "DYSZA", 220337, 3 },
                    { 198, 0, 80, false, "NASADKA DYSZY", 220755, 3 },
                    { 197, 0, 80, true, "NASADKA DYSZY", 220755, 3 },
                    { 196, 0, 80, false, "OSŁONA", 220338, 3 },
                    { 195, 0, 80, true, "OSŁONA", 220338, 3 },
                    { 194, 0, 80, false, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 193, 0, 80, true, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 192, 0, 60, false, "RURKA WODNA", 220340, 3 },
                    { 191, 0, 60, true, "RURKA WODNA", 220340, 3 },
                    { 190, 0, 60, false, "ELEKTRODA", 220339, 3 },
                    { 209, 0, 130, true, "OSŁONA", 220198, 3 },
                    { 210, 0, 130, false, "OSŁONA", 220198, 3 },
                    { 211, 0, 130, true, "NASADKA DYSZY", 220755, 3 },
                    { 212, 0, 130, false, "NASADKA DYSZY", 220755, 3 },
                    { 232, 0, 200, false, "ELEKTRODA", 220307, 3 },
                    { 231, 0, 200, true, "ELEKTRODA", 220307, 3 },
                    { 230, 0, 200, false, "PIERŚCIEŃ ZAWIR.", 220342, 3 },
                    { 229, 0, 200, true, "PIERŚCIEŃ ZAWIR.", 220342, 3 },
                    { 228, 0, 200, false, "DYSZA", 220343, 3 },
                    { 227, 0, 200, true, "DYSZA", 220343, 3 },
                    { 226, 0, 200, false, "NASADKA DYSZY", 220758, 3 },
                    { 225, 0, 200, true, "NASADKA DYSZY", 220758, 3 },
                    { 224, 0, 200, false, "OSŁONA", 220762, 3 },
                    { 279, 0, 260, true, "OSŁONA", 220738, 4 },
                    { 223, 0, 200, true, "OSŁONA", 220762, 3 },
                    { 221, 0, 200, true, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 220, 0, 130, false, "RURKA WODNA", 220340, 3 },
                    { 219, 0, 130, true, "RURKA WODNA", 220340, 3 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 218, 0, 130, false, "ELEKTRODA", 220307, 3 },
                    { 217, 0, 130, true, "ELEKTRODA", 220307, 3 },
                    { 216, 0, 130, false, "PIERŚCIEŃ ZAWIR.", 220179, 3 },
                    { 215, 0, 130, true, "PIERŚCIEŃ ZAWIR.", 220179, 3 },
                    { 214, 0, 130, false, "DYSZA", 220197, 3 },
                    { 213, 0, 130, true, "DYSZA", 220197, 3 },
                    { 222, 0, 200, false, "TARCZA OSŁANIAJĄCA", 220637, 3 },
                    { 280, 0, 260, false, "OSŁONA", 220738, 4 },
                    { 281, 0, 260, true, "NASADKA DYSZY", 220739, 4 },
                    { 282, 0, 260, false, "NASADKA DYSZY", 220739, 4 },
                    { 348, 0, 260, false, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 347, 0, 260, true, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 346, 0, 200, false, "RURKA WODNA", 220340, 5 },
                    { 345, 0, 200, true, "RURKA WODNA", 220340, 5 },
                    { 344, 0, 200, false, "ELEKTRODA", 220307, 5 },
                    { 343, 0, 200, true, "ELEKTRODA", 220307, 5 },
                    { 342, 0, 200, false, "PIERŚCIEŃ ZAWIR.", 220342, 5 },
                    { 341, 0, 200, true, "PIERŚCIEŃ ZAWIR.", 220342, 5 },
                    { 340, 0, 200, false, "DYSZA", 220346, 5 },
                    { 339, 0, 200, true, "DYSZA", 220346, 5 },
                    { 338, 0, 200, false, "NASADKA DYSZY", 220759, 5 },
                    { 337, 0, 200, true, "NASADKA DYSZY", 220759, 5 },
                    { 336, 0, 200, false, "OSŁONA", 220762, 5 },
                    { 335, 0, 200, true, "OSŁONA", 220762, 5 },
                    { 334, 0, 200, false, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 333, 0, 200, true, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 332, 0, 130, false, "RURKA WODNA", 220340, 5 },
                    { 331, 0, 130, true, "RURKA WODNA", 220340, 5 },
                    { 330, 0, 130, false, "ELEKTRODA", 440488, 5 },
                    { 349, 0, 260, true, "OSŁONA", 220763, 5 },
                    { 350, 0, 260, false, "OSŁONA", 220763, 5 },
                    { 351, 0, 260, true, "NASADKA DYSZY", 220758, 5 },
                    { 352, 0, 260, false, "NASADKA DYSZY", 220758, 5 },
                    { 372, 0, 400, false, "ELEKTRODA", 220709, 5 },
                    { 371, 0, 400, true, "ELEKTRODA", 220709, 5 },
                    { 370, 0, 400, false, "PIERŚCIEŃ ZAWIR.", 220405, 5 },
                    { 369, 0, 400, true, "PIERŚCIEŃ ZAWIR.", 220405, 5 },
                    { 368, 0, 400, false, "DYSZA", 220708, 5 },
                    { 367, 0, 400, true, "DYSZA", 220708, 5 },
                    { 366, 0, 400, false, "NASADKA DYSZY", 220712, 5 },
                    { 365, 0, 400, true, "NASADKA DYSZY", 220712, 5 },
                    { 364, 0, 400, false, "OSŁONA", 220707, 5 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 329, 0, 130, true, "ELEKTRODA", 440488, 5 },
                    { 363, 0, 400, true, "OSŁONA", 220707, 5 },
                    { 361, 0, 400, true, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 360, 0, 260, false, "RURKA WODNA", 220340, 5 },
                    { 359, 0, 260, true, "RURKA WODNA", 220340, 5 },
                    { 358, 0, 260, false, "ELEKTRODA", 220307, 5 },
                    { 357, 0, 260, true, "ELEKTRODA", 220307, 5 },
                    { 356, 0, 260, false, "PIERŚCIEŃ ZAWIR.", 220405, 5 },
                    { 355, 0, 260, true, "PIERŚCIEŃ ZAWIR.", 220405, 5 },
                    { 354, 0, 260, false, "DYSZA", 220406, 5 },
                    { 353, 0, 260, true, "DYSZA", 220406, 5 },
                    { 362, 0, 400, false, "TARCZA OSŁANIAJĄCA", 220637, 5 },
                    { 189, 0, 60, true, "ELEKTRODA", 220339, 3 },
                    { 328, 0, 130, false, "PIERŚCIEŃ ZAWIR.", 220179, 5 },
                    { 326, 0, 130, false, "DYSZA", 220197, 5 },
                    { 301, 0, 400, true, "ELEKTRODA", 220709, 4 },
                    { 300, 0, 400, false, "PIERŚCIEŃ ZAWIR.", 220405, 4 },
                    { 299, 0, 400, true, "PIERŚCIEŃ ZAWIR.", 220405, 4 },
                    { 298, 0, 400, false, "DYSZA", 220708, 4 },
                    { 297, 0, 400, true, "DYSZA", 220708, 4 },
                    { 296, 0, 400, false, "NASADKA DYSZY", 220712, 4 },
                    { 295, 0, 400, true, "NASADKA DYSZY", 220712, 4 },
                    { 294, 0, 400, false, "OSŁONA", 220707, 4 },
                    { 293, 0, 400, true, "OSŁONA", 220707, 4 },
                    { 292, 0, 400, false, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 291, 0, 400, true, "TARCZA OSŁANIAJĄCA", 220637, 4 },
                    { 290, 0, 260, false, "RURKA WODNA", 220571, 4 },
                    { 289, 0, 260, true, "RURKA WODNA", 220571, 4 },
                    { 288, 0, 260, false, "ELEKTRODA", 220606, 4 },
                    { 287, 0, 260, true, "ELEKTRODA", 220606, 4 },
                    { 286, 0, 260, false, "PIERŚCIEŃ ZAWIR.", 220405, 4 },
                    { 285, 0, 260, true, "PIERŚCIEŃ ZAWIR.", 220405, 4 },
                    { 284, 0, 260, false, "DYSZA", 220607, 4 },
                    { 283, 0, 260, true, "DYSZA", 220607, 4 },
                    { 302, 0, 400, false, "ELEKTRODA", 220709, 4 },
                    { 303, 0, 400, true, "RURKA WODNA", 220571, 4 },
                    { 304, 0, 400, false, "RURKA WODNA", 220571, 4 },
                    { 305, 0, 45, true, "TARCZA OSŁANIAJĄCA", 220747, 5 },
                    { 325, 0, 130, true, "DYSZA", 220197, 5 },
                    { 324, 0, 130, false, "NASADKA DYSZY", 220755, 5 },
                    { 323, 0, 130, true, "NASADKA DYSZY", 220755, 5 },
                    { 322, 0, 130, false, "OSŁONA", 220198, 5 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 321, 0, 130, true, "OSŁONA", 220198, 5 },
                    { 320, 0, 130, false, "TARCZA OSŁANIAJĄCA", 220747, 5 },
                    { 319, 0, 130, true, "TARCZA OSŁANIAJĄCA", 220747, 5 },
                    { 318, 0, 45, false, "RURKA WODNA", 220340, 5 },
                    { 317, 0, 45, true, "RURKA WODNA", 220340, 5 },
                    { 327, 0, 130, true, "PIERŚCIEŃ ZAWIR.", 220179, 5 },
                    { 316, 0, 45, false, "ELEKTRODA", 220308, 5 },
                    { 314, 0, 45, false, "PIERŚCIEŃ ZAWIR.", 220180, 5 },
                    { 313, 0, 45, true, "PIERŚCIEŃ ZAWIR.", 220180, 5 },
                    { 312, 0, 45, false, "DYSZA", 220201, 5 },
                    { 311, 0, 45, true, "DYSZA", 220201, 5 },
                    { 310, 0, 45, false, "NASADKA DYSZY", 220756, 5 },
                    { 309, 0, 45, true, "NASADKA DYSZY", 220756, 5 },
                    { 308, 0, 45, false, "OSŁONA", 220202, 5 },
                    { 307, 0, 45, true, "OSŁONA", 220202, 5 },
                    { 306, 0, 45, false, "TARCZA OSŁANIAJĄCA", 220747, 5 },
                    { 315, 0, 45, true, "ELEKTRODA", 220308, 5 },
                    { 188, 0, 60, false, "PIERŚCIEŃ ZAWIR.", 220180, 3 },
                    { 187, 0, 60, true, "PIERŚCIEŃ ZAWIR.", 220180, 3 },
                    { 186, 0, 60, false, "DYSZA", 220847, 3 },
                    { 67, 0, 200, true, "DYSZA", 220188, 1 },
                    { 66, 0, 200, false, "NASADKA DYSZY", 220756, 1 },
                    { 65, 0, 200, true, "NASADKA DYSZY", 220756, 1 },
                    { 64, 0, 200, false, "OSŁONA", 220189, 1 },
                    { 63, 0, 200, true, "OSŁONA", 220189, 1 },
                    { 62, 0, 200, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 61, 0, 200, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 60, 0, 130, false, "RURKA WODNA", 220340, 1 },
                    { 59, 0, 130, true, "RURKA WODNA", 220340, 1 },
                    { 58, 0, 130, false, "ELEKTRODA SILVER", 220566, 1 },
                    { 57, 0, 130, true, "ELEKTRODA SILVER", 220566, 1 },
                    { 56, 0, 130, false, "ELEKTRODA", 220187, 1 },
                    { 55, 0, 130, true, "ELEKTRODA", 220187, 1 },
                    { 54, 0, 130, false, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 53, 0, 130, true, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 52, 0, 130, false, "DYSZA", 220188, 1 },
                    { 51, 0, 130, true, "DYSZA", 220188, 1 },
                    { 50, 0, 130, false, "NASADKA DYSZY", 220756, 1 },
                    { 49, 0, 130, true, "NASADKA DYSZY", 220756, 1 },
                    { 68, 0, 200, false, "DYSZA", 220188, 1 },
                    { 69, 0, 200, true, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 70, 0, 200, false, "PIERŚCIEŃ ZAWIR.", 220179, 1 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 71, 0, 200, true, "ELEKTRODA", 220187, 1 },
                    { 91, 0, 260, true, "RURKA WODNA", 220340, 1 },
                    { 90, 0, 260, false, "ELEKTRODA SILVER", 220566, 1 },
                    { 89, 0, 260, true, "ELEKTRODA SILVER", 220566, 1 },
                    { 88, 0, 260, false, "ELEKTRODA", 220187, 1 },
                    { 87, 0, 260, true, "ELEKTRODA", 220187, 1 },
                    { 86, 0, 260, false, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 85, 0, 260, true, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 84, 0, 260, false, "DYSZA", 220188, 1 },
                    { 83, 0, 260, true, "DYSZA", 220188, 1 },
                    { 48, 0, 130, false, "OSŁONA", 220189, 1 },
                    { 82, 0, 260, false, "NASADKA DYSZY", 220756, 1 },
                    { 80, 0, 260, false, "OSŁONA", 220189, 1 },
                    { 79, 0, 260, true, "OSŁONA", 220189, 1 },
                    { 78, 0, 260, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 77, 0, 260, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 76, 0, 200, false, "RURKA WODNA", 220340, 1 },
                    { 75, 0, 200, true, "RURKA WODNA", 220340, 1 },
                    { 74, 0, 200, false, "ELEKTRODA SILVER", 220566, 1 },
                    { 73, 0, 200, true, "ELEKTRODA SILVER", 220566, 1 },
                    { 72, 0, 200, false, "ELEKTRODA", 220187, 1 },
                    { 81, 0, 260, true, "NASADKA DYSZY", 220756, 1 },
                    { 92, 0, 260, false, "RURKA WODNA", 220340, 1 },
                    { 47, 0, 130, true, "OSŁONA", 220189, 1 },
                    { 45, 0, 130, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 20, 0, 50, false, "NASADKA DYSZY", 220754, 1 },
                    { 19, 0, 50, true, "NASADKA DYSZY", 220754, 1 },
                    { 18, 0, 50, false, "OSŁONA", 220555, 1 },
                    { 17, 0, 50, true, "OSŁONA", 220555, 1 },
                    { 16, 0, 50, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 15, 0, 50, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 14, 0, 30, false, "RURKA WODNA", 220340, 1 },
                    { 13, 0, 30, true, "RURKA WODNA", 220340, 1 },
                    { 12, 0, 30, false, "ELEKTRODA", 220192, 1 },
                    { 11, 0, 30, true, "ELEKTRODA", 220192, 1 },
                    { 10, 0, 30, false, "PIERŚCIEŃ ZAWIR.", 220180, 1 },
                    { 9, 0, 30, true, "PIERŚCIEŃ ZAWIR.", 220180, 1 },
                    { 8, 0, 30, false, "DYSZA", 220193, 1 },
                    { 7, 0, 30, true, "DYSZA", 220193, 1 },
                    { 6, 0, 30, false, "NASADKA DYSZY", 220754, 1 },
                    { 5, 0, 30, true, "NASADKA DYSZY", 220754, 1 },
                    { 4, 0, 30, false, "OSŁONA", 220194, 1 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 3, 0, 30, true, "OSŁONA", 220194, 1 },
                    { 2, 0, 30, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 21, 0, 50, true, "DYSZA", 220554, 1 },
                    { 22, 0, 50, false, "DYSZA", 220554, 1 },
                    { 23, 0, 50, true, "PIERŚCIEŃ ZAWIR.", 220553, 1 },
                    { 24, 0, 50, false, "PIERŚCIEŃ ZAWIR.", 220553, 1 },
                    { 44, 0, 80, false, "RURKA WODNA", 220340, 1 },
                    { 43, 0, 80, true, "RURKA WODNA", 220340, 1 },
                    { 42, 0, 80, false, "ELEKTRODA SILVER", 220566, 1 },
                    { 41, 0, 80, true, "ELEKTRODA SILVER", 220566, 1 },
                    { 40, 0, 80, false, "ELEKTRODA", 220187, 1 },
                    { 39, 0, 80, true, "ELEKTRODA", 220187, 1 },
                    { 38, 0, 80, false, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 37, 0, 80, true, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 36, 0, 80, false, "DYSZA", 220188, 1 },
                    { 46, 0, 130, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 35, 0, 80, true, "DYSZA", 220188, 1 },
                    { 33, 0, 80, true, "NASADKA DYSZY", 220756, 1 },
                    { 32, 0, 80, false, "OSŁONA", 220189, 1 },
                    { 31, 0, 80, true, "OSŁONA", 220189, 1 },
                    { 30, 0, 80, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 29, 0, 80, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 28, 0, 50, false, "RURKA WODNA", 220340, 1 },
                    { 27, 0, 50, true, "RURKA WODNA", 220340, 1 },
                    { 26, 0, 50, false, "ELEKTRODA", 220552, 1 },
                    { 25, 0, 50, true, "ELEKTRODA", 220552, 1 },
                    { 34, 0, 80, false, "NASADKA DYSZY", 220756, 1 },
                    { 373, 0, 400, true, "RURKA WODNA", 220571, 5 },
                    { 93, 0, 400, true, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 95, 0, 400, true, "OSŁONA", 220189, 1 },
                    { 161, 0, 260, true, "ELEKTRODA", 220541, 2 },
                    { 160, 0, 260, false, "PIERŚCIEŃ ZAWIR.", 220436, 2 },
                    { 159, 0, 260, true, "PIERŚCIEŃ ZAWIR.", 220436, 2 },
                    { 158, 0, 260, false, "DYSZA", 220542, 2 },
                    { 157, 0, 260, true, "DYSZA", 220542, 2 },
                    { 156, 0, 260, false, "NASADKA DYSZY", 220740, 2 },
                    { 155, 0, 260, true, "NASADKA DYSZY", 220740, 2 },
                    { 154, 0, 260, false, "OSŁONA", 220741, 2 },
                    { 153, 0, 260, true, "OSŁONA", 220741, 2 },
                    { 152, 0, 260, false, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 151, 0, 260, true, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 150, 0, 200, false, "RURKA WODNA", 220700, 2 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 149, 0, 200, true, "RURKA WODNA", 220700, 2 },
                    { 148, 0, 200, false, "ELEKTRODA", 220662, 2 },
                    { 147, 0, 200, true, "ELEKTRODA", 220662, 2 },
                    { 146, 0, 200, false, "PIERŚCIEŃ ZAWIR.", 220353, 2 },
                    { 145, 0, 200, true, "PIERŚCIEŃ ZAWIR.", 220353, 2 },
                    { 144, 0, 200, false, "DYSZA", 220659, 2 },
                    { 143, 0, 200, true, "DYSZA", 220659, 2 },
                    { 162, 0, 260, false, "ELEKTRODA", 220541, 2 },
                    { 163, 0, 260, true, "RURKA WODNA", 220571, 2 },
                    { 164, 0, 260, false, "RURKA WODNA", 220571, 2 },
                    { 165, 0, 45, true, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 185, 0, 60, true, "DYSZA", 220847, 3 },
                    { 184, 0, 60, false, "NASADKA DYSZY", 220814, 3 },
                    { 183, 0, 60, true, "NASADKA DYSZY", 220814, 3 },
                    { 182, 0, 60, false, "OSŁONA", 220815, 3 },
                    { 181, 0, 60, true, "OSŁONA", 220815, 3 },
                    { 180, 0, 60, false, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 179, 0, 60, true, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 178, 0, 45, false, "RURKA WODNA", 220340, 3 },
                    { 177, 0, 45, true, "RURKA WODNA", 220340, 3 },
                    { 142, 0, 200, false, "NASADKA DYSZY", 220845, 2 },
                    { 176, 0, 45, false, "ELEKTRODA", 220308, 3 },
                    { 174, 0, 45, false, "PIERŚCIEŃ ZAWIR.", 220180, 3 },
                    { 173, 0, 45, true, "PIERŚCIEŃ ZAWIR.", 220180, 3 },
                    { 172, 0, 45, false, "DYSZA", 220201, 3 },
                    { 171, 0, 45, true, "DYSZA", 220201, 3 },
                    { 170, 0, 45, false, "NASADKA DYSZY", 220755, 3 },
                    { 169, 0, 45, true, "NASADKA DYSZY", 220755, 3 },
                    { 168, 0, 45, false, "OSŁONA", 220202, 3 },
                    { 167, 0, 45, true, "OSŁONA", 220202, 3 },
                    { 166, 0, 45, false, "TARCZA OSŁANIAJĄCA", 220747, 3 },
                    { 175, 0, 45, true, "ELEKTRODA", 220308, 3 },
                    { 94, 0, 400, false, "TARCZA OSŁANIAJĄCA", 220747, 1 },
                    { 141, 0, 200, true, "NASADKA DYSZY", 220845, 2 },
                    { 139, 0, 200, true, "OSŁONA", 220658, 2 },
                    { 114, 0, 80, false, "NASADKA DYSZY", 220845, 2 },
                    { 113, 0, 80, true, "NASADKA DYSZY", 220845, 2 },
                    { 112, 0, 80, false, "OSŁONA", 220742, 2 },
                    { 111, 0, 80, true, "OSŁONA", 220742, 2 },
                    { 110, 0, 80, false, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 109, 0, 80, true, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 108, 0, 400, false, "RURKA WODNA", 220571, 1 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "id", "amount", "current", "isOriginal", "name", "number", "steelTypeId" },
                values: new object[,]
                {
                    { 107, 0, 400, true, "RURKA WODNA", 220571, 1 },
                    { 106, 0, 400, false, "ELEKTRODA SILVER", 220566, 1 },
                    { 105, 0, 400, true, "ELEKTRODA SILVER", 220566, 1 },
                    { 104, 0, 400, false, "ELEKTRODA", 220187, 1 },
                    { 103, 0, 400, true, "ELEKTRODA", 220187, 1 },
                    { 102, 0, 400, false, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 101, 0, 400, true, "PIERŚCIEŃ ZAWIR.", 220179, 1 },
                    { 100, 0, 400, false, "DYSZA", 220188, 1 },
                    { 99, 0, 400, true, "DYSZA", 220188, 1 },
                    { 98, 0, 400, false, "NASADKA DYSZY", 220756, 1 },
                    { 97, 0, 400, true, "NASADKA DYSZY", 220756, 1 },
                    { 96, 0, 400, false, "OSŁONA", 220189, 1 },
                    { 115, 0, 80, true, "DYSZA", 220806, 2 },
                    { 116, 0, 80, false, "DYSZA", 220806, 2 },
                    { 117, 0, 80, true, "PIERŚCIEŃ ZAWIR.", 220179, 2 },
                    { 118, 0, 80, false, "PIERŚCIEŃ ZAWIR.", 220179, 2 },
                    { 138, 0, 200, false, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 137, 0, 200, true, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 136, 0, 130, false, "RURKA WODNA", 220700, 2 },
                    { 135, 0, 130, true, "RURKA WODNA", 220700, 2 },
                    { 134, 0, 130, false, "ELEKTRODA", 220649, 2 },
                    { 133, 0, 130, true, "ELEKTRODA", 220649, 2 },
                    { 132, 0, 130, false, "PIERŚCIEŃ ZAWIR.", 220179, 2 },
                    { 131, 0, 130, true, "PIERŚCIEŃ ZAWIR.", 220179, 2 },
                    { 130, 0, 130, false, "DYSZA", 220646, 2 },
                    { 140, 0, 200, false, "OSŁONA", 220658, 2 },
                    { 129, 0, 130, true, "DYSZA", 220646, 2 },
                    { 127, 0, 130, true, "NASADKA DYSZY", 220740, 2 },
                    { 126, 0, 130, false, "OSŁONA", 220742, 2 },
                    { 125, 0, 130, true, "OSŁONA", 220742, 2 },
                    { 124, 0, 130, false, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 123, 0, 130, true, "TARCZA OSŁANIAJĄCA", 220637, 2 },
                    { 122, 0, 80, false, "RURKA WODNA", 220700, 2 },
                    { 121, 0, 80, true, "RURKA WODNA", 220700, 2 },
                    { 120, 0, 80, false, "ELEKTRODA", 220802, 2 },
                    { 119, 0, 80, true, "ELEKTRODA", 220802, 2 },
                    { 128, 0, 130, false, "NASADKA DYSZY", 220740, 2 },
                    { 374, 0, 400, false, "RURKA WODNA", 220571, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_steelTypeId",
                table: "items",
                column: "steelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_itemId",
                table: "orderItems",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_orderId",
                table: "orderItems",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderingUserId",
                table: "orders",
                column: "orderingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_statusId",
                table: "orders",
                column: "statusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "steelTypes");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
