using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Numerics;

namespace Model.Repositories;

public class SQLAccountRepository : IAccountRepository
{
    private readonly EFGemeenteBoekContext context;

    // -----------
    // Constructor
    // -----------
    public SQLAccountRepository(EFGemeenteBoekContext context)
        => this.context = context;

    // -------
    // Methods
    // -------

    // GetPersoonIdByName
    public async Task<int> GetPersoonIdByNameAsync(string naam)
    {
        var persoon = await context.Personen.Where(k => k.LoginNaam.ToUpper() == naam.ToUpper()).FirstOrDefaultAsync();
        if (persoon == null) return -1;
        return persoon.PersoonId;
    }

    // GetKlantById
    public async Task<Persoon> GetPersoonByIdAsync(int userId)
    {
        return (await context.Personen.Where(k => k.PersoonId == userId).FirstOrDefaultAsync())!;
    }

    // LoginBestaat
    public async Task<bool> LoginBestaatAsync(string gebruikersNaam)
    {
        return await Task.FromResult(context.Personen.Where(g => g.LoginNaam == gebruikersNaam).FirstOrDefault() != null);
    }
    // GetKlantByLoginName
    public async Task<Persoon> GetPersoonIdByLoginNameAsync(string klantlogin)
    {
        return (await context.Personen.Where(k => k.LoginNaam == klantlogin).FirstOrDefaultAsync())!;
    }
    // Activeer klant
    public async Task ActiveerProfielAsync(Profiel profiel)
    {
        profiel.GoedgekeurdTijdstip = DateTime.Now;
        await context.SaveChangesAsync();
    }
    // Voeg klant toe
    public async Task<Profiel> VoegProfielToeAsync(Profiel nieuwProfiel)
    {
        await context.Personen.AddAsync(nieuwProfiel);
        await context.SaveChangesAsync();
        return nieuwProfiel;
    }
    // Get alle talen
    public async Task<IEnumerable<Taal>> GetAllTalenAsync()
    {
        return await context.Talen.OrderBy(t => t.TaalId).ToListAsync();
    }
}