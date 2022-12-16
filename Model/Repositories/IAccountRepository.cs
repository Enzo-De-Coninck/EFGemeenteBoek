using Model.Entities;
using System.Numerics;

namespace Model.Repositories;

public interface IAccountRepository
{
    public Task<int> GetPersoonIdByNameAsync(string naam);
    public Task<Persoon> GetPersoonByIdAsync(int userId);
    public Task<bool> LoginBestaatAsync(string gebruikersNaam);
    public Task<Persoon> GetPersoonIdByLoginNameAsync(string persoonlogin);
    public Task ActiveerProfielAsync(Profiel profiel);
    public Task<Profiel> VoegProfielToeAsync(Profiel nieuwProfiel);
}