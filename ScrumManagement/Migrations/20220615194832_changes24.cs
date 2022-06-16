using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Strengths");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strengths", x => x.Id);
                });

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
    }
}
