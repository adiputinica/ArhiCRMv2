namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amplasament")]
    public partial class Amplasament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Amplasament()
        {
            Proiects = new HashSet<Proiect>();
        }

        public int ID { get; set; }

        public decimal? SuprafataTerenMasurata { get; set; }

        public int? JudetID { get; set; }

        public int? LocalitateID { get; set; }

        [StringLength(255)]
        public string ComunaSat { get; set; }

        [StringLength(255)]
        public string Strada { get; set; }

        [StringLength(255)]
        public string Numar { get; set; }

        [StringLength(255)]
        public string Tarla { get; set; }

        [StringLength(255)]
        public string Parcela { get; set; }

        [StringLength(255)]
        public string NumarCadastral { get; set; }

        [StringLength(255)]
        public string NumarCF { get; set; }

        public virtual Judet Judet { get; set; }

        public virtual Localitate Localitate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proiect> Proiects { get; set; }
    }
}
