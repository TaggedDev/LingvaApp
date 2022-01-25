using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class ArticleTitleAndDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PublishedArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PublishedArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PendingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PendingArticles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PublishedArticles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PublishedArticles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PendingArticles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PendingArticles");
        }
    }
}
