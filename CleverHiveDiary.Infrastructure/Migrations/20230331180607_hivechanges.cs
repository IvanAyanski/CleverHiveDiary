using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverHiveDiary.Infrastructure.Migrations
{
    public partial class hivechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "Hives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ConcurrencyStamp",
                value: "30bf59b1-8a6d-4dba-af0c-0e3d9e2969de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51027be8-1ea8-44a3-b50e-5e4e054784b5", "AQAAAAEAACcQAAAAELbNMdI6DvBiO8HOcovLWKdHC72o2J7pywUgF+zrM7WuLUZKAUcadwBsfi6RhQU2Pw==", "aeb9293e-6a83-416f-b82c-317ae05d3494" });

            migrationBuilder.UpdateData(
                table: "Hives",
                keyColumn: "Id",
                keyValue: 1,
                column: "Floors",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Floors",
                table: "Hives");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ConcurrencyStamp",
                value: "6e46ed1f-eaad-4036-b650-14242de9f88b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e445605-08da-48f5-b0b8-a00934b3068e", "AQAAAAEAACcQAAAAEKMNwl4Pqr5GFKdjF3+j+g+RNMjIxSnZDNhRWaNrYRmBlEnJYVBEx9a8rLb9YAst4g==", "a5b646ff-204c-4272-87bf-aef5eccded1f" });
        }
    }
}
