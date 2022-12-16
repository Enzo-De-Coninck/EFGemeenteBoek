using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Taal
{
    // ----------
    // Properties
    // ----------
    public int TaalId { get; set; }
    public string TaalCode { get; set; } = null!;
    public string TaalNaam { get; set; } = null!;

    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<Persoon> Personen { get; set; } = new List<Persoon>();
    public virtual ICollection<Gemeente> Gemeenten { get; set; } = new List<Gemeente>();
}