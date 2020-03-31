using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLite.MVC.Migrations
{
    public partial class UpdatePrefixDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "FilmMember",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "FilmMember",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
