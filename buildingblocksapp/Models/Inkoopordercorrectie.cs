namespace buildingblocksapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inkoopordercorrectie")]
    public partial class Inkoopordercorrectie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long inkooporderid { get; set; }

        public int? rood { get; set; }

        public int? grijs { get; set; }

        public int? blauw { get; set; }

        public virtual Inkooporder Inkooporder { get; set; }
    }
}
