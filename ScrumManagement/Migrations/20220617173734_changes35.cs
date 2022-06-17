using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductOwnerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TeamMembers_TeamMemberId",
                table: "Products",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }
    }
}
