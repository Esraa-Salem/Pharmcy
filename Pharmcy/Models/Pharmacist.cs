namespace Pharmcy.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pharmacist")]
    public partial class Pharmacist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pharmacist()
        {
            Customers = new HashSet<Customer>();
            Prescriptions = new HashSet<Prescription>();
            Inventories = new HashSet<Inventory>();
            Medicines = new HashSet<Medicine>();
        }

        [Key]
        public int ph_id { get; set; }

        [StringLength(50)]
        public string ph_name { get; set; }

        public float? ph_salary { get; set; }

        [StringLength(50)]
        public string ph_email { get; set; }
         
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Customer> Customers  { get; set; }
         
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
         
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }
         
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Medicine> Medicines { get; set; }
        public bool ShouldSerializeCustomers()
        {
            return Customers != null;
        }
        public bool ShouldSerializePrescriptions()
        {
            return Prescriptions != null;
        }
        public bool ShouldSerializeInventories()
        {
            return Inventories != null;
        }
        public bool ShouldSerializeMedicines()
        {
            return Medicines != null;
        }
    }
}
