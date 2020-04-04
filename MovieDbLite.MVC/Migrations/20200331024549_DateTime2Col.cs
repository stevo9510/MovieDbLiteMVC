using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MovieDbLite.MVC.Migrations
{
    public partial class DateTime2Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "MovieUserReview",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "MovieUserReview",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
