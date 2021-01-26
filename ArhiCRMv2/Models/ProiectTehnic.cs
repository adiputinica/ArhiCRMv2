namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProiectTehnic")]
    public partial class ProiectTehnic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProiectTehnic()
        {
            ProiectTehnicToProiectMappings = new HashSet<ProiectTehnicToProiectMapping>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProiectTehnicToProiectMapping> ProiectTehnicToProiectMappings { get; set; }
    }
}
