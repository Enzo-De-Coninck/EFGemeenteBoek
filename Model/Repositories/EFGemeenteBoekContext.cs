using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Repositories.Configurations;
//using Model.Repositories.Seeding;

namespace Model.Repositories;

public class EFGemeenteBoekContext : DbContext
{
    public static IConfigurationRoot configuration = null!;
    private string appsetting = "efgemeenteboek";


    // ------
    // DbSets
    // ------
    public DbSet<Provincie> Provincies { get; set; } = null!;
    public DbSet<Gemeente> Gemeenten { get; set; } = null!;
    public DbSet<Straat> Straten { get; set; } = null!;
    public DbSet<Adres> Adressen { get; set; } = null!;
    public DbSet<Taal> Talen { get; set; } = null!;
    public DbSet<Persoon> Personen { get; set; } = null!;
    public DbSet<Afdeling> Afdelingen { get; set; } = null!;
    public DbSet<InteresseSoort> InteresseSoorten { get; set; } = null!;
    public DbSet<ProfielInteresse> ProfielInteresses { get; set; } = null!;
    public DbSet<Bericht> Berichten { get; set; } = null!;
    public DbSet<BerichtType> BerichtTypes { get; set; } = null!;
    public DbSet<Profiel> Profielen { get; set; } = null!;
    public DbSet<Medewerker> Medewerkers { get; set; } = null!;

    // ------------
    // Constructors
    // ------------
    public EFGemeenteBoekContext() { }

    public EFGemeenteBoekContext(DbContextOptions<EFGemeenteBoekContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var connectionString = configuration.GetConnectionString(appsetting);

            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150))
                    .EnableSensitiveDataLogging(true)
                    .UseLazyLoadingProxies();
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --------------
        // Configurations
        // --------------
        modelBuilder.ApplyConfiguration(new AdresConfig());
        modelBuilder.ApplyConfiguration(new AfdelingConfig());
        modelBuilder.ApplyConfiguration(new BerichtConfig());
        modelBuilder.ApplyConfiguration(new BerichtTypeConfig());
        modelBuilder.ApplyConfiguration(new GemeenteConfig());
        modelBuilder.ApplyConfiguration(new InteresseSoortConfig());
        modelBuilder.ApplyConfiguration(new MedewerkerConfig());
        modelBuilder.ApplyConfiguration(new PersoonConfig());
        modelBuilder.ApplyConfiguration(new ProfielConfig());
        modelBuilder.ApplyConfiguration(new ProfielInteresseConfig());
        modelBuilder.ApplyConfiguration(new ProvincieConfig());
        modelBuilder.ApplyConfiguration(new StraatConfig());
        modelBuilder.ApplyConfiguration(new TaalConfig());


        // -------
        // Seeding
        // -------
    }



}