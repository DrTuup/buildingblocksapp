namespace buildingblocksapp.Models
{
    public class InkooporderCorrectie
    {
        //Properties
        public long InkooporderId { get; set; }
        public int Rood { get; set; }
        public int Grijs { get; set; }
        public int Blauw { get; set; }

        //Relationships
        public List<Inkooporder> Inkooporders { get; set; } = new List<Inkooporder>();
    }
}
