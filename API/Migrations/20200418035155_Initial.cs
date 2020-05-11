using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FalconParkingAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "parking");

            migrationBuilder.CreateTable(
                name: "lot_eventlog",
                schema: "parking",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    EventData = table.Column<string>(type: "jsonb", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lot_eventlog", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "lot_view",
                schema: "parking",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    TotalSlotsCount = table.Column<int>(nullable: false),
                    AvailableSlotsCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lot_view", x => x.AggregateId);
                });

            migrationBuilder.CreateTable(
                name: "slot_eventlog",
                schema: "parking",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    EventData = table.Column<string>(type: "jsonb", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slot_eventlog", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "slot_view",
                schema: "parking",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(nullable: false),
                    SlotNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsReservable = table.Column<bool>(nullable: false),
                    CurrentOccupantLicensePlate = table.Column<string>(nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    ParkingLotViewAggregateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slot_view", x => x.AggregateId);
                    table.ForeignKey(
                        name: "FK_slot_view_lot_view_ParkingLotViewAggregateId",
                        column: x => x.ParkingLotViewAggregateId,
                        principalSchema: "parking",
                        principalTable: "lot_view",
                        principalColumn: "AggregateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_slot_view_ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view",
                column: "ParkingLotViewAggregateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lot_eventlog",
                schema: "parking");

            migrationBuilder.DropTable(
                name: "slot_eventlog",
                schema: "parking");

            migrationBuilder.DropTable(
                name: "slot_view",
                schema: "parking");

            migrationBuilder.DropTable(
                name: "lot_view",
                schema: "parking");
        }
    }
}
