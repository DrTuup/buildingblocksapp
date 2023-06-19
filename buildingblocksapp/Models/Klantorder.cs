namespace buildingblocksapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klantorder")]
    public partial class Klantorder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klantorder()
        {
            Werkorders = new HashSet<Werkorder>();
        }

        [StringLength(255)]
        public string Naam { get; set; }

        public int? aantal { get; set; }

        [StringLength(5)]
        public string type { get; set; }

        [StringLength(255)]
        public string referentienummer { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderid { get; set; }

        public bool? akkoordAccountmanager { get; set; }

        public DateTime? aanmaakdatum { get; set; }

        public DateTime? voldaandatum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Werkorder> Werkorders { get; set; }
    }
}
