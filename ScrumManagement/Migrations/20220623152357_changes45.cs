using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Sprints",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_TeamId",
                table: "Sprints",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Teams_TeamId",
                table: "Sprints",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Teams_TeamId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_TeamId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Sprints");
        }
    }
}
