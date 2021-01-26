namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResponsabilitateToProiectMapping")]
    public partial class ResponsabilitateToProiectMapping
    {
        public int ID { get; set; }

        public int? ProiectID { get; set; }

        public int? ResponsabilitateID { get; set; }

        public virtual Proiect Proiect { get; set; }

        public virtual ResponsabilitateBeneficiar ResponsabilitateBeneficiar { get; set; }
    }
}
