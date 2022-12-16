namespace Model.Entities;

public class BerichtType
{
    // ----------
    // Properties
    // ----------
    public int BerichtTypeId { get; set; }
    public string BerichtTypeCode { get; set; } = null!;
    public string BerichtTypeNaam { get; set; } = null!;
    public string BerichtTypeTekst { get; set; }



    // ---------------------
    // Navigation properties
    // ---------------------
    public virtual ICollection<Bericht> Berichten { get; set; } = new List<Bericht>();
}