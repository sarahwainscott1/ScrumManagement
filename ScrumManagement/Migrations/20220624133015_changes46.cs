using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Products_ProductId",
                table: "Teams",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
