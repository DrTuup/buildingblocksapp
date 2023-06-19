using System.ComponentModel.DataAnnotations;

namespace buildingblocksapp.Models
{
    public class Klantorder
    {
        // Properties
        [Key, Required]
        public int KlantorderId { get; set; }
        [Required]
        public string Naam { get; set; } = null!;
        [Required]
        public int Aantal { get; set; }
        [Required]
        public string Type { get; set; } = null!;
        [Required]
        public int Referentienummer { get; set; }
        [Required]
        public bool AkkoordAccountmanager { get; set; }

        // Relationships
        public List<Werkorder> Werkorders { get; set; } = new();
    }
}