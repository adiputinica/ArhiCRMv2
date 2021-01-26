namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudiuToProiectMapping")]
    public partial class StudiuToProiectMapping
    {
        public int ID { get; set; }

        public int? ProiectID { get; set; }

        public int? StudiuID { get; set; }

        public int? ColaboratorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataDepunere { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataRidicare { get; set; }

        public bool? SV { get; set; }

        public bool? BeneficiarResposabil { get; set; }

        public virtual Colaborator Colaborator { get; set; }

        public virtual Proiect Proiect { get; set; }

        public virtual Studiu Studiu { get; set; }
    }
}
