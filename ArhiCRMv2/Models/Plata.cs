namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plata")]
    public partial class Plata
    {
        public int ID { get; set; }

        public int? ProiectID { get; set; }

        public decimal? Suma { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public virtual Proiect Proiect { get; set; }
    }
}
