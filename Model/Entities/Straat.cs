using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Straat
{
    // ----------
    // Properties
    // ----------
    public int StraatId { get; set; }
    public string StraatNaam { get; set; } = null!;
    public int GemeenteId { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Gemeente Gemeente { get; set; } = null!;
    public virtual ICollection<Adres> Adressen { get; set; }
}