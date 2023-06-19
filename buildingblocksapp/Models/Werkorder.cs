using System.Security.Principal;

namespace buildingblocksapp.Models
{
    public class Werkorder
    {
        //Properties
        public long WerkorderId { get; set; }
        public long OrderId { get; set; }
        public string Productielijn { get; set; }
        public DateTime LeverPeriode { get; set; }
        public bool AkkoordPanning { get; set; }
        public bool AkkoordAccountmanager { get; set; }


        //Relationships
        public List<Orderpick> Orderpicks { get; set; } = new List<Orderpick>();
        public List<Klantorder> Klantorders { get; set; } = new List<Klantorder>();
    }
}
