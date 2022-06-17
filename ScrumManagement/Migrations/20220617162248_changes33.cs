using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamMembers_ProductOwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductOwnerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOwnerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TeamMemberId",
                table: "Products",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TeamMemberId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOwnerId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }
    }
}
