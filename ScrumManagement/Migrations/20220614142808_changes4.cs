using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "SprintId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "SprintId",
                table: "Stories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Sprints_SprintId",
                table: "Stories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }
    }
}
