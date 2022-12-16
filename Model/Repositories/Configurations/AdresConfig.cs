using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class AdresConfig : IEntityTypeConfiguration<Adres>
{
    public void Configure(EntityTypeBuilder<Adres> builder)
    {
        builder.ToTable("Adressen");

        builder.HasKey(b => b.AdresId);

        builder.Property(b => b.StraatId)
            .IsRequired();

        builder.Property(b => b.HuisNr)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(b => b.BusNr)
            .HasMaxLength(5);

        builder.HasIndex(b => new { b.StraatId, b.HuisNr, b.BusNr })
            .IsUnique();

        builder.HasOne(b => b.Straat)
            .WithMany(b => b.Adressen)
            .HasForeignKey(b => b.StraatId);
    }
}