using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class GemeenteSeeding : IEntityTypeConfiguration<Gemeente>
{
    public void Configure(EntityTypeBuilder<Gemeente> builder)
    {
        builder.HasData
            (
                new Gemeente { GemeenteId = 1730, GemeenteNaam = "Gent", PostCode = 9000, ProvincieId = 3, HoofdGemeenteId = null, TaalId = 1 },
                new Gemeente { GemeenteId = 1731, GemeenteNaam = "Sint-Amandsberg", PostCode = 9040, ProvincieId = 3, HoofdGemeenteId = 1730, TaalId = 1 },
                new Gemeente { GemeenteId = 1732, GemeenteNaam = "Oostakker", PostCode = 9041, ProvincieId = 3, HoofdGemeenteId = 1730, TaalId = 1 },
                new Gemeente { GemeenteId = 1733, GemeenteNaam = "Destelbergen", PostCode = 9042, ProvincieId = 3, HoofdGemeenteId = 1730, TaalId = 1 },
                new Gemeente { GemeenteId = 1734, GemeenteNaam = "Brussel", PostCode = 1000, ProvincieId = 11, HoofdGemeenteId = null, TaalId = 2 },
                new Gemeente { GemeenteId = 1735, GemeenteNaam = "miniBrussel", PostCode = 1001, ProvincieId = 11, HoofdGemeenteId = 1734, TaalId = 2 },
                new Gemeente { GemeenteId = 1736, GemeenteNaam = "Molenbeek", PostCode = 1002, ProvincieId = 11, HoofdGemeenteId = 1734, TaalId = 2 },
                new Gemeente { GemeenteId = 1737, GemeenteNaam = "Antwerpen", PostCode = 2000, ProvincieId = 1, HoofdGemeenteId = null, TaalId = 1 }
            );
    }
}