using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stories_StoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sprints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ProductId",
                table: "Stories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProductId",
                table: "Sprints",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ProductId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_ProductId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoryId",
                table: "Products",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stories_StoryId",
                table: "Products",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
