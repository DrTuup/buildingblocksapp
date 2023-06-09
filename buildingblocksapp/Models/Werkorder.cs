﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace buildingblocksapp.Models
{
    public class Werkorder
    {
        //Properties
        [Key, Required]
        public int WerkorderId { get; set; }
        [Required, ForeignKey("Klantorder")]
        public int KlantOrder { get; set; }
        [Required]
        public MotortypeEnum Motortype { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime LeverPeriode { get; set; }
        public bool AkkoordPanning { get; set; }


        //Relationships
        public Klantorder Klantorder { get; set; } = null!;
    }
}
