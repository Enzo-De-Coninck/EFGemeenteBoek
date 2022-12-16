using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Seeding;

class AdresSeeding : IEntityTypeConfiguration<Adres>
{
    public void Configure(EntityTypeBuilder<Adres> builder)
    {
        builder.HasData
            (
                new Adres { AdresId = 1, StraatId = 24, HuisNr = "1" },
                new Adres { AdresId = 2, StraatId = 23, HuisNr = "2" },
                new Adres { AdresId = 3, StraatId = 22, HuisNr = "3" },
                new Adres { AdresId = 4, StraatId = 21, HuisNr = "4" },
                new Adres { AdresId = 5, StraatId = 20, HuisNr = "5" },
                new Adres { AdresId = 6, StraatId = 19, HuisNr = "6" },
                new Adres { AdresId = 7, StraatId = 18, HuisNr = "7" },
                new Adres { AdresId = 8, StraatId = 17, HuisNr = "8" },
                new Adres { AdresId = 9, StraatId = 16, HuisNr = "9" },
                new Adres { AdresId = 10, StraatId = 15, HuisNr = "10" },
                new Adres { AdresId = 11, StraatId = 14, HuisNr = "11" },
                new Adres { AdresId = 12, StraatId = 13, HuisNr = "12" },
                new Adres { AdresId = 13, StraatId = 12, HuisNr = "13" },
                new Adres { AdresId = 14, StraatId = 11, HuisNr = "14" },
                new Adres { AdresId = 15, StraatId = 10, HuisNr = "15" },
                new Adres { AdresId = 16, StraatId = 9, HuisNr = "16" },
                new Adres { AdresId = 17, StraatId = 8, HuisNr = "17" },
                new Adres { AdresId = 18, StraatId = 7, HuisNr = "18" },
                new Adres { AdresId = 19, StraatId = 6, HuisNr = "19" },
                new Adres { AdresId = 20, StraatId = 5, HuisNr = "20" },
                new Adres { AdresId = 21, StraatId = 4, HuisNr = "21" },
                new Adres { AdresId = 22, StraatId = 3, HuisNr = "22" },
                new Adres { AdresId = 23, StraatId = 2, HuisNr = "23" },
                new Adres { AdresId = 24, StraatId = 1, HuisNr = "24" }
            );
    }
}