using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumManagement.Migrations
{
    public partial class changes36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Sprints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Stories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Products_ProductId",
                table: "Sprints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Products_ProductId",
                table: "Stories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
