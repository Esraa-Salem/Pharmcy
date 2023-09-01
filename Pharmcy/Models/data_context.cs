using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pharmcy.Models
{
    public partial class data_context : DbContext
    {
        public data_context()
            : base("name=data_context")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Pharmacist> Pharmacists { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.c_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.c_email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.c_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Prescriptions)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.cust_id);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.in_name)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.in_location)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Medicines)
                .WithMany(e => e.Inventories)
                .Map(m => m.ToTable("Inv_Medicine").MapLeftKey("inv_id").MapRightKey("m_id"));

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Pharmacists)
                .WithMany(e => e.Inventories)
                .Map(m => m.ToTable("Ph_Inventory").MapLeftKey("inv_id").MapRightKey("ph_id"));

            modelBuilder.Entity<Medicine>()
                .Property(e => e.m_name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.m_category)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .HasMany(e => e.Pharmacists)
                .WithMany(e => e.Medicines)
                .Map(m => m.ToTable("Ph_Medicine").MapLeftKey("m_id").MapRightKey("ph_id"));

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.ph_email)
                .IsUnicode(false);
        }
    }
}
