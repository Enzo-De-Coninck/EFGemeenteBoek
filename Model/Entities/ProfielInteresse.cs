using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class ProfielInteresse
{
    // ----------
    // Properties
    // ----------
    public int PersoonId { get; set; }
    public int InteresseSoortId { get; set; }
    public string ProfielInteresseTekst { get; set; }


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual Profiel Profiel { get; set; } = null!;
    public virtual InteresseSoort InteresseSoort { get; set; } = null!;

}