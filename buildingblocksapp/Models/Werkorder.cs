namespace buildingblocksapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Werkorder")]
    public partial class Werkorder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Werkorder()
        {
            Orderpicks = new HashSet<Orderpick>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long werkorderid { get; set; }

        public long? orderid { get; set; }

        [StringLength(5)]
        public string productielijn { get; set; }

        public DateTime? leverperiode { get; set; }

        public bool? akkoordPlanning { get; set; }

        public bool? akkoordAccountmanager { get; set; }

        public virtual Klantorder Klantorder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderpick> Orderpicks { get; set; }
    }
}
