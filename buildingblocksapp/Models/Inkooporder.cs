using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildingblocksapp.Models
{
    public class Inkooporder
    {
        //Properties
        [Key, Required]
        public int InkooporderId { get; set; }
        [Required, ForeignKey("InkooporderCorrectie")]
        public int InkooporderCorrectieId { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime PeriodeBinnenkomst { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime PeriodeVerwerkt { get; set; }
        [Required]
        public int Rood { get; set; } = 0;
        [Required]
        public int Grijs { get; set; } = 0;
        [Required]
        public int Blauw { get; set; } = 0;


        //Relationships
        public InkooporderCorrectie InkooporderCorrectie { get; set; }
    }
}
