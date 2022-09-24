using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    programmingLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Technologies_ProgrammingLanguages_programmingLanguageId",
                        column: x => x.programmingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "id", "name", "programmingLanguageId" },
                values: new object[] { 1, "ASP.Net", 1 });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "id", "name", "programmingLanguageId" },
                values: new object[] { 2, "WPF", 1 });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "id", "name", "programmingLanguageId" },
                values: new object[] { 3, "Spring", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_programmingLanguageId",
                table: "Technologies",
                column: "programmingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
