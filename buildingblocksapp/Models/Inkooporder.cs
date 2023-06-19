namespace buildingblocksapp.Models
{
    public class Inkooporder
    {
        //Properties
        public long InkooporderId { get; set; }
        public DateTime PeriodeBinnenkomst { get; set; }
        public DateTime PeriodeVerwerkt { get; set; }
        public int Rood { get; set; }
        public int Grijs { get; set; }
        public int Blauw { get; set; }


        //Relationships
        public List<InkooporderCorrectie> InkooporderCorrecties { get; set; } = new List<InkooporderCorrectie>();
    }
}
