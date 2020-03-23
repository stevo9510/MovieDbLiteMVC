using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLite.MVC.Migrations
{
    public partial class RenameGenreDisplayNameNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Genre",
                newName: "GenreName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genre",
                newName: "DisplayName");
        }
    }
}
