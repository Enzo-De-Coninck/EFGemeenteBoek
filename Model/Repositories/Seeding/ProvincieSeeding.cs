using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class ProvincieSeeding : IEntityTypeConfiguration<Provincie>
{
    public void Configure(EntityTypeBuilder<Provincie> builder)
    {
        builder.HasData
            (
                new Provincie { ProvincieId = 1, ProvincieCode = "ANT", ProvincieNaam = "Antwerpen" },
                new Provincie { ProvincieId = 2, ProvincieCode = "LIM", ProvincieNaam = "Limburg" },
                new Provincie { ProvincieId = 3, ProvincieCode = "OVL", ProvincieNaam = "Oost-Vlaanderen" },
                new Provincie { ProvincieId = 4, ProvincieCode = "VBR", ProvincieNaam = "Vlaams-Brabant" },
                new Provincie { ProvincieId = 5, ProvincieCode = "WVL", ProvincieNaam = "West-Vlaanderen" },
                new Provincie { ProvincieId = 6, ProvincieCode = "WBR", ProvincieNaam = "Waals-Brabant" },
                new Provincie { ProvincieId = 7, ProvincieCode = "HEN", ProvincieNaam = "Henegouwen" },
                new Provincie { ProvincieId = 8, ProvincieCode = "LUI", ProvincieNaam = "Luik" },
                new Provincie { ProvincieId = 9, ProvincieCode = "LUX", ProvincieNaam = "Luxemburg" },
                new Provincie { ProvincieId = 10, ProvincieCode = "NAM", ProvincieNaam = "Namen" },
                new Provincie { ProvincieId = 11, ProvincieCode = "BRU", ProvincieNaam = "Brussel" }
            );
    }
}