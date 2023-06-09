namespace buildingblocksapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orderpick")]
    public partial class Orderpick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderpickid { get; set; }

        public long? werkorderid { get; set; }

        public DateTime? periodeAanvraag { get; set; }

        public DateTime? periodeLevering { get; set; }

        public int? rood { get; set; }

        public int? grijs { get; set; }

        public int? blauw { get; set; }

        public bool? akkoordProductie { get; set; }

        public virtual Werkorder Werkorder { get; set; }
    }
}
