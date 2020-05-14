using HealthCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace HealthSQLDB.Data
{
    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientAilments>()
                .HasKey(pa => new { pa.AilmentId, pa.PatientId });
            modelBuilder.Entity<PatientAilments>()
                .HasOne(pa => pa.Patient)
                .WithMany(p => p.PatientAilments)
                .HasForeignKey(pa => pa.PatientId);
            modelBuilder.Entity<PatientAilments>()
                .HasOne(pa => pa.Ailment)
                .WithMany(a => a.PatientAilments)
                .HasForeignKey(pa => pa.AilmentId);

            modelBuilder.Entity<PatientMedications>()
                .HasKey(pm => new { pm.PatientId, pm.MedicationId });
            modelBuilder.Entity<PatientMedications>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.PatientMedications)
                .HasForeignKey(pm => pm.PatientId);
            modelBuilder.Entity<PatientMedications>()
                .HasOne(pm => pm.Medication)
                .WithMany(m => m.PatientMedications)
                .HasForeignKey(pm => pm.MedicationId);

            modelBuilder.Entity<Ailment>()
                .HasData(new Ailment { Id = 1 , Name = "Covid-19" }, new Ailment { Id = 2, Name = "Manflu" }, 
                    new Ailment{ Id = 3, Name = "Broken bone"}, new Ailment{ Id = 4, Name = "tyfus"}, new Ailment{Id=5, Name = "Stubed Tow"}, new Ailment{ Id = 6, Name = "Depression" }, new Ailment { Id = 7, Name = "Chinkunguya" }, new Ailment { Id = 8, Name = "Ebola" }, new Ailment { Id = 9, Name = "Krim-Kongo-feber" }, new Ailment { Id = 10, Name = "Lassafeber" }, new Ailment { Id = 11, Name = "MERS" }, new Ailment { Id = 12, Name = "Nipahvirus" }, new Ailment { Id = 13, Name = "Zikafeber" }, new Ailment { Id = 14, Name = "Flu" }, new Ailment { Id = 15, Name = "Fat liver" });
            modelBuilder.Entity<Patient>()
                .HasData(new Patient {PatientId = 1,  Name = "Ola Nordmann" });
            modelBuilder.Entity<PatientAilments>()
                .HasData(new PatientAilments { AilmentId = 1, PatientId = 1 });
            modelBuilder.Entity<Medication>()
               .HasData(new Medication { Id = 1, Name = "Man up" }, new Medication { Id = 2, Name = "No Cure" }, new Medication { Id = 3, Name = "Ibux" }, new Medication { Id = 4, Name = "Sunshine" }, new Medication { Id = 5, Name = "Kondoms" }, new Medication { Id = 6, Name = "Scream" }, new Medication { Id = 7, Name = "HPV vaksine" }, new Medication { Id = 8, Name = "Ice cream" }, new Medication { Id = 9, Name = "Hug" }, new Medication { Id = 10, Name = "Antibiotics" }, new Medication { Id = 11, Name = "Flushoot" });
        }

        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
      
    }
}
