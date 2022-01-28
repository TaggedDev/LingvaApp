using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class ExtendingArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorAvatarURL",
                table: "PublishedArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "PublishedArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "PublishedArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorAvatarURL",
                table: "PendingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "PendingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "PendingArticles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorAvatarURL",
                table: "PublishedArticles");

            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "PublishedArticles");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "PublishedArticles");

            migrationBuilder.DropColumn(
                name: "AuthorAvatarURL",
                table: "PendingArticles");

            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "PendingArticles");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "PendingArticles");
        }
    }
}
