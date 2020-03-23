using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLite.MVC.Migrations
{
    public partial class RenameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UX_Genre_DisplayName",
                table: "Genre",
                newName: "UX_Genre_GenreName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UX_Genre_GenreName",
                table: "Genre",
                newName: "UX_Genre_DisplayName");
        }
    }
}
