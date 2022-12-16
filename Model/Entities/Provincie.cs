using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Provincie
{
    // ----------
    // Properties
    // ----------
    public int ProvincieId { get; set; }
    public string ProvincieCode { get; set; } = null!;
    public string ProvincieNaam { get; set; } = null!;


    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<Gemeente> Gemeenten { get; set; } = new List<Gemeente>();
}