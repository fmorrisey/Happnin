using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc9d9e9a-01cc-4ffc-8768-c6c69f317901", "632f47aa-4204-4d8b-ae9c-a29c8e9a5df2", "Person", "PERSON" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3406ad93-586a-4166-9dff-7b40c9085074", "946ba6ca-fc13-4fe3-8ad6-6eb81dd97678", "Group", "GROUP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6b75ce8-5572-4ed2-9218-91c119b5bac1", "bd7f3e7d-d50e-4054-9ac3-edcad2c4111d", "Venue", "VENUE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3406ad93-586a-4166-9dff-7b40c9085074");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc9d9e9a-01cc-4ffc-8768-c6c69f317901");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b75ce8-5572-4ed2-9218-91c119b5bac1");
        }
    }
}
