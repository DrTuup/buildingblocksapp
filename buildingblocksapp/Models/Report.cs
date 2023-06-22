namespace buildingblocksapp.Models
{
    public class Report
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Referentie { get; set; }
        public int Rood { get; set; }
        public int Grijs { get; set; }
        public int Blauw { get; set; }
        public MotortypeEnum Type { get; set; }
        public int Aantal { get; set; }
    }
}
