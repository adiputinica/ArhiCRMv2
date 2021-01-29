namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Localitate")]
    public partial class Localitate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localitate()
        {
            Amplasaments = new HashSet<Amplasament>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }

        public int? JudetID { get; set; }

        public virtual Judet Judet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amplasament> Amplasaments { get; set; }
    }
}
