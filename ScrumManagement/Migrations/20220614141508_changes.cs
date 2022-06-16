using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Sprints");
        }
    }
}
