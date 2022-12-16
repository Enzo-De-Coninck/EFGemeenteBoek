using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Afdelingen",
                columns: new[] { "AfdelingId", "AfdelingCode", "AfdelingNaam", "AfdelingTekst" },
                values: new object[,]
                {
                    { 1, "VERK", "Verkoop", null },
                    { 2, "BOEK", "Boekhouding", null },
                    { 3, "AANK", "Aankoop", null }
                });

            migrationBuilder.InsertData(
                table: "BerichtTypes",
                columns: new[] { "BerichtTypeId", "BerichtTypeCode", "BerichtTypeNaam", "BerichtTypeTekst" },
                values: new object[,]
                {
                    { 1, "AL", "Algemeen", null },
                    { 2, "TK", "Te koop", null },
                    { 3, "IZ", "Ik zoek", null },
                    { 4, "ID", "Idee", null },
                    { 5, "LN", "Lenen", null },
                    { 6, "WG", "Weggeven", null },
                    { 7, "AC", "Activiteit", null },
                    { 8, "MD", "Melding", null },
                    { 9, "BS", "Babysit", null },
                    { 10, "HD", "Huisdieren", null },
                    { 11, "GH", "Gezondheid", null }
                });

            migrationBuilder.InsertData(
                table: "InteresseSoorten",
                columns: new[] { "InteresseSoortId", "InteresseSoortNaam" },
                values: new object[,]
                {
                    { 1, "Fietsen" },
                    { 2, "ICT" },
                    { 3, "Klussen" },
                    { 4, "Muziek beluisteren" },
                    { 5, "Muziek spelen" },
                    { 6, "Natuur" },
                    { 7, "TVkijken" },
                    { 8, "Vrijwilligerswerk" },
                    { 9, "Wandelen" },
                    { 10, "Zwemmen" }
                });

            migrationBuilder.InsertData(
                table: "Provincies",
                columns: new[] { "ProvincieId", "ProvincieCode", "ProvincieNaam" },
                values: new object[,]
                {
                    { 1, "ANT", "Antwerpen" },
                    { 2, "LIM", "Limburg" },
                    { 3, "OVL", "Oost-Vlaanderen" },
                    { 4, "VBR", "Vlaams-Brabant" },
                    { 5, "WVL", "West-Vlaanderen" },
                    { 6, "WBR", "Waals-Brabant" },
                    { 7, "HEN", "Henegouwen" },
                    { 8, "LUI", "Luik" },
                    { 9, "LUX", "Luxemburg" },
                    { 10, "NAM", "Namen" },
                    { 11, "BRU", "Brussel" }
                });

            migrationBuilder.InsertData(
                table: "Talen",
                columns: new[] { "TaalCode", "TaalId", "TaalNaam" },
                values: new object[,]
                {
                    { "nl", 1, "Nederlands" },
                    { "fr", 2, "Frans" },
                    { "en", 3, "Engels" }
                });

            migrationBuilder.InsertData(
                table: "Gemeenten",
                columns: new[] { "GemeenteId", "GemeenteNaam", "HoofdGemeenteId", "PostCode", "ProvincieId", "TaalId" },
                values: new object[,]
                {
                    { 1730, "Gent", null, 9000, 3, 1 },
                    { 1734, "Brussel", null, 1000, 11, 2 },
                    { 1737, "Antwerpen", null, 2000, 1, 1 },
                    { 1731, "Sint-Amandsberg", 1730, 9040, 3, 1 },
                    { 1732, "Oostakker", 1730, 9041, 3, 1 },
                    { 1733, "Destelbergen", 1730, 9042, 3, 1 },
                    { 1735, "miniBrussel", 1734, 1001, 11, 2 },
                    { 1736, "Molenbeek", 1734, 1002, 11, 2 }
                });

            migrationBuilder.InsertData(
                table: "Straten",
                columns: new[] { "StraatId", "GemeenteId", "StraatNaam" },
                values: new object[,]
                {
                    { 1, 1730, "Stationsstraat" },
                    { 2, 1730, "Dorpstraat" },
                    { 3, 1730, "Kerkstraat" },
                    { 13, 1734, "Waterstraat" },
                    { 14, 1734, "Aardestraat" },
                    { 15, 1734, "Kerkwegel" },
                    { 22, 1737, "Brandweerstraat" },
                    { 23, 1737, "Kerkstraat" },
                    { 24, 1737, "Vuurstraat" }
                });

            migrationBuilder.InsertData(
                table: "Adressen",
                columns: new[] { "AdresId", "BusNr", "HuisNr", "StraatId" },
                values: new object[,]
                {
                    { 1, null, "1", 24 },
                    { 2, null, "2", 23 },
                    { 3, null, "3", 22 },
                    { 10, null, "10", 15 },
                    { 11, null, "11", 14 },
                    { 12, null, "12", 13 },
                    { 22, null, "22", 3 },
                    { 23, null, "23", 2 },
                    { 24, null, "24", 1 }
                });

            migrationBuilder.InsertData(
                table: "Straten",
                columns: new[] { "StraatId", "GemeenteId", "StraatNaam" },
                values: new object[,]
                {
                    { 4, 1731, "Ziekenhuisstraat" },
                    { 5, 1731, "Kerkstraat" },
                    { 6, 1731, "Dorpstraat" },
                    { 7, 1732, "Brandweerstraat" },
                    { 8, 1732, "Politiestraat" },
                    { 9, 1732, "Stationsstraat" },
                    { 10, 1733, "Waterstraat" },
                    { 11, 1733, "Politiestraat" },
                    { 12, 1733, "Vuurstraat" },
                    { 16, 1735, "Aardestraat" },
                    { 17, 1735, "Politiestraat" },
                    { 18, 1735, "Vuurstraar" },
                    { 19, 1736, "Waterstraat" },
                    { 20, 1736, "Windstraat" },
                    { 21, 1736, "Aardestraat" }
                });

            migrationBuilder.InsertData(
                table: "Adressen",
                columns: new[] { "AdresId", "BusNr", "HuisNr", "StraatId" },
                values: new object[,]
                {
                    { 4, null, "4", 21 },
                    { 5, null, "5", 20 },
                    { 6, null, "6", 19 },
                    { 7, null, "7", 18 },
                    { 8, null, "8", 17 },
                    { 9, null, "9", 16 },
                    { 13, null, "13", 12 },
                    { 14, null, "14", 11 },
                    { 15, null, "15", 10 },
                    { 16, null, "16", 9 },
                    { 17, null, "17", 8 },
                    { 18, null, "18", 7 },
                    { 19, null, "19", 6 },
                    { 20, null, "20", 5 },
                    { 21, null, "21", 4 }
                });

            migrationBuilder.InsertData(
                table: "Personen",
                columns: new[] { "PersoonId", "AdresId", "AfdelingId", "FamilieNaam", "Geblokkeerd", "GeboorteDatum", "GeboorteplaatsId", "Geslacht", "LoginAantal", "LoginNaam", "LoginPaswoord", "PersoonType", "TaalId", "TelefoonNr", "VerkeerdeLoginsAantal", "VoorNaam" },
                values: new object[,]
                {
                    { 1, 1, 1, "Admin", false, new DateTime(2000, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1730, 0, 0, "Enzo", "Admin", "M", 1, "04123743123", 0, "Enzo" },
                    { 2, 1, 1, "Naessens", false, new DateTime(2002, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1730, 1, 0, "Jana", "Jana123", "M", 1, "04321564852", 0, "Jana" },
                    { 3, 1, 1, "Admin", false, new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1730, 1, 0, "Nayla", "Woef", "M", 1, "0123456789", 0, "Nayla" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Afdelingen",
                keyColumn: "AfdelingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Afdelingen",
                keyColumn: "AfdelingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BerichtTypes",
                keyColumn: "BerichtTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InteresseSoorten",
                keyColumn: "InteresseSoortId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personen",
                keyColumn: "PersoonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personen",
                keyColumn: "PersoonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personen",
                keyColumn: "PersoonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumns: new[] { "TaalCode", "TaalId" },
                keyValues: new object[] { "en", 3 });

            migrationBuilder.DeleteData(
                table: "Adressen",
                keyColumn: "AdresId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Afdelingen",
                keyColumn: "AfdelingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1731);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1732);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1733);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1735);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1736);

            migrationBuilder.DeleteData(
                table: "Straten",
                keyColumn: "StraatId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1730);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1734);

            migrationBuilder.DeleteData(
                table: "Gemeenten",
                keyColumn: "GemeenteId",
                keyValue: 1737);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincies",
                keyColumn: "ProvincieId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumns: new[] { "TaalCode", "TaalId" },
                keyValues: new object[] { "nl", 1 });

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumns: new[] { "TaalCode", "TaalId" },
                keyValues: new object[] { "fr", 2 });
        }
    }
}
