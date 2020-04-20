using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FalconParkingAPI.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_slot_view_lot_view_ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.DropIndex(
                name: "IX_slot_view_ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.DropColumn(
                name: "ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.AddColumn<Guid>(
                name: "ParkingLotId",
                schema: "parking",
                table: "slot_view",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_slot_view_ParkingLotId",
                schema: "parking",
                table: "slot_view",
                column: "ParkingLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_slot_view_lot_view_ParkingLotId",
                schema: "parking",
                table: "slot_view",
                column: "ParkingLotId",
                principalSchema: "parking",
                principalTable: "lot_view",
                principalColumn: "AggregateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_slot_view_lot_view_ParkingLotId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.DropIndex(
                name: "IX_slot_view_ParkingLotId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.DropColumn(
                name: "ParkingLotId",
                schema: "parking",
                table: "slot_view");

            migrationBuilder.AddColumn<Guid>(
                name: "ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_slot_view_ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view",
                column: "ParkingLotViewAggregateId");

            migrationBuilder.AddForeignKey(
                name: "FK_slot_view_lot_view_ParkingLotViewAggregateId",
                schema: "parking",
                table: "slot_view",
                column: "ParkingLotViewAggregateId",
                principalSchema: "parking",
                principalTable: "lot_view",
                principalColumn: "AggregateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
