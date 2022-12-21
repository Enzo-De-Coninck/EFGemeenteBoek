using Model.Entities;
using Model.Repositories;
using System.Numerics;

namespace Model.Services;

public class AccountService
{
    private IAccountRepository accountRepository;

    // -----------
    // Constructor
    // -----------
    public AccountService(IAccountRepository accountRepository)
    => this.accountRepository = accountRepository;

    // -------
    // Methods
    // -------

    // GetKlantIdByName
    public async Task<int> GetPersoonIdByNameAsync(string naam)
    {
        return await accountRepository.GetPersoonIdByNameAsync(naam);
    }
    // GetKlantById
    public async Task<Persoon> GetPersoonByIdAsync(int userId)
    {
        return await accountRepository.GetPersoonByIdAsync(userId);
    }
    // LoginBestaat
    public async Task<bool> LoginBestaatAsync(string gebruikersNaam)
    {
        return await accountRepository.LoginBestaatAsync(gebruikersNaam);
    }
    // GetKlantByLoginName
    public async Task<int> GetProfielIdByLoginNameAsync(string persoonlogin)
    {
        return await accountRepository.GetProfielIdByLoginNameAsync(persoonlogin);
    }
    // Activeer klant
    public async Task ActiveerKlantAsync(Profiel profiel)
    {
        await accountRepository.ActiveerProfielAsync(profiel);
    }
    // Voeg klant toe
    public async Task<Profiel> VoegProfielToeAsync(Profiel nieuwProfiel)
    {
        return await accountRepository.VoegProfielToeAsync(nieuwProfiel);
    }

    // Get alle talen
    public async Task<IEnumerable<Taal>> GetAllTalenAsync()
    {
        return await accountRepository.GetAllTalenAsync();
    }

    // Get alle gemeenten
    public async Task<IEnumerable<Gemeente>> GetAllGemeenteAsync(string aantalLetters)
    {
        return await accountRepository.GetAllGemeenteAsync(aantalLetters);
    }

    // Get alle straten
    public async Task<IEnumerable<Straat>> GetAllStratenAsync(string aantalLetters, int gemeenteid)
    {
        return await accountRepository.GetAllStratenAsync(aantalLetters, gemeenteid);
    }

    // Get alle interesses
    public async Task<IEnumerable<InteresseSoort>> GetAllInteressesAsync()
    {
        return await accountRepository.GetAllInteressesAsync();
    }

    // Get alle berichttypes
    public async Task<IEnumerable<BerichtType>> GetAllBerichtTypes()
    {
        return await accountRepository.GetAllBerichtTypes();
    }
}