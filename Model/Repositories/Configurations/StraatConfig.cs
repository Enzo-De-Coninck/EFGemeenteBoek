using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class StraatConfig : IEntityTypeConfiguration<Straat>
{
    public void Configure(EntityTypeBuilder<Straat> builder)
    {
        builder.ToTable("Straten");

        builder.HasKey(b => b.StraatId);

        builder.Property(b => b.StraatNaam)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(b => new { b.StraatNaam, b.GemeenteId })
            .IsUnique();

        builder.Property(b => b.GemeenteId)
            .IsRequired();
    }
}