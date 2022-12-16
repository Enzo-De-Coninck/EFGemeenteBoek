using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class AfdelingSeeding : IEntityTypeConfiguration<Afdeling>
{
    public void Configure(EntityTypeBuilder<Afdeling> builder)
    {
        builder.HasData
            (
                new Afdeling { AfdelingId = 1, AfdelingCode = "VERK", AfdelingNaam = "Verkoop" },
                new Afdeling { AfdelingId = 2, AfdelingCode = "BOEK", AfdelingNaam = "Boekhouding" },
                new Afdeling { AfdelingId = 3, AfdelingCode = "AANK", AfdelingNaam = "Aankoop" }
            );
    }
}