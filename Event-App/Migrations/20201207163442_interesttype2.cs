using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class interesttype2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9870a83e-b3d4-4ec1-b422-ce24f3463841");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7fdaa9b-dc39-4825-a136-9c16a5fa12b7", "6ff54ebe-e5d3-431f-a7a3-5350f36fff76", "Person", "PERSON" });

            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "InterestId", "InterestType" },
                values: new object[,]
                {
                    { 1, "Basketball" },
                    { 2, "Football" },
                    { 3, "Soccer" },
                    { 4, "Cycling" },
                    { 5, "Rock Climbing" },
                    { 6, "Baseball" },
                    { 7, "Yoga" },
                    { 8, "Baking" },
                    { 9, "Game Night" },
                    { 10, "Trivia" },
                    { 11, "Crochete" },
                    { 12, "Music" },
                    { 13, "Networking" },
                    { 14, "Sky Diving" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7fdaa9b-dc39-4825-a136-9c16a5fa12b7");

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "InterestId",
                keyValue: 14);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9870a83e-b3d4-4ec1-b422-ce24f3463841", "3d29dd1d-3d7c-4591-bbf7-0d5ff47137ba", "Person", "PERSON" });
        }
    }
}
