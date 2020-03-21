using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLiteMvc2.Migrations
{
    public partial class SmallRenamesAndNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_FilmMember",
                table: "Movie_Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_Movie",
                table: "Movie_Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieFilmMember_FilmMember",
                table: "MovieFilmMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieFilmMember_FilmRole",
                table: "MovieFilmMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieFilmMember_Movie",
                table: "MovieFilmMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieFilmMember",
                table: "MovieFilmMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Actor",
                table: "Movie_Actor");

            migrationBuilder.RenameTable(
                name: "MovieFilmMember",
                newName: "MovieCrewMember");

            migrationBuilder.RenameTable(
                name: "Movie_Actor",
                newName: "MovieCastMember");

            migrationBuilder.RenameColumn(
                name: "Helpful",
                table: "MovieUserReviewHelpful",
                newName: "IsHelpful");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "MovieCastMember",
                newName: "CharacterName");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageUserRating",
                table: "Movie",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCrewMember",
                table: "MovieCrewMember",
                columns: new[] { "MovieId", "FilmMemberId", "FilmRoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCastMember",
                table: "MovieCastMember",
                columns: new[] { "MovieId", "ActorFilmMemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCastMember_FilmMember",
                table: "MovieCastMember",
                column: "ActorFilmMemberId",
                principalTable: "FilmMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCastMember_Movie",
                table: "MovieCastMember",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrewMember_FilmMember",
                table: "MovieCrewMember",
                column: "FilmMemberId",
                principalTable: "FilmMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrewMember_FilmRole",
                table: "MovieCrewMember",
                column: "FilmRoleId",
                principalTable: "FilmRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrewMember_Movie",
                table: "MovieCrewMember",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCastMember_FilmMember",
                table: "MovieCastMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCastMember_Movie",
                table: "MovieCastMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrewMember_FilmMember",
                table: "MovieCrewMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrewMember_FilmRole",
                table: "MovieCrewMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrewMember_Movie",
                table: "MovieCrewMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCrewMember",
                table: "MovieCrewMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCastMember",
                table: "MovieCastMember");

            migrationBuilder.DropColumn(
                name: "AverageUserRating",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "MovieCrewMember",
                newName: "MovieFilmMember");

            migrationBuilder.RenameTable(
                name: "MovieCastMember",
                newName: "Movie_Actor");

            migrationBuilder.RenameColumn(
                name: "IsHelpful",
                table: "MovieUserReviewHelpful",
                newName: "Helpful");

            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "Movie_Actor",
                newName: "RoleName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieFilmMember",
                table: "MovieFilmMember",
                columns: new[] { "MovieId", "FilmMemberId", "FilmRoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Actor",
                table: "Movie_Actor",
                columns: new[] { "MovieId", "ActorFilmMemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_FilmMember",
                table: "Movie_Actor",
                column: "ActorFilmMemberId",
                principalTable: "FilmMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_Movie",
                table: "Movie_Actor",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFilmMember_FilmMember",
                table: "MovieFilmMember",
                column: "FilmMemberId",
                principalTable: "FilmMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFilmMember_FilmRole",
                table: "MovieFilmMember",
                column: "FilmRoleId",
                principalTable: "FilmRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFilmMember_Movie",
                table: "MovieFilmMember",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
