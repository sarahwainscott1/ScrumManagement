using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_TeamMemberId",
                table: "Stories",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_TeamMemberId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Stories");
        }
    }
}
