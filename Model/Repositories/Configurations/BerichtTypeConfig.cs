using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;


namespace Model.Repositories.Configurations;

class BerichtTypeConfig : IEntityTypeConfiguration<BerichtType>
{
    public void Configure(EntityTypeBuilder<BerichtType> builder)
    {
        builder.ToTable("BerichtTypes");

        builder.HasKey(b => b.BerichtTypeId);

        builder.HasIndex(b => b.BerichtTypeCode)
            .IsUnique();

        builder.Property(b => b.BerichtTypeCode)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(b => b.BerichtTypeNaam)
            .HasMaxLength(20)
            .IsRequired();
    }
}