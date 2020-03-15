using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDbLiteMvc2.Migrations
{
    public partial class UpdateHashedPasswordLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HashedPassword",
                table: "User",
                unicode: false,
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldUnicode: false,
                oldMaxLength: 32);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HashedPassword",
                table: "User",
                type: "varchar(32)",
                unicode: false,
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 60);
        }
    }
}
