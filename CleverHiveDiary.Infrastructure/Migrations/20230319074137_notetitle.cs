using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class notetitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5b37450-fab5-43ab-b443-af2b3444cd98", "AQAAAAEAACcQAAAAEDNso7VQvU3533HgjG1jcJrVVSS6wLOiAYMvEQR4XHLecCiukOHSvG/3OKbOK/uflw==", "02631cd0-609d-4c1e-b357-8f66560e239c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5d7aeea-a9fd-47e5-ab9e-e5ac5854dc2b", "AQAAAAEAACcQAAAAEF0Cah6uKg62ba2ozbIgXd4bCVypF3DmseS6y3wb4KX7MDxj7PZV6kPDpHMDz15sTA==", "25699970-07ed-4884-a314-b91e22210f55" });
        }
    }
}
