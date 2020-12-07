using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15881227-6a63-44cb-82d7-bddd66a6168a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd26a60a-64f0-455c-ac41-717d285cfb45", "0d803638-d304-4961-a66b-4deee93f1145", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd26a60a-64f0-455c-ac41-717d285cfb45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15881227-6a63-44cb-82d7-bddd66a6168a", "c321783f-0c01-4800-9cea-24cffae79734", "Person", "PERSON" });
        }
    }
}
