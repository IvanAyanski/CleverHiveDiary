using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "a1", "90dcacc2-3c6d-4911-9f5b-25c5452c64ce", "Role", "Admin", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "317cfcee-7905-4129-8034-67b45dbbf427", "AQAAAAEAACcQAAAAEDf8uSx5ZtHAMZkPfXHhX5TzguCt6ZVOBbQv0aGCgLGyVTQsv5NwHq8qBScqwustwQ==", "1b118c10-ea97-4f1e-bba5-e5ac68919f06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ec642d-1aa3-4c7c-b724-79d26b5a1164", "AQAAAAEAACcQAAAAEN6ic5Vsx2NbT3/z1t+ZRR878zA02MEAesa2tYiqEwhf7+Va6YdjRDPfUtzMJ1MV4g==", "9a44fc5b-94dc-4b0f-9ef3-28e24f72c592" });
        }
    }
}
