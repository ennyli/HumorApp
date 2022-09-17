using Microsoft.EntityFrameworkCore.Migrations;

namespace HumorApp.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gaate_1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GaateSporsmal = table.Column<string>(nullable: true),
                    GaateSvar = table.Column<string>(nullable: true),
                    Kategori = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaate_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vits_1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vitsen = table.Column<string>(nullable: true),
                    Kategori = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vits_1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gaate_1");

            migrationBuilder.DropTable(
                name: "Vits_1");
        }
    }
}
