using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class GemeenteConfig : IEntityTypeConfiguration<Gemeente>
{
    public void Configure(EntityTypeBuilder<Gemeente> builder)
    {
        builder.ToTable("Gemeenten");

        builder.HasKey(b => b.GemeenteId);

        builder.HasIndex(b => b.GemeenteNaam)
            .IsUnique();

        builder.Property(b => b.GemeenteNaam)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.PostCode)
            .IsRequired();

        builder.HasOne(b => b.Provincie)
            .WithMany(s => s.Gemeenten)
            .HasForeignKey(b => b.ProvincieId);

        builder.HasOne(x => x.Hoofdgemeente)
             .WithMany(h => h.Gemeenten)
             .HasForeignKey(x => x.HoofdGemeenteId);


    }
}