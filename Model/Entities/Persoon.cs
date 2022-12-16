using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public abstract class Persoon
{
    // ----------
    // Properties
    // ----------
    public int PersoonId { get; set; }
    public string VoorNaam { get; set; } = null!;
    public string FamilieNaam { get; set; } = null!;
    public Geslacht Geslacht { get; set; }
    public DateTime? GeboorteDatum { get; set; }
    public int AdresId { get; set; }
    public int? GeboorteplaatsId { get; set; }
    public bool Geblokkeerd { get; set; }
    public string? TelefoonNr { get; set; }
    public string LoginNaam { get; set; } = null!;
    public string LoginPaswoord { get; set; } = null!;
    public int VerkeerdeLoginsAantal { get; set; }
    public int LoginAantal { get; set; }
    public int TaalId { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Adres Adres { get; set; } = null!;
    public virtual Gemeente? Geboorteplaats { get; set; }
    public virtual Taal Taal { get; set; } = null!;
    public virtual Afdeling Afdeling { get; set; } = null!;

}