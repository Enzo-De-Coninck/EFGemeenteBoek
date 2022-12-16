using Model.Entities;
//using Model.Services;
using Model.Repositories;
using System.Text;
using System;

namespace UIConsole;

public partial class Program
{
    // ---------------------------------------
    // Static variables - Dependency Injection
    // ---------------------------------------
    private static readonly EFGemeenteBoekContext context = new EFGemeenteBoekContext();

    //private static readonly ISecurityRepository securityRepository = new SQLSecurityRepository(context);
    //private static readonly SecurityService securityService = new SecurityService(securityRepository);

    //private static readonly ISecurityRepository securityRepository = new SQLSecurityRepository(context);
    //private static readonly AccountService ProfielService = new AccountService(context);

    //private static readonly ISecurityRepository securityRepository = new SQLSecurityRepository(context);
    //private static readonly BerichtService BerichtService = new BerichtService(context);

    private static Persoon CurrentAccount { get; set; } = null!;
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
                    new MenuAction (04,"<U>itloggen", "Uitloggen",MenuItemActive.Disabled, MenuItemVisible.Visible,Uitloggen),
                    new MenuLijn (),
                    new MenuAction (05,"<R>egistreren", "Registeren",MenuItemActive.Enabled, MenuItemVisible.Visible,Registeren),
                    new MenuLijn (),
                    new MenuAction (06,"<T>oon profielgegevens", "Profielgegevens",MenuItemActive.Disabled, MenuItemVisible.Visible,ToonGegevens),
                    new MenuAction (07,"<W>ijzig profielgegevens", "Wijzigen profiel",MenuItemActive.Disabled, MenuItemVisible.Visible,WijzigGegevens),
                    new MenuAction (08,"<V>erwijder profiel","Verwijderen profiel",MenuItemActive.Disabled, MenuItemVisible.Visible,VerwijderGegevens),
                }
            ),
            new MenuLijn (),
            new MenuAction (09,"<G>oedkeuring nieuw profiel","Goedkeuren van een profiel",MenuItemActive.Disabled, MenuItemVisible.Visible,GoedkeurenNieuwProfiel),
            new MenuAction (10,"<B>lokkeren van een profiel","Blokkeer een profiel",MenuItemActive.Disabled, MenuItemVisible.Visible,BlokkerenProfiel),
            new MenuAction (11,"<D>eblokkeren van een profiel","Deblokkeer een profiel",MenuItemActive.Disabled, MenuItemVisible.Visible,DeblokkerenProfiel),
            new MenuLijn (),
            new MenuAction (12,"<N>ieuw bericht","Ingave nieuw bericht",MenuItemActive.Disabled, MenuItemVisible.Visible,InvoerenNieuwBericht),
            new MenuAction (13,"<R>aadplegen berichten van uw hoofdgemeente","Berichten van de hoofdgemeente",MenuItemActive.Disabled, MenuItemVisible.Visible,RaadplegenBerichten),
        }
    );

    public static SubMenu menuBerichten = new SubMenu
    (
        01, null, "Raadplegen bericht", MenuItemActive.Disabled, MenuItemVisible.Visible, Direction.Horizontal, new List<MenuItem>
        {
            new MenuAction (02,"<W>ijzigen","",MenuItemActive.Disabled, MenuItemVisible.Visible,WijzigBericht),
            new MenuAction (03,"<V>erwijderen","",MenuItemActive.Disabled, MenuItemVisible.Visible,VerwijderBericht),
            new MenuAction (04,"<A>ntwoorden","",MenuItemActive.Disabled, MenuItemVisible.Visible,AntwoordBericht),
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
    }

    public static void Uitloggen()
    {
    }

    public static void Registeren()
    {
    }

    public static void ToonGegevens(Persoon persoon)
    {
    }

    public static void ToonGegevens()
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