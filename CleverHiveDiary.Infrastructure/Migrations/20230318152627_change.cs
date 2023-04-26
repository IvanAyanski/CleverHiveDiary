using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5d7aeea-a9fd-47e5-ab9e-e5ac5854dc2b", "AQAAAAEAACcQAAAAEF0Cah6uKg62ba2ozbIgXd4bCVypF3DmseS6y3wb4KX7MDxj7PZV6kPDpHMDz15sTA==", "25699970-07ed-4884-a314-b91e22210f55" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ed34af-e499-452a-9675-d8e18ac425b9", "AQAAAAEAACcQAAAAEIlci37FcRWN5LNuvrBgtwn3B7iWHpVzzATDtc9H/hQPDri9ktL+cFKMT0hSBYb28w==", "760903eb-740f-449e-9aa6-1798be8c2079" });
        }
    }
}
