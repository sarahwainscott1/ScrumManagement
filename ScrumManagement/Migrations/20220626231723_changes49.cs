using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyScrum_Sprints_SprintId",
                table: "DailyScrum");

            migrationBuilder.AlterColumn<int>(
                name: "SprintId",
                table: "DailyScrum",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isHighlighted",
                table: "DailyScrum",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyScrum_Sprints_SprintId",
                table: "DailyScrum",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyScrum_Sprints_SprintId",
                table: "DailyScrum");

            migrationBuilder.DropColumn(
                name: "isHighlighted",
                table: "DailyScrum");

            migrationBuilder.AlterColumn<int>(
                name: "SprintId",
                table: "DailyScrum",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyScrum_Sprints_SprintId",
                table: "DailyScrum",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }
    }
}
