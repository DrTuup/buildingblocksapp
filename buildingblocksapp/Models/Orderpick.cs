using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildingblocksapp.Models
{
    public class Orderpick
    {
        // Properties
        [Key, Required]
        public int OrderpickId { get; set; }
        [Required]
        public int WerkorderId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PeriodeAanvraag { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime PeriodeLevering { get; set; }
        [Required]
        public int Rood { get; set; }
        [Required]
        public int Grijs { get; set; }
        [Required]
        public int Blauw { get; set; }
        [Required]
        public bool AkkoordProductie { get; set; }

        // Relationships
        public Werkorder Werkorder { get; set; } = null!;
    }
}