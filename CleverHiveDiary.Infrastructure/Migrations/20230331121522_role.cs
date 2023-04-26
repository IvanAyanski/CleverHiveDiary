using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ConcurrencyStamp",
                value: "6e46ed1f-eaad-4036-b650-14242de9f88b");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { "a1", "u1", "UserRole" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e445605-08da-48f5-b0b8-a00934b3068e", "AQAAAAEAACcQAAAAEKMNwl4Pqr5GFKdjF3+j+g+RNMjIxSnZDNhRWaNrYRmBlEnJYVBEx9a8rLb9YAst4g==", "a5b646ff-204c-4272-87bf-aef5eccded1f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1", "u1" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ConcurrencyStamp",
                value: "90dcacc2-3c6d-4911-9f5b-25c5452c64ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "317cfcee-7905-4129-8034-67b45dbbf427", "AQAAAAEAACcQAAAAEDf8uSx5ZtHAMZkPfXHhX5TzguCt6ZVOBbQv0aGCgLGyVTQsv5NwHq8qBScqwustwQ==", "1b118c10-ea97-4f1e-bba5-e5ac68919f06" });
        }
    }
}
