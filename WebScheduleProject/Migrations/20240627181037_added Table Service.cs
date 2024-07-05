using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScheduleProject.Migrations
{
    /// <inheritdoc />
    public partial class addedTableService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SimCardServices",
                table: "SimCardServices");

            migrationBuilder.RenameTable(
                name: "SimCardServices",
                newName: "SimCardService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimCardService",
                table: "SimCardService",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SimCardService",
                table: "SimCardService");

            migrationBuilder.RenameTable(
                name: "SimCardService",
                newName: "SimCardServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimCardServices",
                table: "SimCardServices",
                column: "Id");
        }
    }
}
