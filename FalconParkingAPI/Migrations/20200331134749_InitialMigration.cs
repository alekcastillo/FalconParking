using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FalconParkingAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    AggregateId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true),
                    TotalSlotsCount = table.Column<int>(nullable: false),
                    AvailableSlotsCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.AggregateId);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    AggregateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => new { x.AggregateId, x.Id });
                    table.ForeignKey(
                        name: "FK_Slots_Lots_AggregateId",
                        column: x => x.AggregateId,
                        principalTable: "Lots",
                        principalColumn: "AggregateId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Lots");
        }
    }
}
