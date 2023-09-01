namespace Pharmcy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicine")]
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            Inventories = new HashSet<Inventory>();
            Pharmacists = new HashSet<Pharmacist>();
        }

        [Key]
        public int m_id { get; set; }

        [Required]
        [StringLength(50)]
        public string m_name { get; set; }

        public double? m_price { get; set; }

        [StringLength(50)]
        public string m_category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pharmacist> Pharmacists { get; set; }
    }
}
