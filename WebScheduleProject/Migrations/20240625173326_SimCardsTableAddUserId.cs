using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScheduleProject.Migrations
{
    /// <inheritdoc />
    public partial class SimCardsTableAddUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SimCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SimCards");
        }
    }
}
