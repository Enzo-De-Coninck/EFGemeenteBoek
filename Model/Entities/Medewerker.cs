using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Medewerker : Persoon
{
    // ----------
    // Properties
    // ----------
    public int AfdelingId { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Afdeling Afdeling { get; set; } = null!;
}