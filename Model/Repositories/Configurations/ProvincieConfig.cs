using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;

class ProvincieConfig : IEntityTypeConfiguration<Provincie>
{
    public void Configure(EntityTypeBuilder<Provincie> builder)
    {
        builder.ToTable("Provincies");

        builder.HasKey(b => b.ProvincieId);

        builder.HasIndex(b => b.ProvincieCode)
            .IsUnique();

        builder.HasIndex(b => b.ProvincieNaam)
            .IsUnique();

        builder.Property(b => b.ProvincieCode)
            .HasMaxLength(3)
            .IsRequired();


        builder.Property(b => b.ProvincieNaam)
            .HasMaxLength(30)
            .IsRequired();
    }
}