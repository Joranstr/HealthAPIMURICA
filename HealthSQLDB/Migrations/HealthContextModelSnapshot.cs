﻿// <auto-generated />
using HealthSQLDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthSQLDB.Migrations
{
    [DbContext(typeof(HealthContext))]
    partial class HealthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthCore.Domain.Model.Ailment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ailments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Covid-19"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manflu"
                        });
                });

            modelBuilder.Entity("HealthCore.Domain.Model.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Man up"
                        },
                        new
                        {
                            Id = 2,
                            Name = "No Cure"
                        });
                });

            modelBuilder.Entity("HealthCore.Domain.Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            Name = "Ola Nordmann"
                        });
                });

            modelBuilder.Entity("HealthCore.Domain.Model.PatientAilments", b =>
                {
                    b.Property<int>("AilmentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AilmentId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAilments");

                    b.HasData(
                        new
                        {
                            AilmentId = 1,
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("HealthCore.Domain.Model.PatientMedications", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("Doses")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "MedicationId");

                    b.HasIndex("MedicationId");

                    b.ToTable("PatientMedications");
                });

            modelBuilder.Entity("HealthCore.Domain.Model.PatientAilments", b =>
                {
                    b.HasOne("HealthCore.Domain.Model.Ailment", "Ailment")
                        .WithMany("PatientAilments")
                        .HasForeignKey("AilmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCore.Domain.Model.Patient", "Patient")
                        .WithMany("PatientAilments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCore.Domain.Model.PatientMedications", b =>
                {
                    b.HasOne("HealthCore.Domain.Model.Medication", "Medication")
                        .WithMany("PatientMedications")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCore.Domain.Model.Patient", "Patient")
                        .WithMany("PatientMedications")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
