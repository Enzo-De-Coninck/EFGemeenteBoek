using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;

class BerichtConfig : IEntityTypeConfiguration<Bericht>
{
    public void Configure(EntityTypeBuilder<Bericht> builder)
    {
        builder.ToTable("Berichten");

        builder.HasKey(b => b.BerichtId);

        builder.Property(b => b.BerichtTijdstip)
            .IsRequired();

        builder.Property(b => b.BerichtTitel)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.BerichtTekst)
            .IsRequired();

        builder.HasOne(b => b.HoofdBericht)
            .WithMany(b => b.Berichten)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(b => b.HoofdBerichtId);

        builder.HasOne(b => b.Gemeente)
            .WithMany(g => g.Berichten)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(b => b.GemeenteId);

        builder.HasIndex(b => b.GemeenteId);

        builder.Property(b => b.GemeenteId)
            .IsRequired();

        builder.HasOne(b => b.Profiel)
            .WithMany(p => p.Berichten)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(b => b.PersoonId);

        builder.HasOne(b => b.BerichtType)
            .WithMany(b => b.Berichten)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(b => b.BerichtTypeId);

        builder.Property(b => b.BerichtTijdstip)
            .IsRequired();

        builder.Property(b => b.BerichtTitel)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.BerichtTekst)
            .IsRequired();
    }
}