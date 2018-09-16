using Microsoft.EntityFrameworkCore.Migrations;

namespace UnicornigotchiApi.Migrations
{
    public partial class Testt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "STRINGG",
                table: "Care",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STRINGG",
                table: "Care");
        }
    }
}
