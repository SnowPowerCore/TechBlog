using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTechBlog.Server.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    AuthorsSerialized = table.Column<string>(nullable: false),
                    TagsSerialized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Motto = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: false),
                    MediaLinksSerialized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                table: "Articles",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FirstName",
                table: "Authors",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_LastName",
                table: "Authors",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
