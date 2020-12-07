using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class namechagne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3709269-be11-4165-aaf2-2d637325b1c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b78b718b-6cc3-4fd3-8258-7e176714a439", "eac69306-75e1-4fc4-ba64-8f84b06d64ea", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78b718b-6cc3-4fd3-8258-7e176714a439");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3709269-be11-4165-aaf2-2d637325b1c1", "782ac8ce-a8d8-4c86-b6c7-ef39e55cfba6", "Person", "PERSON" });
        }
    }
}
