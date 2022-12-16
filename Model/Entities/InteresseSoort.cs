using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class InteresseSoort
{
    // ----------
    // Properties
    // ----------
    public int InteresseSoortId { get; set; }
    public string InteresseSoortNaam { get; set; } = null!;


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<ProfielInteresse> ProfielInteresses { get; set; } = new List<ProfielInteresse>();
}