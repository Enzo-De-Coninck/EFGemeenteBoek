using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Repositories.Configurations;

class InteresseSoortConfig : IEntityTypeConfiguration<InteresseSoort>
{
    public void Configure(EntityTypeBuilder<InteresseSoort> builder)
    {
        builder.ToTable("InteresseSoorten");

        builder.HasKey(i => i.InteresseSoortId);

        builder.Property(i => i.InteresseSoortNaam)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(i => i.InteresseSoortNaam)
            .IsUnique();
    }
}