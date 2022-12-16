using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class ProfielConfig : IEntityTypeConfiguration<Profiel>
{
    public void Configure(EntityTypeBuilder<Profiel> builder)
    {
        builder.Property(p => p.KennismakingTekst)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.BeroepTekst)
            .HasMaxLength(30);

        builder.Property(p => p.FirmaNaam)
            .HasMaxLength(30);

        builder.Property(p => p.WebsiteAdres)
            .HasMaxLength(50);

        builder.Property(p => p.EmailAdres)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.FacebookNaam)
            .HasMaxLength(30);

        builder.Property(p => p.CreatieTijdstip)
            .IsRequired();

        builder.Property(p => p.LaatsteUpdateTijdstip)
            .IsRequired();


    }
}