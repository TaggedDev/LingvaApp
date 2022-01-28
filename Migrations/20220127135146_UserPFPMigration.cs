using Microsoft.EntityFrameworkCore.Migrations;

namespace LingvaApp.Migrations
{
    public partial class UserPFPMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "AspNetUsers");
        }
    }
}
