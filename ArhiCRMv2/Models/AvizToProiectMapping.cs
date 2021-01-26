namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvizToProiectMapping")]
    public partial class AvizToProiectMapping
    {
        public int ID { get; set; }

        public int? ProiectID { get; set; }

        public int? AvizID { get; set; }

        public int? AvizatorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataDepunere { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataRidicare { get; set; }

        public bool? BeneficiarResposabil { get; set; }

        public virtual Aviz Aviz { get; set; }

        public virtual Avizator Avizator { get; set; }

        public virtual Proiect Proiect { get; set; }
    }
}
