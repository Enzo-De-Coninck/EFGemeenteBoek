using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;


class TaalConfig : IEntityTypeConfiguration<Taal>
{
    public void Configure(EntityTypeBuilder<Taal> builder)
    {
        builder.HasKey(b => new { b.TaalId, b.TaalCode });

        builder.Property(b => b.TaalCode)
            .HasMaxLength(2);

        builder.Property(b => b.TaalNaam)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(b => b.Gemeenten)
            .WithOne(g => g.Taal)
            .HasPrincipalKey(t => t.TaalId);

        builder.HasMany(t => t.Personen)
            .WithOne(p => p.Taal)
            .HasPrincipalKey(t => t.TaalId);
    }
}