using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Stories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductOwnerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProductId",
                table: "Teams",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductOwnerId",
                table: "Products",
                column: "ProductOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TeamMembers_ProductOwnerId",
                table: "Products",
                column: "ProductOwnerId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamMembers_ProductOwnerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ProductId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductOwnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Sprints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_TeamMembers_TeamMemberId",
                table: "Stories",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
