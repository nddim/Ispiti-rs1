using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class z22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit");

            migrationBuilder.DropForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_id",
                table: "Nastavnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_Drzava_drzava_id",
                table: "Opstina");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_KorisnickiNalog_id",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "UpisnaGodina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodinaStudija = table.Column<int>(type: "int", nullable: false),
                    AkademskaGodinaID = table.Column<int>(type: "int", nullable: false),
                    CijenaSkolarine = table.Column<int>(type: "int", nullable: false),
                    Obnova = table.Column<bool>(type: "bit", nullable: false),
                    DatumOvjere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Evidentirao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisnaGodina", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisnaGodina_AkademskaGodina_AkademskaGodinaID",
                        column: x => x.AkademskaGodinaID,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisnaGodina_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpisnaGodina_AkademskaGodinaID",
                table: "UpisnaGodina",
                column: "AkademskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisnaGodina_StudentID",
                table: "UpisnaGodina",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_id",
                table: "Nastavnik",
                column: "id",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                table: "Obavijest",
                column: "evidentiraoKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_Drzava_drzava_id",
                table: "Opstina",
                column: "drzava_id",
                principalTable: "Drzava",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita",
                column: "IspitID",
                principalTable: "Ispit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_KorisnickiNalog_id",
                table: "Student",
                column: "id",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit");

            migrationBuilder.DropForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_id",
                table: "Nastavnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_Drzava_drzava_id",
                table: "Opstina");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_KorisnickiNalog_id",
                table: "Student");

            migrationBuilder.DropTable(
                name: "UpisnaGodina");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_id",
                table: "Nastavnik",
                column: "id",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                table: "Obavijest",
                column: "evidentiraoKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_Drzava_drzava_id",
                table: "Opstina",
                column: "drzava_id",
                principalTable: "Drzava",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita",
                column: "IspitID",
                principalTable: "Ispit",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_KorisnickiNalog_id",
                table: "Student",
                column: "id",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");
        }
    }
}
