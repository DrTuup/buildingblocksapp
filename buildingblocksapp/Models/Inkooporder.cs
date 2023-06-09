namespace buildingblocksapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inkooporder")]
    public partial class Inkooporder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long inkooporderid { get; set; }

        public DateTime? periodeBinnenkomst { get; set; }

        public DateTime? periodeVerwerkt { get; set; }

        public int? rood { get; set; }

        public int? grijs { get; set; }

        public int? blauw { get; set; }

        public virtual Inkoopordercorrectie Inkoopordercorrectie { get; set; }
    }
}
