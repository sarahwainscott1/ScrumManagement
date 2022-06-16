using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_TeamMembers_TeamMemberId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coaches");

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_TeamMembers_TeamMemberId",
                table: "Coaches",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_TeamMembers_TeamMemberId",
                table: "Coaches");

            migrationBuilder.AlterColumn<int>(
                name: "TeamMemberId",
                table: "Coaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_TeamMembers_TeamMemberId",
                table: "Coaches",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }
    }
}
