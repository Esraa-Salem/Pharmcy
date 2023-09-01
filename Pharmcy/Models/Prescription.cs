namespace Pharmcy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prescription")]
    public partial class Prescription
    {
        [Key]
        public int p_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? p_date { get; set; }

        public int? ph_id { get; set; }

        public int? cust_id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Pharmacist Pharmacist { get; set; }
    }
}
