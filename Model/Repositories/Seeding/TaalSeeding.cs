using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class TaalSeeding : IEntityTypeConfiguration<Taal>
{
    public void Configure(EntityTypeBuilder<Taal> builder)
    {
        builder.HasData
            (
                new Taal { TaalId = 1, TaalCode = "nl", TaalNaam = "Nederlands" },
                new Taal { TaalId = 2, TaalCode = "fr", TaalNaam = "Frans" },
                new Taal { TaalId = 3, TaalCode = "en", TaalNaam = "Engels" }
            );
    }
}