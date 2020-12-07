using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class namechange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78b718b-6cc3-4fd3-8258-7e176714a439");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97f8486a-36b0-4388-bac8-a11479069a15", "1d4e0df8-e5e7-4390-ba96-d08b6f4dc89e", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97f8486a-36b0-4388-bac8-a11479069a15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b78b718b-6cc3-4fd3-8258-7e176714a439", "eac69306-75e1-4fc4-ba64-8f84b06d64ea", "Person", "PERSON" });
        }
    }
}
