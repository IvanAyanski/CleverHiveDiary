using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hives_StatusHive_StatusId",
                table: "Hives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusHive",
                table: "StatusHive");

            migrationBuilder.RenameTable(
                name: "StatusHive",
                newName: "statusHives");

            migrationBuilder.AddPrimaryKey(
                name: "PK_statusHives",
                table: "statusHives",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ed34af-e499-452a-9675-d8e18ac425b9", "AQAAAAEAACcQAAAAEIlci37FcRWN5LNuvrBgtwn3B7iWHpVzzATDtc9H/hQPDri9ktL+cFKMT0hSBYb28w==", "760903eb-740f-449e-9aa6-1798be8c2079" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hives_statusHives_StatusId",
                table: "Hives",
                column: "StatusId",
                principalTable: "statusHives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hives_statusHives_StatusId",
                table: "Hives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_statusHives",
                table: "statusHives");

            migrationBuilder.RenameTable(
                name: "statusHives",
                newName: "StatusHive");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusHive",
                table: "StatusHive",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a66fa1f1-db78-46dc-a0d5-1abed0dc8624", "AQAAAAEAACcQAAAAEOh35OrVAOMrp8dsbjmAixHfn0EmHciAvGpqd0g8lgV7rox9xWK99VZlFzydLyZsaQ==", "045aa5ff-1219-44f7-b305-79ae1dae471d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hives_StatusHive_StatusId",
                table: "Hives",
                column: "StatusId",
                principalTable: "StatusHive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
