using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class EasyOnRulesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "PendingArticles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PendingArticles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "PendingArticles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PendingArticles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
