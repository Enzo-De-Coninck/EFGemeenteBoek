using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class PersoonConfig : IEntityTypeConfiguration<Persoon>
{
    public void Configure(EntityTypeBuilder<Persoon> builder)
    {
        builder.ToTable("Personen");
        
        builder.HasKey(p => p.PersoonId);

        builder.Property(p => p.VoorNaam)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.FamilieNaam)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.Geslacht)
            .IsRequired();

        builder.Property(p => p.AdresId)
            .IsRequired();

        builder.Property(p => p.Geblokkeerd)
            .IsRequired();

        builder.Property(p => p.TelefoonNr)
            .HasMaxLength(30);

        builder.Property(p => p.LoginNaam)
            .HasMaxLength(25)
            .IsRequired();

        builder.HasIndex(p => p.LoginNaam)
            .IsUnique();

        builder.Property(p => p.LoginPaswoord)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.VerkeerdeLoginsAantal)
            .IsRequired();

        builder.Property(p => p.LoginAantal)
            .IsRequired();

        builder.Property(p => p.TaalId)
            .IsRequired();

        builder.HasOne(p => p.Adres)
            .WithMany(p => p.Personen)
            .HasForeignKey(p => p.AdresId);

        builder.HasOne(p => p.Geboorteplaats)
            .WithMany(p => p.Personen)
            .HasForeignKey(p => p.GeboorteplaatsId);
    }
}