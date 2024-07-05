using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScheduleProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_SimCards_SimCardId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimCardService",
                table: "SimCardService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "SimCardService",
                newName: "SimCardServices");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_Service_SimCardId",
                table: "Services",
                newName: "IX_Services_SimCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimCardServices",
                table: "SimCardServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_SimCards_SimCardId",
                table: "Services",
                column: "SimCardId",
                principalTable: "SimCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_SimCards_SimCardId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimCardServices",
                table: "SimCardServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "SimCardServices",
                newName: "SimCardService");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_Services_SimCardId",
                table: "Service",
                newName: "IX_Service_SimCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimCardService",
                table: "SimCardService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_SimCards_SimCardId",
                table: "Service",
                column: "SimCardId",
                principalTable: "SimCards",
                principalColumn: "Id");
        }
    }
}
