using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seminarski.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_Korisnici_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.RenameColumn(
                name: "KorisnickiNalogId",
                table: "AutentifikacijaToken",
                newName: "korisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                newName: "IX_AutentifikacijaToken_korisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_Korisnici_korisnikId",
                table: "AutentifikacijaToken",
                column: "korisnikId",
                principalTable: "Korisnici",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_Korisnici_korisnikId",
                table: "AutentifikacijaToken");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "AutentifikacijaToken",
                newName: "KorisnickiNalogId");

            migrationBuilder.RenameIndex(
                name: "IX_AutentifikacijaToken_korisnikId",
                table: "AutentifikacijaToken",
                newName: "IX_AutentifikacijaToken_KorisnickiNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_Korisnici_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "Korisnici",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
