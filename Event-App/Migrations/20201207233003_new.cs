using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 134,
                columns: new[] { "EventDate", "Venue" },
                values: new object[] { new DateTime(2020, 12, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), "City Lights, Menomonee River Valley" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "EventDate", "EventDescription", "EventName", "IdentityUserId", "InterestId", "IsPrivate", "IsVirtual", "Venue" },
                values: new object[,]
                {
                    { 133, new DateTime(2020, 12, 8, 7, 0, 0, 0, DateTimeKind.Unspecified), "Be there, loser!", "Tour Harley-Davidson", 1, 2, false, false, "Harley-Davidson Museum" },
                    { 135, new DateTime(2020, 12, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "We will be showing 'Back to the Future' parts 1, 2, and 3", "Movies at the Park", 1, 1, false, false, "Lakeshore State Park" },
                    { 136, new DateTime(2020, 12, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), "Come bowling with us while we listen to all the best tunes of the 80s", "Bowling with the Oldies", 1, 3, false, false, "Bay View Bowl" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 136);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 134,
                columns: new[] { "EventDate", "Venue" },
                values: new object[] { new DateTime(2020, 12, 8, 7, 0, 0, 0, DateTimeKind.Unspecified), "Downtown" });
        }
    }
}
