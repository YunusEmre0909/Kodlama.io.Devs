using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addSocialLinkData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "id", "githubLink" },
                values: new object[] { 1, "https://github.com/YunusEmre0909" });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "id", "githubLink" },
                values: new object[] { 2, "https://github.com/YunusEmre09" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
