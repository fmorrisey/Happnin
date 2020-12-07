using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class DBInterests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b036f30d-15ff-4322-af3b-c5d83c5c29bd");

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.InterestId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9870a83e-b3d4-4ec1-b422-ce24f3463841", "3d29dd1d-3d7c-4591-bbf7-0d5ff47137ba", "Person", "PERSON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9870a83e-b3d4-4ec1-b422-ce24f3463841");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b036f30d-15ff-4322-af3b-c5d83c5c29bd", "eaf81b14-fffb-417b-8018-81d4f752c884", "Person", "PERSON" });
        }
    }
}
