using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ec642d-1aa3-4c7c-b724-79d26b5a1164", "AQAAAAEAACcQAAAAEN6ic5Vsx2NbT3/z1t+ZRR878zA02MEAesa2tYiqEwhf7+Va6YdjRDPfUtzMJ1MV4g==", "9a44fc5b-94dc-4b0f-9ef3-28e24f72c592" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5b37450-fab5-43ab-b443-af2b3444cd98", "AQAAAAEAACcQAAAAEDNso7VQvU3533HgjG1jcJrVVSS6wLOiAYMvEQR4XHLecCiukOHSvG/3OKbOK/uflw==", "02631cd0-609d-4c1e-b357-8f66560e239c" });
        }
    }
}
