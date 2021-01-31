namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Proiect")]
    public partial class Proiect
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proiect()
        {
            AvizToProiectMappings = new HashSet<AvizToProiectMapping>();
            Observaties = new HashSet<Observatie>();
            Platas = new HashSet<Plata>();
            ProiectTehnicToProiectMappings = new HashSet<ProiectTehnicToProiectMapping>();
            ResponsabilitateToProiectMappings = new HashSet<ResponsabilitateToProiectMapping>();
            StudiuToProiectMappings = new HashSet<StudiuToProiectMapping>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }

        [StringLength(255)]
        public string An { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(255)]
        public string NrProiect { get; set; }

        [StringLength(255)]
        public string NrContract { get; set; }

        public int? Valoare { get; set; }

        [StringLength(255)]
        public string Recomandare { get; set; }

        public int? TipProiectID { get; set; }

        public int? StatusID { get; set; }

        public int? BeneficiarID { get; set; }

        public int? AmplasamentID { get; set; }

        public virtual Amplasament Amplasament { get; set; }

        public IEnumerable<SelectListItem> LocalitateSubCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AvizToProiectMapping> AvizToProiectMappings { get; set; }

        public virtual Beneficiar Beneficiar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observatie> Observaties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plata> Platas { get; set; }

        public virtual Status Status { get; set; }

        public virtual TipProiect TipProiect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProiectTehnicToProiectMapping> ProiectTehnicToProiectMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResponsabilitateToProiectMapping> ResponsabilitateToProiectMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudiuToProiectMapping> StudiuToProiectMappings { get; set; }
    }
}
