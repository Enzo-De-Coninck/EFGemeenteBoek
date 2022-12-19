using Model.Entities;
using System.Numerics;

namespace Model.Repositories;

public interface IAccountRepository
{
    public Task<int> GetPersoonIdByNameAsync(string naam);
    public Task<Persoon> GetPersoonByIdAsync(int userId);
    public Task<bool> LoginBestaatAsync(string gebruikersNaam);
    public Task<int> GetProfielIdByLoginNameAsync(string persoonlogin);
    public Task ActiveerProfielAsync(Profiel profiel);
    public Task<Profiel> VoegProfielToeAsync(Profiel nieuwProfiel);
    public Task<IEnumerable<Taal>> GetAllTalenAsync();
    public Task<IEnumerable<Gemeente>> GetAllGemeenteAsync(string aantalLetters);
    public Task<IEnumerable<Straat>> GetAllStratenAsync(string aantalLetters, int gemeenteid);
    public Task<IEnumerable<InteresseSoort>> GetAllInteressesAsync();
}