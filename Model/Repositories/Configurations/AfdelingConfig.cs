using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class AfdelingConfig : IEntityTypeConfiguration<Afdeling>
{
    public void Configure(EntityTypeBuilder<Afdeling> builder)
    {
        builder.ToTable("Afdelingen");

        builder.HasKey(p => p.AfdelingId);

        builder.HasIndex(a => a.AfdelingCode)
            .IsUnique();

        builder.HasIndex(a => a.AfdelingNaam)
            .IsUnique();

        builder.Property(a => a.AfdelingCode)
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(a => a.AfdelingNaam)
            .HasMaxLength(50)
            .IsRequired();
    }
}