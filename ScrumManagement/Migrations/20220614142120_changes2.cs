using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Stories_StoryId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_StoryId",
                table: "Sprints");

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Stories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_SprintId",
                table: "Stories",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_SprintId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Stories");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_StoryId",
                table: "Sprints",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Stories_StoryId",
                table: "Sprints",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
