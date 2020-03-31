using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FalconParkingAPI.Migrations
{
    public partial class AddedEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Lots_AggregateId",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lots",
                table: "Lots");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "ParkingSlotViews");

            migrationBuilder.RenameTable(
                name: "Lots",
                newName: "ParkingLotViews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSlotViews",
                table: "ParkingSlotViews",
                columns: new[] { "AggregateId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLotViews",
                table: "ParkingLotViews",
                column: "AggregateId");

            migrationBuilder.CreateTable(
                name: "ParkingLotEvents",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    AggregateId = table.Column<int>(nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    EventData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLotEvents", x => x.EventId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlotViews_ParkingLotViews_AggregateId",
                table: "ParkingSlotViews",
                column: "AggregateId",
                principalTable: "ParkingLotViews",
                principalColumn: "AggregateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlotViews_ParkingLotViews_AggregateId",
                table: "ParkingSlotViews");

            migrationBuilder.DropTable(
                name: "ParkingLotEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSlotViews",
                table: "ParkingSlotViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLotViews",
                table: "ParkingLotViews");

            migrationBuilder.RenameTable(
                name: "ParkingSlotViews",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "ParkingLotViews",
                newName: "Lots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                columns: new[] { "AggregateId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lots",
                table: "Lots",
                column: "AggregateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Lots_AggregateId",
                table: "Slots",
                column: "AggregateId",
                principalTable: "Lots",
                principalColumn: "AggregateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
