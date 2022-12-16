using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;


namespace Model.Repositories.Configurations;

class ProfielInteresseConfig : IEntityTypeConfiguration<ProfielInteresse>
{
    public void Configure(EntityTypeBuilder<ProfielInteresse> builder)
    {
        builder.ToTable("ProfielInteresses");

        builder.HasKey(p => new { p.PersoonId, p.InteresseSoortId });

        builder.HasOne(p => p.Profiel)
            .WithMany(p => p.ProfielInteresses)
            .HasForeignKey(p => p.PersoonId);

        builder.HasOne(p => p.InteresseSoort)
            .WithMany(p => p.ProfielInteresses)
            .HasForeignKey(p => p.InteresseSoortId);
    }
}