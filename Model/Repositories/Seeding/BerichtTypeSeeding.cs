using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class BerichtTypeSeeding : IEntityTypeConfiguration<BerichtType>
{
    public void Configure(EntityTypeBuilder<BerichtType> builder)
    {
        builder.HasData
            (
                new BerichtType { BerichtTypeId = 1, BerichtTypeCode = "AL", BerichtTypeNaam = "Algemeen" },
                new BerichtType { BerichtTypeId = 2, BerichtTypeCode = "TK", BerichtTypeNaam = "Te koop" },
                new BerichtType { BerichtTypeId = 3, BerichtTypeCode = "IZ", BerichtTypeNaam = "Ik zoek" },
                new BerichtType { BerichtTypeId = 4, BerichtTypeCode = "ID", BerichtTypeNaam = "Idee" },
                new BerichtType { BerichtTypeId = 5, BerichtTypeCode = "LN", BerichtTypeNaam = "Lenen" },
                new BerichtType { BerichtTypeId = 6, BerichtTypeCode = "WG", BerichtTypeNaam = "Weggeven" },
                new BerichtType { BerichtTypeId = 7, BerichtTypeCode = "AC", BerichtTypeNaam = "Activiteit" },
                new BerichtType { BerichtTypeId = 8, BerichtTypeCode = "MD", BerichtTypeNaam = "Melding" },
                new BerichtType { BerichtTypeId = 9, BerichtTypeCode = "BS", BerichtTypeNaam = "Babysit" },
                new BerichtType { BerichtTypeId = 10, BerichtTypeCode = "HD", BerichtTypeNaam = "Huisdieren" },
                new BerichtType { BerichtTypeId = 11, BerichtTypeCode = "GH", BerichtTypeNaam = "Gezondheid" }
            );
    }
}