using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class ArticleTagsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "PendingArticles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "PendingArticles");
        }
    }
}
