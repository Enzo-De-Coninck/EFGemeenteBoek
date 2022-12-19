using Model.Entities;
using Model.Services;
using Model.Repositories;
using System.Text;
using System;
using System.Security.Principal;
using System.Numerics;

namespace UIConsole;

public partial class Program
{
    // ---------------------------------------
    // Static variables - Dependency Injection
    // ---------------------------------------
    private static readonly EFGemeenteBoekContext context = new EFGemeenteBoekContext();

    //private static readonly ISecurityRepository securityRepository = new SQLSecurityRepository(context);
    //private static readonly SecurityService securityService = new SecurityService(securityRepository);

    private static readonly IAccountRepository accountRepository = new SQLAccountRepository(context);
    private static readonly AccountService accountService = new AccountService(accountRepository);

    //private static readonly ISecurityRepository securityRepository = new SQLSecurityRepository(context);
    //private static readonly BerichtService BerichtService = new BerichtService(context);

    private static Persoon? CurrentAccount { get; set; }
    private static Bericht CurrentBericht { get; set; } = null!;

    

    public static string MenuGegevens => $"{(CurrentAccount == null ? "Niet ingelogd" : (CurrentAccount is Profiel ? "PROFIEL: " : "MEDEWERKER: ") + "Nr: " + CurrentAccount.PersoonId + " - Naam: " + CurrentAccount.LoginNaam)}";

    // ----
    // Menu
    // ----
    public static SubMenu menu = new SubMenu
    (
        01, null, "Hoofdmenu", MenuItemActive.Enabled, MenuItemVisible.Visible, new List<MenuItem>
        {
            new SubMenu
            (
                02,"<A>ccount","AccountMenu",MenuItemActive.Enabled, MenuItemVisible.Visible,new List<MenuItem>
                {
                    new MenuAction (03,"<I>nloggen","Inloggen",MenuItemActive.Enabled, MenuItemVisible.Visible,Inloggen),
                    new MenuAction (04,"<U>itloggen", "Uitloggen",MenuItemActive.Disabled, MenuItemVisible.Hidden,Uitloggen),
                    new MenuLijn (),
                    new MenuAction (05,"<R>egistreren", "Registeren",MenuItemActive.Enabled, MenuItemVisible.Visible,Registeren),
                    new MenuLijn (),
                    //new MenuAction (06,"<T>oon profielgegevens", "Profielgegevens",MenuItemActive.Disabled, MenuItemVisible.Visible,ToonGegevens),
                    new MenuAction (07,"<W>ijzig profielgegevens", "Wijzigen profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,WijzigGegevens),
                    new MenuAction (08,"<V>erwijder profiel","Verwijderen profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,VerwijderGegevens),
                }
            ),
            new MenuLijn (),
            new MenuAction (09,"<G>oedkeuring nieuw profiel","Goedkeuren van een profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,GoedkeurenNieuwProfiel),
            new MenuAction (10,"<B>lokkeren van een profiel","Blokkeer een profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,BlokkerenProfiel),
            new MenuAction (11,"<D>eblokkeren van een profiel","Deblokkeer een profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,DeblokkerenProfiel),
            new MenuLijn (),
            new MenuAction (12,"<N>ieuw bericht","Ingave nieuw bericht",MenuItemActive.Disabled, MenuItemVisible.Hidden,InvoerenNieuwBericht),
            new MenuAction (13,"<R>aadplegen berichten van uw hoofdgemeente","Berichten van de hoofdgemeente",MenuItemActive.Disabled, MenuItemVisible.Hidden,RaadplegenBerichten),
        }
    );

    public static SubMenu menuBerichten = new SubMenu
    (
        01, null, "Raadplegen bericht", MenuItemActive.Disabled, MenuItemVisible.Visible, Direction.Horizontal, new List<MenuItem>
        {
            new MenuAction (02,"<W>ijzigen","",MenuItemActive.Disabled, MenuItemVisible.Hidden,WijzigBericht),
            new MenuAction (03,"<V>erwijderen","",MenuItemActive.Disabled, MenuItemVisible.Hidden,VerwijderBericht),
            new MenuAction (04,"<A>ntwoorden","",MenuItemActive.Disabled, MenuItemVisible.Hidden,AntwoordBericht),
        }
    );

    private static void Main(string[] args)
    {
        //PrintMenu("GemeenteBoek", menu);
        //PrintMenu("GemeenteBoek", menuBerichten);
        ToonMenu("GemeenteBoek", menu);
    }

    public static void GoedkeurenNieuwProfiel()
    {
    }

    public static void BlokkerenProfiel()
    {
    }

    public static void DeblokkerenProfiel()
    {
    }

    public static void Inloggen()
    {
        if (!(CurrentAccount is null))
        {
            ToonFoutBoodschap("Account is al ingelogd. Log eerst uit aub");
            return;
        }

        int userId = -1;
        var gebruikersnaam = string.Empty;
        var loginOk = false;
        Persoon account = null!;
        bool medewerker = false;

        gebruikersnaam = LeesString("Gebruikersnaam <Enter>=Terug", 50, OptionMode.Optional);

        while ((gebruikersnaam != string.Empty) & (userId == -1))
        {
            try
            {
                userId = accountService.GetPersoonIdByNameAsync(gebruikersnaam!).Result;
            }
            catch (Exception ex)
            {
                ToonFoutBoodschap(ex.InnerException!.InnerException!.Message.ToString());
                return;
            }

            if (userId != -1)
            {
                account = accountService.GetPersoonByIdAsync(userId).Result;
                
                var wachtwoord = LeesString("Wachtwoord", 50);
                if (wachtwoord == String.Empty) return;

                if (account.LoginPaswoord == wachtwoord) loginOk= true;

            }
            else
            {
                ToonFoutBoodschap("Ongeldig account, probeer opnieuw");
                gebruikersnaam = LeesString("Gebruikersnaam <Enter>Terug", 50, OptionMode.Optional);
            }
        }

        if (loginOk)
        {
            if (account.Geblokkeerd)
            {
                ToonFoutBoodschap("Uw account is geblokkeerd, verwittig een medewerker");
                return;
            }
            
            account.LoginAantal++;

            if (account is Medewerker)
                medewerker = true;
            else
                medewerker = false;

            SetLabel(menu, new List<int> { 3 }, $"Ingelogd als '{(account.LoginNaam.Length > 5 ? string.Concat(account.LoginNaam.AsSpan(0, 5), "...") : account.LoginNaam)}'");

            if (medewerker)
            {
                CurrentAccount = account;
                ToonInfoBoodschap("Inloggen met succes voltooid");

                // Menu
                SetVisible(menu, new List<int> { 4, 6, 9, 10, 11 }, MenuItemVisible.Visible);
                SetActive(menu, new List<int> { 4, 6, 9, 10, 11 }, MenuItemActive.Enabled);
                SetActive(menu, new List<int> { 3, 5 }, MenuItemActive.Disabled);
                SetVisible(menu, new List<int> { 3, 5 }, MenuItemVisible.Hidden);

            } else
            {
                ToonInfoBoodschap("not imp");
            }

        }
          
    }

    public static void Uitloggen()
    {
        if (CurrentAccount is null)
        {
            ToonFoutBoodschap("Account is niet ingelogd");
            return;
        }

        CurrentAccount = null!;
        ResetMenu(menu);
    }

    public static void Registeren()
    {
        var voornaam = LeesString("Voornaam (<Enter>=Terug)", 20, OptionMode.Optional);
        DateTime minDate = new DateTime(1900, 1, 1);
        DateTime maxDate = new DateTime(2022, 1, 1);

        if (voornaam == string.Empty) return;

        var familienaam = LeesString("Familienaam", 30, OptionMode.Mandatory);
        var geboortedatum = LeesDatum("Geboortedatum (DD/MM/JJJJ)", minDate, maxDate, OptionMode.Mandatory);
        var telefoonnr = LeesString("TelefoonNr", 30, OptionMode.Optional);
        var kennismakingstekst = LeesString("Kennismaking Tekst", 255, OptionMode.Mandatory);
        var emailadres = LeesString("EmailAdres", 25, OptionMode.Mandatory);
        var beroep = LeesString("Beroep", 25, OptionMode.Optional);
        var firma = LeesString("Firma", 25, OptionMode.Optional);
        var facebooknaam = LeesString("FacebookNaam", 25, OptionMode.Optional);
        var websiteurl = LeesString("Website URL", 25, OptionMode.Optional);
        var geslacht = LeesString("Geslacht (M, V)", 1, OptionMode.Mandatory);
        var woonthiersinds = LeesDatum("Woont hier sinds (DD/MM/YYYY)", minDate, maxDate, OptionMode.Optional);

        // Kies taal
        while(true)
        {
            var talen = accountService.GetAllTalenAsync().Result;
            var taal = (Taal)LeesLijst($"Kies taal\n----------\n", talen, talen.Select(t => t.TaalId + "\t" + t.TaalNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;

            if (taal == null) break;

            ToonInfoBoodschap($"De gekozen taal is {taal.TaalCode} - {taal.TaalNaam}.");
            KiesGeboorteplaats();
        }


        // Login
        Console.WriteLine("\n-->Ingave Login");

        string gebruikersnaam = string.Empty;
        string wachtwoord = string.Empty;

        Geslacht hetGeslacht = Geslacht.M;
        if (geslacht == "M")
            hetGeslacht = Geslacht.M;
        else if (geslacht == "V")
            hetGeslacht = Geslacht.V;



        while (true)
        {
            gebruikersnaam = LeesString("LoginNaam", 25, OptionMode.Mandatory)!;
            wachtwoord = LeesString("Wachtwoord", 255, OptionMode.Mandatory)!;
            if (!accountService.LoginBestaatAsync(gebruikersnaam).Result) break;
            ToonFoutBoodschap("Deze login is reeds in gebruik.");
        }

        Console.WriteLine();

        // Toevoegen profiel
        var profiel = new Profiel()
        {
            VoorNaam = voornaam!,
            FamilieNaam = familienaam!,
            GeboorteDatum = geboortedatum!,
            TelefoonNr = telefoonnr,
            KennismakingTekst = kennismakingstekst,
            EmailAdres = emailadres!,
            BeroepTekst = beroep,
            FirmaNaam = firma,
            FacebookNaam = facebooknaam,
            WebsiteAdres = websiteurl,
            Geslacht = hetGeslacht,
            CreatieTijdstip = DateTime.Now,
            LaatsteUpdateTijdstip = DateTime.Now,
            WoontHierSindsDatum = woonthiersinds
        };

        // Overzicht
        ToonGegevens(profiel);

        // Bevestiging + Bewaren
        if ((bool)LeesBool("Bewaren OK ?", OptionMode.Mandatory)!)
        {
            profiel = accountService.VoegProfielToeAsync(profiel).Result;
            ToonInfoBoodschap($"U werd toegevoegd als profiel (id: {profiel.PersoonId}).");
        }
        else
            ToonInfoBoodschap("U werd niet toegevoegd als profiel.");
    }

    
    public static void KiesGeboorteplaats()
    {

    }
    
    
    public static void ToonPersoonGegevens(Persoon persoon)
    {

    }

    public static void ToonGegevens(Profiel profiel)
    {

    }

    public static void WijzigGegevens()
    {
    }

    public static void VerwijderGegevens()
    {
    }

    public static void InvoerenNieuwBericht()
    {
    }

    public static void RaadplegenBerichten()
    {
    }

    public static void AntwoordBericht()
    {
    }

    public static void WijzigBericht()
    {
    }

    public static void VerwijderBericht()
    {
    }

    //public static Bericht? KiesBericht(string titel, OptionMode optionMode)
    //{
    //}
}