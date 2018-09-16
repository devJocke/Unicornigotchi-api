using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnicornigotchiApi.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "hibernate_sequence");

            migrationBuilder.CreateTable(
                name: "Blueprints",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fishingShack = table.Column<bool>(nullable: true),
                    running = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blueprints", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Care",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Care", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    blueprintsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.id);
                    table.ForeignKey(
                        name: "blueprints_fk",
                        column: x => x.blueprintsId,
                        principalTable: "Blueprints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unicorn",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    lastName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    thirdName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    farmId = table.Column<int>(nullable: true),
                    careId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unicorn", x => x.id);
                    table.ForeignKey(
                        name: "FK_Unicorn_Care_careId",
                        column: x => x.careId,
                        principalTable: "Care",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farm_blueprintsId",
                table: "Farm",
                column: "blueprintsId");

            migrationBuilder.CreateIndex(
                name: "IX_Unicorn_careId",
                table: "Unicorn",
                column: "careId",
                unique: true,
                filter: "[careId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "Unicorn");

            migrationBuilder.DropTable(
                name: "Blueprints");

            migrationBuilder.DropTable(
                name: "Care");

            migrationBuilder.DropSequence(
                name: "hibernate_sequence");
        }
    }
}
