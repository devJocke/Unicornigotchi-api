using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cares",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisciplineId = table.Column<int>(nullable: false),
                    ToiletId = table.Column<int>(nullable: false),
                    PlayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cares", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Unicorns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ThirdName = table.Column<string>(nullable: true),
                    Careid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unicorns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unicorns_Cares_Careid",
                        column: x => x.Careid,
                        principalTable: "Cares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unicorns_Careid",
                table: "Unicorns",
                column: "Careid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unicorns");

            migrationBuilder.DropTable(
                name: "Cares");
        }
    }
}
