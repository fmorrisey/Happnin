using Microsoft.EntityFrameworkCore.Migrations;

namespace Event_App.Migrations
{
    public partial class interesttype3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7fdaa9b-dc39-4825-a136-9c16a5fa12b7");

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "Event",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "179bf138-e111-4ac9-ad65-35a0791e3736", "a8e0e497-56c1-4a9e-8086-6124bf8bb312", "Person", "PERSON" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventId1",
                table: "Event",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Event_EventId1",
                table: "Event",
                column: "EventId1",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Event_EventId1",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_EventId1",
                table: "Event");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "179bf138-e111-4ac9-ad65-35a0791e3736");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Event");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7fdaa9b-dc39-4825-a136-9c16a5fa12b7", "6ff54ebe-e5d3-431f-a7a3-5350f36fff76", "Person", "PERSON" });
        }
    }
}
