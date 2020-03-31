using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLite.MVC.Migrations
{
    public partial class ChangeReviewType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "MovieUserReview",
                unicode: false,
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "MovieUserReview",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8000,
                oldNullable: true);
        }
    }
}
