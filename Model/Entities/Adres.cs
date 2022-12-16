using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Adres
{
    // ----------
    // Properties
    // ----------
    public int AdresId { get; set; }
    public int StraatId { get; set; }
    public string HuisNr { get; set; } = null!;
    public string? BusNr { get; set; }



    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Straat Straat { get; set; } = null!;
    public virtual ICollection<Persoon> Personen { get; set; } = new List<Persoon>();
}