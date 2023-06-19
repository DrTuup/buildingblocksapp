namespace buildingblocksapp.Models
{
    public class Orderpick
    {
        // Properties
        public int OrderpickId { get; set; }
        public int WerkorderId { get; set; }
        public DateTime PeriodeAanvraag { get; set; }
        public DateTime PeriodeLevering { get; set; }
        public int Rood { get; set; }
        public int Grijs { get; set; }
        public int Blauw { get; set; }
        public bool AkkoordProductie { get; set; }

        // Relationships
        public Werkorder MyProperty { get; set; }
    }
}