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
                    new MenuAction (06,"<T>oon profielgegevens", "Profielgegevens",MenuItemActive.Disabled, MenuItemVisible.Hidden,ToonGegevens),
                    new MenuAction (07,"<W>ijzig profielgegevens", "Wijzigen profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,WijzigGegevens),
                    new MenuAction (08,"<V>erwijder profiel","Verwijderen profiel",MenuItemActive.Disabled, MenuItemVisible.Hidden,VerwijderProfiel),
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
        01, null, "Raadplegen bericht", MenuItemActive.Disabled, MenuItemVisible.Hidden, Direction.Horizontal, new List<MenuItem>
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
        string naam = LeesString("Geef de naam van het profiel dat goedgekeurd moet worden <Enter>=Terug:", 10, OptionMode.Optional)!;
        var userId = accountService.GetPersoonIdByNameAsync(naam).Result;
        var profiel = (Profiel)context.Personen.Find(userId)!;
        profiel.GoedgekeurdTijdstip = DateTime.Now;
        Console.WriteLine($"{profiel.LoginNaam} is goedgekeurd...");
        profiel.LaatsteUpdateTijdstip = DateTime.Now;
        context.SaveChanges();

    }

    public static void BlokkerenProfiel()
    {
        string naam = LeesString("Geef de naam van het profiel dat geblokkeerd moet worden <Enter>=Terug:", 10, OptionMode.Optional)!;
        var userId = accountService.GetPersoonIdByNameAsync(naam).Result;
        var profiel = (Profiel)context.Personen.Find(userId)!;
        profiel.Geblokkeerd = true;
        ToonInfoBoodschap($"{profiel.LoginNaam} is geblokkeerd");
        profiel.LaatsteUpdateTijdstip = DateTime.Now;
        context.SaveChanges();
    }

    public static void DeblokkerenProfiel()
    {
        string naam = LeesString("Geef de naam van het profiel dat gedeblokkeerd moet worden <Enter>=Terug:", 10, OptionMode.Optional)!;
        var userId = accountService.GetPersoonIdByNameAsync(naam).Result;
        var profiel = (Profiel)context.Personen.Find(userId)!;
        profiel.Geblokkeerd = false;
        ToonInfoBoodschap($"{profiel.LoginNaam} is gedeblokkeerd");
        profiel.LaatsteUpdateTijdstip = DateTime.Now;
        context.SaveChanges();
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
                ToonFoutBoodschap("De gebruiker werd niet gevonden. Probeer opnieuw");
                return;
            }

            if (userId != -1)
            {
                account = accountService.GetPersoonByIdAsync(userId).Result;

                var wachtwoord = LeesString("Wachtwoord", 50);
                if (wachtwoord == String.Empty) return;

                if (account.LoginPaswoord == wachtwoord)
                    loginOk = true;
                else
                {
                    while (!loginOk)
                    {
                        ToonFoutBoodschap("Fout wachtwoord");
                        account.VerkeerdeLoginsAantal++;
                        wachtwoord = LeesString("Wachtwoord", 50);
                        if (account.LoginPaswoord == wachtwoord) loginOk = true;
                    }
                }

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
            {
                ToonInfoBoodschap("Inloggen met succes voltooid");
                CurrentAccount = account;
                SetLabel(menu, new List<int> { 3 }, $"Ingelogd als '{(account.LoginNaam.Length > 5 ? string.Concat(account.LoginNaam.AsSpan(0, 5), "...") : account.LoginNaam)}'");


                // Menu
                SetVisible(menu, new List<int> { 4, 6, 9, 10, 11 }, MenuItemVisible.Visible);
                SetActive(menu, new List<int> { 4, 6, 9, 10, 11 }, MenuItemActive.Enabled);
                SetActive(menu, new List<int> { 3, 5 }, MenuItemActive.Disabled);
                SetVisible(menu, new List<int> { 3, 5 }, MenuItemVisible.Hidden);
            }
            else
            {
                Profiel profiel = (Profiel)account;
                if (profiel.GoedgekeurdTijdstip != null)
                {
                    ToonInfoBoodschap("Inloggen met succes voltooid");
                    CurrentAccount = profiel;
                    SetLabel(menu, new List<int> { 3 }, $"Ingelogd als '{(account.LoginNaam.Length > 5 ? string.Concat(account.LoginNaam.AsSpan(0, 5), "...") : account.LoginNaam)}'");

                    // Menu
                    SetVisible(menu, new List<int> { 4, 6, 7, 8, 12, 13 }, MenuItemVisible.Visible);
                    SetVisible(menuBerichten, new List<int> { 1, 2, 3, 4 }, MenuItemVisible.Visible);
                    SetActive(menu, new List<int> { 4, 6, 7, 8, 12, 13 }, MenuItemActive.Enabled);
                    SetActive(menuBerichten, new List<int> { 1, 2, 3, 4 }, MenuItemActive.Enabled);
                    SetActive(menu, new List<int> { 3, 5 }, MenuItemActive.Disabled);
                    SetVisible(menu, new List<int> { 3, 5 }, MenuItemVisible.Hidden);
                }
                else
                {
                    ToonInfoBoodschap("Je profiel is nog niet goedgekeurd, contacteer eerst een medewerker");
                }
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
        var talen = accountService.GetAllTalenAsync().Result;
        var taal = (Taal)LeesLijst($"Kies taal\n----------\n", talen, talen.Select(t => t.TaalNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;

        ToonInfoBoodschap($"De gekozen taal is {taal.TaalCode} - {taal.TaalNaam}.");


        // Kies geboorteplaats
        Console.WriteLine("Kies geboorteplaats\n-----------------------");
        var letters = LeesString("Geef een aantal letters in van de gemeente", 5, OptionMode.Optional);
        if (letters == null) letters = "";
        var gemeentes = accountService.GetAllGemeenteAsync(letters).Result;
        var gemeente = (Gemeente)LeesLijst("", gemeentes, gemeentes.Select(g => g.GemeenteNaam).ToList(), SelectionMode.Single, OptionMode.Optional).FirstOrDefault()!;

        ToonInfoBoodschap($"De gekozen geboorteplaats is {gemeente.GemeenteNaam}.");

        // Ingave Adres
        Console.WriteLine("\n--> Ingave Adres");
        Console.WriteLine("Kies Woonplaats\n-----------------------");
        var lettersWoonplaats = LeesString("Geef een aantal letters in van de gemeente", 5, OptionMode.Optional);
        if (lettersWoonplaats == null) lettersWoonplaats = "";
        var gemeentez = accountService.GetAllGemeenteAsync(lettersWoonplaats).Result;
        var woonplaats = (Gemeente)LeesLijst("", gemeentez, gemeentez.Select(g => g.GemeenteNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;
        ToonInfoBoodschap($"De gekozen woonplaats is {woonplaats.GemeenteNaam}.");

        // Ingave Adres - Kies straat
        Console.WriteLine("Kies straat\n-----------------------");
        var lettersStraat = LeesString("Geef een aantal letters in van de straat", 5, OptionMode.Optional);
        if (lettersStraat == null) lettersStraat = "";
        var straten = accountService.GetAllStratenAsync(lettersStraat, woonplaats.GemeenteId).Result;
        var straat = (Straat)LeesLijst("", straten, straten.Select(s => s.StraatNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;
        ToonInfoBoodschap($"De gekozen straat is {straat.StraatNaam}.\n");

        // Ingave Adres - Huis & bus NR
        var huisnummer = LeesString("HuisNummer:", 5, OptionMode.Mandatory)!;
        var busnummer = LeesString("BusNummer:", 5, OptionMode.Optional);

        Adres adres = new Adres()
        {
            StraatId = straat.StraatId,
            Straat = straat,
            HuisNr = huisnummer,
            BusNr = busnummer,
        };



        Console.WriteLine("\n\n");

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


        // Toevoegen interesses
        Console.WriteLine("\n-->Ingave Interesses");
        var interessesoorten = accountService.GetAllInteressesAsync().Result;
        var profielinteresses = new List<ProfielInteresse>();
        var interessez = LeesLijst("Kies Interesses (gescheiden door een komma)", interessesoorten, interessesoorten.Select(i => i.InteresseSoortNaam).ToList(), SelectionMode.Multiple, OptionMode.Optional);
        foreach (InteresseSoort intres in interessez)
        {
            string text = LeesString($"Tekst voor {intres.InteresseSoortNaam}", 255, OptionMode.Optional);
            var intresse = new ProfielInteresse()
            {
                InteresseSoortId = intres.InteresseSoortId,
                InteresseSoort = intres,
                ProfielInteresseTekst = text
            };
            profielinteresses.Add(intresse);

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
            WoontHierSindsDatum = woonthiersinds,
            Taal = taal,
            TaalId = taal.TaalId,
            Adres = adres,
            AdresId = adres.AdresId,
            LoginAantal = 0,
            LoginNaam = gebruikersnaam,
            LoginPaswoord = wachtwoord,
            GeboorteplaatsId = gemeente.GemeenteId,
            Geboorteplaats = gemeente
        };

        foreach (ProfielInteresse intresse in profielinteresses)
        {
            intresse.Profiel = profiel;
            intresse.PersoonId = profiel.PersoonId;
            profiel.ProfielInteresses.Add(intresse);
        }

        // Overzicht
        ToonPersoonGegevens(profiel);

        // Bevestiging + Bewaren
        if ((bool)LeesBool("Bewaren OK ?", OptionMode.Mandatory)!)
        {
            profiel = accountService.VoegProfielToeAsync(profiel).Result;
            ToonInfoBoodschap($"U werd toegevoegd als profiel (id: {profiel.PersoonId}).");
            context.SaveChanges();
        }
        else
            ToonInfoBoodschap("U werd niet toegevoegd als profiel.");
    }


    public static void ToonPersoonGegevens(Persoon persoon)
    {
        Console.WriteLine("---------\nOverzicht\n---------\n");
        Console.WriteLine($"Naam: {persoon.VoorNaam} {persoon.FamilieNaam}");
        Console.WriteLine();

        string busnr = String.Empty;
        if (persoon.Adres.BusNr != null)
            busnr = persoon.Adres.BusNr;
        Console.WriteLine($"Adres:  {persoon.Adres.Straat.StraatNaam} {persoon.Adres.HuisNr} {busnr}");
        Console.WriteLine($"\t{persoon.Adres.Straat.Gemeente.PostCode} {persoon.Adres.Straat.Gemeente.GemeenteNaam}");
        Console.WriteLine($"\t{persoon.Adres.Straat.Gemeente.Provincie.ProvincieNaam}");
        Console.WriteLine();

        Console.WriteLine($"Geboortedatum: {persoon.GeboorteDatum}");
        Console.WriteLine($"Geboren in: {persoon.Geboorteplaats.GemeenteNaam}");

        string gender = "Man";
        if (persoon.Geslacht == Geslacht.V)
            gender = "Vrouw";
        else
            gender = "Man";
        Console.WriteLine($"Geslacht: {gender}");

        Console.WriteLine($"Taal: {persoon.Taal.TaalNaam}");
        Console.WriteLine();

        Console.WriteLine($"TelefoonNr: {persoon.TelefoonNr}");
        Console.WriteLine();

        string geblokkeerd = "Niet";
        if (persoon.Geblokkeerd)
            geblokkeerd = "Wel";
        else
            geblokkeerd = "Niet";

        Console.WriteLine($"Login: {persoon.LoginNaam}/{persoon.LoginPaswoord} {geblokkeerd} Geblokkeerd");
        Console.WriteLine($"Aantal keer ingelogd: {persoon.LoginAantal} Aantal verkeerd: {persoon.VerkeerdeLoginsAantal}");

        if (persoon is Profiel)
        {
            Profiel profiel = (Profiel)persoon;

            Console.WriteLine($"Woont hier sinds: {profiel.WoontHierSindsDatum}");
            Console.WriteLine($"Emailadres: {profiel.EmailAdres}");
            Console.WriteLine($"Facebook: {profiel.FacebookNaam}");
            Console.WriteLine($"Website: {profiel.WebsiteAdres}");
            Console.WriteLine($"Beroep: {profiel.BeroepTekst}");
            Console.WriteLine();

            Console.WriteLine($"Profiel goedgekeurd op: {profiel.GoedgekeurdTijdstip}");
            Console.WriteLine($"Aangemaakt op: {profiel.CreatieTijdstip}");
            Console.WriteLine($"Laatste wijziging: {profiel.LaatsteUpdateTijdstip}");
            Console.WriteLine();

            Console.WriteLine($"Kennismakingstekst:\n{profiel.KennismakingTekst}");
            Console.WriteLine();

            Console.WriteLine("Interesses:");
            foreach (ProfielInteresse intres in profiel.ProfielInteresses)
            {
                Console.WriteLine($"\t{intres.InteresseSoort.InteresseSoortNaam}\t\t{intres.ProfielInteresseTekst}");
            }
            Console.WriteLine();

        }
    }

    public static void ToonGegevens()
    {
        ToonPersoonGegevens(CurrentAccount);
    }

    public static void WijzigGegevens()
    {
        DateTime minDate = new DateTime(1900, 1, 1);
        DateTime maxDate = new DateTime(2023, 1, 1);

        
        var stringlijst = new List<string>()
        {
            "Voornaam",
            "Familienaam",
            "Geboortedatum",
            "Telefoonnummer",
            "Kennismakingstekst",
            "Email",
            "Beroep",
            "Firma",
            "Facebooknaam",
            "Website",
            "Geslacht",
            "Woont hier sinds",
            "Taal",
            "Geboorteplaats",
            "Adres",
            "Paswoord",
            "Interesses"
        };

        var displayvalues = new List<string>();
        stringlijst.ForEach(i => displayvalues.Add(i));
        var keuze = LeesLijst("Wijzigen Profiel", stringlijst, displayvalues, SelectionMode.Single, OptionMode.Optional).FirstOrDefault();

        Profiel profiel = (Profiel)CurrentAccount;


        while (keuze != null)
        {
            switch (keuze)
            {
                case "Voornaam":
                    {
                        profiel.VoorNaam = LeesString("Voornaam: ", 20, OptionMode.Mandatory);
                        ToonInfoBoodschap("Voornaam is gewijzigd");
                        break;
                    }
                case "Familienaam":
                    {
                        profiel.FamilieNaam = LeesString("Familienaam: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Familienaam is gewijzigd");
                        break;
                    }
                case "Geboortedatum": 
                    {
                        profiel.GeboorteDatum = LeesDatum("Geboortedatum: ", minDate, maxDate, OptionMode.Mandatory);
                        ToonInfoBoodschap("Geboortedatum is gewijzigd");
                        break;
                    }
                case "Telefoonnummer":
                    {
                        profiel.TelefoonNr = LeesString("Telefoonnummer: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Telefoonnummer is gewijzigd");
                        break;
                    }
                case "Kennismakingstekst":
                    {
                        profiel.KennismakingTekst = LeesString("Kennismakingstekst: ", 255, OptionMode.Mandatory);
                        ToonInfoBoodschap("Kennismakingstekst is gewijzigd");
                        break;
                    }
                case "Email":
                    {
                        profiel.EmailAdres = LeesString("Emailadres: ", 50, OptionMode.Mandatory);
                        ToonInfoBoodschap("Emailadres is gewijzigd");
                        break;
                    }
                case "Beroep":
                    {
                        profiel.BeroepTekst = LeesString("Beroep: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Beroep is gewijzigd");
                        break;
                    }
                case "Firma":
                    {
                        profiel.FirmaNaam = LeesString("Firmanaam: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Firma is gewijzigd");
                        break;
                    }
                case "Facebooknaam": 
                    {
                        profiel.FacebookNaam = LeesString("Facebooknaam: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Facebooknaam is gewijzigd");
                        break;
                    }
                case "Website": 
                    {
                        profiel.FirmaNaam = LeesString("Websitenaam: ", 50, OptionMode.Mandatory);
                        ToonInfoBoodschap("Website url is gewijzigd");
                        break;
                    }
                case "Geslacht":
                    {
                        var geslacht = LeesString("Geslacht (M/V): ", 1, OptionMode.Mandatory);
                        if (geslacht == "V")
                            profiel.Geslacht = Geslacht.V;
                        else
                            profiel.Geslacht = Geslacht.M;
                          
                        ToonInfoBoodschap("Geslacht is gewijzigd");
                        break;
                    }
                case "Woont hier sinds":
                    {
                        profiel.WoontHierSindsDatum = LeesDatum("Woont hier sinds: (yyyy/mm/dd)", minDate, maxDate, OptionMode.Mandatory);
                        ToonInfoBoodschap("Woont hier sinds is gewijzigd");
                        break;
                    }
                case "Taal":
                    {
                        var talen = accountService.GetAllTalenAsync().Result;
                        var taal = (Taal)LeesLijst($"Kies taal\n----------\n", talen, talen.Select(t => t.TaalNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;

                        ToonInfoBoodschap($"De gekozen taal is {taal.TaalCode} - {taal.TaalNaam}.");
                        ToonInfoBoodschap("Taal is gewijzigd");
                        break;
                    }
                case "Geboorteplaats":
                    {
                        Console.WriteLine("Kies geboorteplaats\n-----------------------");
                        var letters = LeesString("Geef een aantal letters in van de gemeente:", 5, OptionMode.Optional);
                        if (letters == null) letters = "";
                        var gemeentes = accountService.GetAllGemeenteAsync(letters).Result;
                        var gemeente = (Gemeente)LeesLijst("", gemeentes, gemeentes.Select(g => g.GemeenteNaam).ToList(), SelectionMode.Single, OptionMode.Optional).FirstOrDefault()!;

                        ToonInfoBoodschap($"De gekozen geboorteplaats is {gemeente.GemeenteNaam}.");

                        profiel.Geboorteplaats = gemeente;

                        ToonInfoBoodschap("Geboorteplaats is gewijzigd");
                        break;
                    }
                case "Adres":
                    {
                        // Ingave Adres
                        Console.WriteLine("\n--> Ingave Adres");
                        Console.WriteLine("Kies Woonplaats\n-----------------------");
                        var lettersWoonplaats = LeesString("Geef een aantal letters in van de gemeente:", 5, OptionMode.Optional);
                        if (lettersWoonplaats == null) lettersWoonplaats = "";
                        var gemeentez = accountService.GetAllGemeenteAsync(lettersWoonplaats).Result;
                        var woonplaats = (Gemeente)LeesLijst("", gemeentez, gemeentez.Select(g => g.GemeenteNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;
                        ToonInfoBoodschap($"De gekozen woonplaats is {woonplaats.GemeenteNaam}.");

                        // Ingave Adres - Kies straat
                        Console.WriteLine("Kies straat\n-----------------------");
                        var lettersStraat = LeesString("Geef een aantal letters in van de straat:", 5, OptionMode.Optional);
                        if (lettersStraat == null) lettersStraat = "";
                        var straten = accountService.GetAllStratenAsync(lettersStraat, woonplaats.GemeenteId).Result;
                        var straat = (Straat)LeesLijst("", straten, straten.Select(s => s.StraatNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;
                        ToonInfoBoodschap($"De gekozen straat is {straat.StraatNaam}.\n");

                        // Ingave Adres - Huis & bus NR
                        var huisnummer = LeesString("HuisNummer:", 5, OptionMode.Mandatory)!;
                        var busnummer = LeesString("BusNummer:", 5, OptionMode.Optional);

                        profiel.Adres = new Adres()
                        {
                            StraatId = straat.StraatId,
                            Straat = straat,
                            HuisNr = huisnummer,
                            BusNr = busnummer,
                        };
                        ToonInfoBoodschap("Adres is gewijzigd");
                        break;
                    }
                case "Paswoord":
                    {
                        profiel.LoginPaswoord = LeesString("Paswoord: ", 30, OptionMode.Mandatory);
                        ToonInfoBoodschap("Paswoord is gewijzigd");
                        break;
                    }
                case "Interesses":
                    {
                        // Toevoegen interesses
                        Console.WriteLine("\n-->Ingave Interesses");
                        var interessesoorten = accountService.GetAllInteressesAsync().Result;
                        var profielinteresses = new List<ProfielInteresse>();
                        var interessez = LeesLijst("Kies Interesses (gescheiden door een komma)", interessesoorten, interessesoorten.Select(i => i.InteresseSoortNaam).ToList(), SelectionMode.Multiple, OptionMode.Optional);
                        foreach (InteresseSoort intres in interessez)
                        {
                            string text = LeesString($"Tekst voor {intres.InteresseSoortNaam}:", 255, OptionMode.Optional);
                            var intresse = new ProfielInteresse()
                            {
                                InteresseSoortId = intres.InteresseSoortId,
                                InteresseSoort = intres,
                                ProfielInteresseTekst = text
                            };
                            profielinteresses.Add(intresse);

                        }
                        foreach (ProfielInteresse interes in profielinteresses)
                            profiel.ProfielInteresses.Add(interes);

                        ToonInfoBoodschap("Interesses zijn gewijzigd");
                        break;
                    }
            }
            keuze = LeesLijst("Wijzigen Profiel", stringlijst, displayvalues, SelectionMode.Single, OptionMode.Optional).FirstOrDefault();

            if (keuze == null)
            {
                var exit = LeesString("Wijzigen OK ? Y/N", 1, OptionMode.Mandatory);
                if (exit.ToUpper() == "n")
                {
                    keuze = LeesLijst("Wijzigen Profiel", stringlijst, displayvalues, SelectionMode.Single, OptionMode.Optional);
                }
                else
                {
                    ToonInfoBoodschap("Uw profiel werd gewijzigd");
                    profiel.LaatsteUpdateTijdstip = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        
        
        
    }

    public static void VerwijderProfiel()
    {
        var keuze = LeesString("Verwijderen OK ? Y/N", 1, OptionMode.Mandatory);
        if (keuze.ToUpper() == "Y")
        {
            context.Personen.Remove(CurrentAccount);
            Uitloggen();
            context.SaveChanges();
            ToonInfoBoodschap("U werd verwijderd als gebruiker.");
        }
        else
            ToonInfoBoodschap("U werd niet verwijderd als gebruiker.");
        
    }

    public static void InvoerenNieuwBericht()
    {
        
        
        Profiel profiel = (Profiel)CurrentAccount;
        Gemeente deGemeente = CurrentAccount.Adres.Straat.Gemeente.Hoofdgemeente;
        if (deGemeente == null)
        {
            deGemeente = CurrentAccount.Adres.Straat.Gemeente;
        }
        Bericht hetBericht = new Bericht();

        var berichttypes = accountService.GetAllBerichtTypes().Result;
        string berichtTypeTekst = string.Empty;

        hetBericht.Gemeente= deGemeente;
        hetBericht.Profiel= profiel;

        hetBericht.BerichtType = (BerichtType)LeesLijst("Kies BerichtType", berichttypes, berichttypes.Select(b => b.BerichtTypeNaam).ToList(), SelectionMode.Single, OptionMode.Mandatory).FirstOrDefault()!;
        if (hetBericht.BerichtType.BerichtTypeTekst != null)
            berichtTypeTekst = hetBericht.BerichtType.BerichtTypeTekst;
        ToonInfoBoodschap($"Gekozen BerichtType is {hetBericht.BerichtType.BerichtTypeCode} - {hetBericht.BerichtType.BerichtTypeNaam} - {berichtTypeTekst}\n");

        hetBericht.BerichtTitel = (String)LeesString($"\t\tTitel Bericht", 50, OptionMode.Mandatory);
        hetBericht.BerichtTekst = (String)LeesString($"\t\tBericht", 255, OptionMode.Mandatory);
        var ok = (String)LeesString("Nieuw bericht toevoegen OK? Y/N?", 1, OptionMode.Mandatory);
        if (ok.ToUpper() == "Y")
        {
            hetBericht.BerichtTijdstip = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine($"Gemeente: {deGemeente.GemeenteNaam}");
            Console.WriteLine($"Berichttype: {hetBericht.BerichtType.BerichtTypeNaam}");
            Console.WriteLine($"Titel: {hetBericht.BerichtTitel}");
            Console.WriteLine($"Tekst: {hetBericht.BerichtTekst}");
            Console.WriteLine($"Tijdstip: {hetBericht.BerichtTijdstip}");
            Console.WriteLine($"Profiel: {hetBericht.BerichtType.BerichtTypeNaam}");

            context.Berichten.Add(hetBericht);
            context.SaveChanges();

            ToonInfoBoodschap("Het bericht werd toegevoegd.");

        }
        else
        {
            ToonInfoBoodschap("Het bericht werd niet toegevoegd");
        }

    }

    public static void RaadplegenBerichten()
    {
        string puntjesLijn = "......................................................";
        var deGemeente = CurrentAccount.Adres.Straat.Gemeente.Hoofdgemeente;
        if (deGemeente == null)
            deGemeente = CurrentAccount.Adres.Straat.Gemeente;
        var berichten = deGemeente.Berichten;

        Console.WriteLine($"Kies Berichten voor hoofdgemeente {deGemeente}");
        Console.WriteLine("--------------------------------------------------\n");

        foreach (Bericht bericht in berichten)
        {
            int counter = 0;
            var hoofdbericht = bericht.HoofdBericht;

            while (hoofdbericht != null)
            {
                counter++;
                hoofdbericht = hoofdbericht.HoofdBericht;
            }
            // hier is het een hoofdbericht als de counter 0 is
            if (counter == 0)
            {
                Console.WriteLine(puntjesLijn);
                Console.WriteLine($"--{bericht.BerichtId}--   Van: {bericht.Profiel.LoginNaam} Op: {bericht.BerichtTijdstip}");
                Console.WriteLine($"Type: {bericht.BerichtType.BerichtTypeNaam}");
                Console.WriteLine($"Titel: {bericht.BerichtTitel}");
                Console.WriteLine($"Tekst: {bericht.BerichtTekst}");
                if (bericht.Berichten == null)
                {
                    Console.WriteLine(puntjesLijn);
                    Console.WriteLine();
                }
            }
            else // hier is het dus geen hoofdbericht
            {
                for (int teller = counter; teller > 0; teller--)
                {

                }
            }

        }
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