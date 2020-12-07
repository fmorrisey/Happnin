using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class Controller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "179bf138-e111-4ac9-ad65-35a0791e3736");

            migrationBuilder.AddColumn<string>(
                name: "Interest",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15881227-6a63-44cb-82d7-bddd66a6168a", "c321783f-0c01-4800-9cea-24cffae79734", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15881227-6a63-44cb-82d7-bddd66a6168a");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Person");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "179bf138-e111-4ac9-ad65-35a0791e3736", "a8e0e497-56c1-4a9e-8086-6124bf8bb312", "Person", "PERSON" });
        }
    }
}
