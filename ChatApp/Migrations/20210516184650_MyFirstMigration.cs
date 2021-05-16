using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApp.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatAppModel",
                columns: table => new
                {
                    korisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnik_ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_korisnicko_ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatAppModel", x => x.korisnikID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatAppModel");
        }
    }
}
