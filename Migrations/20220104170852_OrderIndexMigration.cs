using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class OrderIndexMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageLevelColumnPosition",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "ThemeTaskPosition",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Themes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Field",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Field");

            migrationBuilder.AddColumn<int>(
                name: "LanguageLevelColumnPosition",
                table: "Themes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThemeTaskPosition",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
