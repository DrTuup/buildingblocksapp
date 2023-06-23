using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildingblocksapp.Models
{
    public class Factuur
    {
        //Properties
        public int FactuurId { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Factuurdatum { get; set; } = DateTime.Now;
        [DataType(DataType.Currency), Column(TypeName = "decimal(18,2)"), DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotaalBedrag { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "decimal(18,2)"), DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal BetaaldBedrag { get; set; } = 0;
        public FactuurStatusEnum FactuurStatus { 
            get; set;
        } = FactuurStatusEnum.NietVoldaan;
        public ICollection<Betaling> Betalingen { get; set; } = new List<Betaling>();

        public int KlantorderId { get; set; }
        public Klantorder? Klantorder { get; set; } = null!;

        //Methods
        public void UpdateBetaalstatus()
        {
            Console.WriteLine("Updating betaalstatus");
            Decimal totaalBetaald = 0;
            if (Betalingen.Count == 0)
            {
                FactuurStatus = FactuurStatusEnum.NietVoldaan;
            }
            else
            {
                System.Console.WriteLine("Betalingen.Count: " + Betalingen.Count);
                foreach (Betaling betaling in Betalingen)
                {
                    Console.WriteLine("Betaling: " + betaling.Bedrag);
                    totaalBetaald += betaling.Bedrag;
                }
                if (totaalBetaald >= TotaalBedrag)
                {
                    FactuurStatus = FactuurStatusEnum.Voldaan;
                }
                else
                {
                    FactuurStatus = FactuurStatusEnum.GedeeltelijkVoldaan;
                }

                if(FactuurStatus != FactuurStatusEnum.Voldaan) {
                    // if 30 days have passed since FactuurDatum, send a reminder
                    if (Factuurdatum.AddDays(30) < DateTime.Now)
                    {
                        FactuurStatus = FactuurStatusEnum.Herinnering;
                    }
                    // if 60 days have passed since FactuurDatum, send to accountmanager
                    else if (Factuurdatum.AddDays(60) < DateTime.Now)
                    {
                        FactuurStatus = FactuurStatusEnum.Accountmanager;
                    }
                    // if 90 days have passed since FactuurDatum, and no regeling has been made, send to incassobureau
                    else if (Factuurdatum.AddDays(90) < DateTime.Now && FactuurStatus != FactuurStatusEnum.Regeling) {
                        FactuurStatus = FactuurStatusEnum.Incassobureau;
                    }
                }                
            }
            BetaaldBedrag = totaalBetaald;
            Console.WriteLine("FactuurStatus: " + FactuurStatus);
            Console.WriteLine("BetaaldBedrag: " + BetaaldBedrag);
        }
    }
}
