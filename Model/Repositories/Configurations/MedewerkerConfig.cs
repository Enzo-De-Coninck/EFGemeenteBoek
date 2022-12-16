using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class MedewerkerConfig : IEntityTypeConfiguration<Medewerker>
{
    public void Configure(EntityTypeBuilder<Medewerker> builder)
    {
        
        
        builder.HasOne(p => p.Afdeling)
            .WithMany(p => p.Medewerkers)
            .HasForeignKey(p => p.AfdelingId);
    }
}