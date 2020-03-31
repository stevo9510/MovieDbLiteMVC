using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLite.MVC.Migrations
{
    public partial class NewForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Movie_DirectorFilmMember",
                table: "Movie",
                column: "DirectorFilmMemberId",
                principalTable: "FilmMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_DirectorFilmMember",
                table: "Movie");
        }
    }
}
