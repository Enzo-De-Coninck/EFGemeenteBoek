using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class MedewerkerSeeding : IEntityTypeConfiguration<Medewerker>
{
    public void Configure(EntityTypeBuilder<Medewerker> builder)
    {
        builder.HasData
            (
                new Medewerker
                {
                    PersoonId = 1,
                    VoorNaam = "Enzo",
                    FamilieNaam = "Admin",
                    Geslacht = Geslacht.M,
                    GeboorteDatum = new DateTime(2000, 11, 17),
                    AdresId = 1,
                    GeboorteplaatsId = 1730,
                    TelefoonNr = "04123743123",
                    LoginNaam = "Enzo",
                    LoginPaswoord = "Admin",
                    VerkeerdeLoginsAantal = 0,
                    LoginAantal = 0,
                    TaalId = 1,
                    Geblokkeerd = false,
                    AfdelingId = 1
                },
                new Medewerker
                {
                    PersoonId = 2,
                    VoorNaam = "Jana",
                    FamilieNaam = "Naessens",
                    Geslacht = Geslacht.V,
                    GeboorteDatum = new DateTime(2002, 6, 28),
                    AdresId = 1,
                    GeboorteplaatsId = 1730,
                    TelefoonNr = "04321564852",
                    LoginNaam = "Jana",
                    LoginPaswoord = "Jana123",
                    VerkeerdeLoginsAantal = 0,
                    LoginAantal = 0,
                    TaalId = 1,
                    Geblokkeerd = false,
                    AfdelingId = 1
                },
                new Medewerker
                {
                    PersoonId = 3,
                    VoorNaam = "Nayla",
                    FamilieNaam = "Admin",
                    Geslacht = Geslacht.V,
                    GeboorteDatum = new DateTime(2016, 9, 30),
                    AdresId = 1,
                    GeboorteplaatsId = 1730,
                    TelefoonNr = "0123456789",
                    LoginNaam = "Nayla",
                    LoginPaswoord = "Woef",
                    VerkeerdeLoginsAantal = 0,
                    LoginAantal = 0,
                    TaalId = 1,
                    Geblokkeerd = false,
                    AfdelingId = 1
                }
            ); ;
    }
}