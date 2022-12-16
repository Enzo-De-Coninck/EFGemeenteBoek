using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Gemeente
{

    // ----------
    // Properties
    // ----------
    public int GemeenteId { get; set; }
    public string GemeenteNaam { get; set; } = null!;
    public int PostCode { get; set; }
    public int ProvincieId { get; set; }
    public int? HoofdGemeenteId { get; set; }
    public int TaalId { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Provincie Provincie { get; set; } = null!;
    public virtual Gemeente? Hoofdgemeente { get; set; }
    public virtual ICollection<Gemeente>? Deelgemeenten { get; set; }
    public virtual Taal Taal { get; set; } = null!;
    public virtual ICollection<Persoon>? Personen { get; set; } = new List<Persoon>();
    public virtual ICollection<Bericht>? Berichten { get; set; } = new List<Bericht>();
}