namespace Pharmcy.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        public int c_id { get; set; }

        [Required]
        [StringLength(50)]
        public string c_name { get; set; }
        public bool ShouldSerializec_name()
        {
            return c_name != null;
        }
        [StringLength(50)]
        public string c_email { get; set; }
        public bool ShouldSerializec_email()
        {
            return c_email != null;
        }

        [StringLength(11)]
        public string c_phone { get; set; }
        public bool ShouldSerializec_phone()
        {
            return c_phone != null;
        }
        [JsonIgnore]
        public int? ph_id { get; set; }
        [JsonIgnore]
        public virtual Pharmacist Pharmacist { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
