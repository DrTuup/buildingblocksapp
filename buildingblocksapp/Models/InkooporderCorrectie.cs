using System.ComponentModel.DataAnnotations;

namespace buildingblocksapp.Models
{
    public class InkooporderCorrectie
    {
        //Properties
        [Required, Key]
        public int InkooporderCorrectieId { get; set; }
        [Required]
        public int InkooporderId { get; set; }
        [Required]
        public int Rood { get; set; } = 0;
        [Required]
        public int Grijs { get; set; } = 0;
        [Required]
        public int Blauw { get; set; } = 0;

        //Relationships
        public Inkooporder Inkooporder { get; set; } = null!;
    }
}
