using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class InteresseSoortSeeding : IEntityTypeConfiguration<InteresseSoort>
{
    public void Configure(EntityTypeBuilder<InteresseSoort> builder)
    {
        builder.HasData
            (
                new InteresseSoort { InteresseSoortId = 1, InteresseSoortNaam = "Fietsen" },
                new InteresseSoort { InteresseSoortId = 2, InteresseSoortNaam = "ICT" },
                new InteresseSoort { InteresseSoortId = 3, InteresseSoortNaam = "Klussen" },
                new InteresseSoort { InteresseSoortId = 4, InteresseSoortNaam = "Muziek beluisteren" },
                new InteresseSoort { InteresseSoortId = 5, InteresseSoortNaam = "Muziek spelen" },
                new InteresseSoort { InteresseSoortId = 6, InteresseSoortNaam = "Natuur" },
                new InteresseSoort { InteresseSoortId = 7, InteresseSoortNaam = "TVkijken" },
                new InteresseSoort { InteresseSoortId = 8, InteresseSoortNaam = "Vrijwilligerswerk" },
                new InteresseSoort { InteresseSoortId = 9, InteresseSoortNaam = "Wandelen" },
                new InteresseSoort { InteresseSoortId = 10, InteresseSoortNaam = "Zwemmen" }
            );
    }
}