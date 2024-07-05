using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScheduleProject.Migrations
{
    /// <inheritdoc />
    public partial class fixedmanytomanyrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_SimCards_SimCardId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "SimCardServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_SimCardId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SimCardId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ServiceSimCard",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    SimCardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSimCard", x => new { x.ServicesId, x.SimCardsId });
                    table.ForeignKey(
                        name: "FK_ServiceSimCard_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSimCard_SimCards_SimCardsId",
                        column: x => x.SimCardsId,
                        principalTable: "SimCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSimCard_SimCardsId",
                table: "ServiceSimCard",
                column: "SimCardsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceSimCard");

            migrationBuilder.AddColumn<int>(
                name: "SimCardId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SimCardServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    SimCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCardServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_SimCardId",
                table: "Services",
                column: "SimCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_SimCards_SimCardId",
                table: "Services",
                column: "SimCardId",
                principalTable: "SimCards",
                principalColumn: "Id");
        }
    }
}
