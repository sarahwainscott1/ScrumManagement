using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strengths_TeamMembers_TeamMemberId",
                table: "Strengths");

            migrationBuilder.DropIndex(
                name: "IX_Strengths_TeamMemberId",
                table: "Strengths");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Strengths");

            migrationBuilder.CreateTable(
                name: "StrengthsTeamMember",
                columns: table => new
                {
                    IndividualStrengthsId = table.Column<int>(type: "int", nullable: false),
                    TeamMembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthsTeamMember", x => new { x.IndividualStrengthsId, x.TeamMembersId });
                    table.ForeignKey(
                        name: "FK_StrengthsTeamMember_Strengths_IndividualStrengthsId",
                        column: x => x.IndividualStrengthsId,
                        principalTable: "Strengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrengthsTeamMember_TeamMembers_TeamMembersId",
                        column: x => x.TeamMembersId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrengthsTeamMember_TeamMembersId",
                table: "StrengthsTeamMember",
                column: "TeamMembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrengthsTeamMember");

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Strengths",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strengths_TeamMemberId",
                table: "Strengths",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strengths_TeamMembers_TeamMemberId",
                table: "Strengths",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }
    }
}
