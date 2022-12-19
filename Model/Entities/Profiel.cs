using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Profiel : Persoon
{
    // ----------
    // Properties
    // ----------
    public string KennismakingTekst { get; set; } = null!;
    public DateTime? WoontHierSindsDatum { get; set; }
    public string? BeroepTekst { get; set; }
    public string? FirmaNaam { get; set; }
    public string? WebsiteAdres { get; set; }
    public string EmailAdres { get; set; } = null!;
    public string? FacebookNaam { get; set; }
    public DateTime? GoedgekeurdTijdstip { get; set; }
    public DateTime CreatieTijdstip { get; set; }
    public DateTime LaatsteUpdateTijdstip { get; set; }

    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<ProfielInteresse> ProfielInteresses { get; set; } = new List<ProfielInteresse>();
    public virtual ICollection<Bericht> Berichten { get; set; } = new List<Bericht>();
}