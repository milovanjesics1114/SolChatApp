using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApp.Migrations
{
    public partial class Connected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "korisnik_korisnikID",
                table: "MessageModel",
                newName: "poruka_korisnikID");

            migrationBuilder.AddColumn<int>(
                name: "ChatAppModelkorisnikID",
                table: "MessageModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_sifra",
                table: "ChatAppModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_korisnicko_ime",
                table: "ChatAppModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_email",
                table: "ChatAppModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_MessageModel_ChatAppModelkorisnikID",
                table: "MessageModel",
                column: "ChatAppModelkorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_ChatAppModel_ChatAppModelkorisnikID",
                table: "MessageModel",
                column: "ChatAppModelkorisnikID",
                principalTable: "ChatAppModel",
                principalColumn: "korisnikID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_ChatAppModel_ChatAppModelkorisnikID",
                table: "MessageModel");

            migrationBuilder.DropIndex(
                name: "IX_MessageModel_ChatAppModelkorisnikID",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "ChatAppModelkorisnikID",
                table: "MessageModel");

            migrationBuilder.RenameColumn(
                name: "poruka_korisnikID",
                table: "MessageModel",
                newName: "korisnik_korisnikID");

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_sifra",
                table: "ChatAppModel",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_korisnicko_ime",
                table: "ChatAppModel",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "korisnik_email",
                table: "ChatAppModel",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
