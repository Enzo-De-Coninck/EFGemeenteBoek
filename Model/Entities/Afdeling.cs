using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Afdeling
{
    // ----------
    // Properties
    // ----------
    public int AfdelingId { get; set; }
    public string AfdelingCode { get; set; } = null!;
    public string AfdelingNaam { get; set; } = null!;
    public string? AfdelingTekst { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();
}