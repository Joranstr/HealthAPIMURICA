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
                .HasData(new Ailment { Id = 1 , Name = "Covid-19" }, new Ailment { Id = 2, Name = "Manflu" } );
            modelBuilder.Entity<Patient>()
                .HasData(new Patient {PatientId = 1,  Name = "Ola Nordmann" });
            modelBuilder.Entity<PatientAilments>()
                .HasData(new PatientAilments { AilmentId = 1, PatientId = 1 });
            modelBuilder.Entity<Medication>()
               .HasData(new Medication { Id = 1, Name = "Man up" }, new Medication { Id = 2, Name = "No Cure" });
        }

        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
      
    }
}
