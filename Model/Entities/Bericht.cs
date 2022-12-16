using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Bericht
{
    // ----------
    // Properties
    // ----------
    public int BerichtId { get; set; }
    public int HoofdBerichtId { get; set; }
    public int GemeenteId { get; set; }
    public int PersoonId { get; set; }
    public int BerichtTypeId { get; set; }
    public DateTime BerichtTijdstip { get; set; }
    public string BerichtTitel { get; set; } = null!;
    public string BerichtTekst { get; set; } = null!;

    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Gemeente Gemeente { get; set; } = null!;
    public virtual Bericht HoofdBericht { get; set; }
    public virtual BerichtType BerichtType { get; set; } = null!;
    public virtual Profiel Profiel { get; set; } = null!;
    public virtual ICollection<Bericht> Berichten { get; set; }
}