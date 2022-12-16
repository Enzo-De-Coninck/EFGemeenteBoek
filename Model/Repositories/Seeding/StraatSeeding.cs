using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class StraatSeeding : IEntityTypeConfiguration<Straat>
{
    public void Configure(EntityTypeBuilder<Straat> builder)
    {
        builder.HasData
            (
                new Straat { StraatId = 1, StraatNaam = "Stationsstraat", GemeenteId = 1730 },
                new Straat { StraatId = 2, StraatNaam = "Dorpstraat", GemeenteId = 1730 },
                new Straat { StraatId = 3, StraatNaam = "Kerkstraat", GemeenteId = 1730 },
                new Straat { StraatId = 4, StraatNaam = "Ziekenhuisstraat", GemeenteId = 1731 },
                new Straat { StraatId = 5, StraatNaam = "Kerkstraat", GemeenteId = 1731 },
                new Straat { StraatId = 6, StraatNaam = "Dorpstraat", GemeenteId = 1731 },
                new Straat { StraatId = 7, StraatNaam = "Brandweerstraat", GemeenteId = 1732 },
                new Straat { StraatId = 8, StraatNaam = "Politiestraat", GemeenteId = 1732 },
                new Straat { StraatId = 9, StraatNaam = "Stationsstraat", GemeenteId = 1732 },
                new Straat { StraatId = 10, StraatNaam = "Waterstraat", GemeenteId = 1733 },
                new Straat { StraatId = 11, StraatNaam = "Politiestraat", GemeenteId = 1733 },
                new Straat { StraatId = 12, StraatNaam = "Vuurstraat", GemeenteId = 1733 },
                new Straat { StraatId = 13, StraatNaam = "Waterstraat", GemeenteId = 1734 },
                new Straat { StraatId = 14, StraatNaam = "Aardestraat", GemeenteId = 1734 },
                new Straat { StraatId = 15, StraatNaam = "Kerkwegel", GemeenteId = 1734 },
                new Straat { StraatId = 16, StraatNaam = "Aardestraat", GemeenteId = 1735 },
                new Straat { StraatId = 17, StraatNaam = "Politiestraat", GemeenteId = 1735 },
                new Straat { StraatId = 18, StraatNaam = "Vuurstraar", GemeenteId = 1735 },
                new Straat { StraatId = 19, StraatNaam = "Waterstraat", GemeenteId = 1736 },
                new Straat { StraatId = 20, StraatNaam = "Windstraat", GemeenteId = 1736 },
                new Straat { StraatId = 21, StraatNaam = "Aardestraat", GemeenteId = 1736 },
                new Straat { StraatId = 22, StraatNaam = "Brandweerstraat", GemeenteId = 1737 },
                new Straat { StraatId = 23, StraatNaam = "Kerkstraat", GemeenteId = 1737 },
                new Straat { StraatId = 24, StraatNaam = "Vuurstraat", GemeenteId = 1737 }
            );
    }
}