namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResponsabilitateBeneficiar")]
    public partial class ResponsabilitateBeneficiar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResponsabilitateBeneficiar()
        {
            ResponsabilitateToProiectMappings = new HashSet<ResponsabilitateToProiectMapping>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResponsabilitateToProiectMapping> ResponsabilitateToProiectMappings { get; set; }
    }
}
