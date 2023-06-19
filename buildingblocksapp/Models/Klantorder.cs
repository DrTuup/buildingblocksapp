namespace buildingblocksapp.Models
{
    public class Klantorder
    {
        // Properties
        public int KlantorderId { get; set; }
        public string Naam { get; set; } = null!;
        public int Aantal { get; set; }
        public string Type { get; set; } = null!;
        public int Referentienummer { get; set; }
        public bool AkkoordAccountmanager { get; set; }

        // Relationships
        public List<Werkorder> Werkorders { get; set; } = new();
    }
}