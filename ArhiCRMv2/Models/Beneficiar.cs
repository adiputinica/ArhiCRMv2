namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beneficiar")]
    public partial class Beneficiar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beneficiar()
        {
            Proiects = new HashSet<Proiect>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }

        [StringLength(255)]
        public string Adresa { get; set; }

        [StringLength(255)]
        public string CNP { get; set; }

        [StringLength(255)]
        public string Telefon { get; set; }

        [StringLength(255)]
        public string SerieCI { get; set; }

        [StringLength(255)]
        public string NumarCI { get; set; }

        [StringLength(255)]
        public string PersoanaContact { get; set; }

        [StringLength(255)]
        public string TelefonPersoanaContact { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proiect> Proiects { get; set; }
    }
}
