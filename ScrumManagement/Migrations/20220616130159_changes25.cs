using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strength",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrengthName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strength", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrengthList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberId = table.Column<int>(type: "int", nullable: false),
                    StrengthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrengthList_Strength_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "Strength",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrengthList_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrengthList_StrengthId",
                table: "StrengthList",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_StrengthList_TeamMemberId",
                table: "StrengthList",
                column: "TeamMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrengthList");

            migrationBuilder.DropTable(
                name: "Strength");
        }
    }
}
