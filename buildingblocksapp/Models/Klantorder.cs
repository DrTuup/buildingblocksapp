using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace buildingblocksapp.Models
{
    public class Klantorder
    {
        // Properties
        [Key, Required]
        public int KlantorderId { get; set; }
        [Required]
        public string Naam { get; set; } = null!;
        [Required]
        public int Aantal { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime AanmaakDatum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime VertrekDatum { get; set; }
        [Required]
        public MotortypeEnum Type { get; set; }
        [Required]
        public string Referentienummer { get; set; } = null!;
        [Required]
        public bool AkkoordAccountmanager { get; set; }

        // Relationships
        public List<Werkorder> Werkorders { get; set; } = new();
        public Factuur? Factuur { get; set; }
        // Methods
        public string GenerateRandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }    
    }
}