namespace ArhiCRMv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Observatie")]
    public partial class Observatie
    {
        public int ID { get; set; }

        public int? ProiectID { get; set; }

        public string Descriere { get; set; }

        public virtual Proiect Proiect { get; set; }
    }
}
