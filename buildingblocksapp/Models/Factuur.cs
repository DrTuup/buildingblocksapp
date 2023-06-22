using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace buildingblocksapp.Models
{
    public class Factuur
    {
        //Properties
        [Key, Required]
        public int FactuurId { get; set; }
        [Required]
        public DateTime Factuurdatum { get; set; } = DateTime.Now;
        [Required, ForeignKey("Klantorder")]    
        public int KlantorderId { get; set; }
        [Required]
        public string TotaalBedrag { get; set; } = null!;
        [Required]
        public string VoldaanBedrag { get; set; } = null!;
        [Required]
        public string Betaaldatum { get; set; } = null!;
        [Required]
        public string Betaalstatus { get; set; } = null!;

        //Relationships
        public Klantorder Klantorder { get; set; } = null!;
    }
}
