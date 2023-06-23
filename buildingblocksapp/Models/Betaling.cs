using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildingblocksapp.Models {
    public class Betaling {
        public int BetalingId { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Betalingsdatum { get; set; }
        [Required, DataType(DataType.Currency), Column(TypeName = "decimal(18,2)"), DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Bedrag { get; set; }
        public int FactuurId { get; set; }
        public Factuur? Factuur { get; set; } = null!;

        // Methods
        public void UpdateBetaalstatus() {
            Factuur?.UpdateBetaalstatus();
        }

    }
}