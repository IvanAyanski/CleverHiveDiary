using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class hivetext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Hives",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b2759f3-9a2d-4602-9020-605cb7009cc8", "AQAAAAEAACcQAAAAEEnbZE75m3Zt4PCRTL5KA9PuCfn5oOyaF+A1fahsVKj1XfdOLcyZ9H4u73W7s3jaJQ==", "760727b9-b085-44ed-a1c7-e072e4d88056" });

            migrationBuilder.UpdateData(
                table: "Hives",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discription",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Hives");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5005a369-4aa5-4fd5-9ba3-1c2b9ef13b79", "AQAAAAEAACcQAAAAENOMn4xmwxTqdmC7FHnUE4hC6TRrXxd6qDF6Z7mFZXZNIL/aG/GiTZtvutr1uyzdTw==", "542960d4-8f94-4da5-b656-fe3eba7c34e9" });
        }
    }
}
