using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StrengthId",
                table: "TeamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_StrengthId",
                table: "TeamMembers",
                column: "StrengthId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Strengths_StrengthId",
                table: "TeamMembers",
                column: "StrengthId",
                principalTable: "Strengths",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Strengths_StrengthId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_StrengthId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "StrengthId",
                table: "TeamMembers");
        }
    }
}
