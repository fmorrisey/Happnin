using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class addressupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "143f26ec-5eec-4a16-9a28-424f64abdda7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b036f30d-15ff-4322-af3b-c5d83c5c29bd", "eaf81b14-fffb-417b-8018-81d4f752c884", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b036f30d-15ff-4322-af3b-c5d83c5c29bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "143f26ec-5eec-4a16-9a28-424f64abdda7", "af3feea0-3a32-42c5-8e84-0278d71a3788", "Person", "PERSON" });
        }
    }
}
