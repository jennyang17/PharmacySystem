using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PharmacyAPI.EF
{
    public partial class PharmacyContext : DbContext
    {
        public PharmacyContext()
        {
        }

        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prescriber> Prescribers { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<PrescriptionItem> PrescriptionItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=Pharmacy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

                entity.Property(e => e.Formulation).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Strength).HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Exemption).HasMaxLength(1);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Nhsnumber)
                    .HasMaxLength(10)
                    .HasColumnName("NHSnumber");
            });

            modelBuilder.Entity<Prescriber>(entity =>
            {
                entity.ToTable("Prescriber");

                entity.Property(e => e.PrescriberId).HasColumnName("PrescriberID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PrescriberAddress).HasMaxLength(100);

                entity.Property(e => e.TypeOfPrescriber).HasMaxLength(100);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.PrescriberId).HasColumnName("PrescriberID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Patie__76969D2E");

                entity.HasOne(d => d.Prescriber)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PrescriberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Presc__778AC167");
            });

            modelBuilder.Entity<PrescriptionItem>(entity =>
            {
                entity.ToTable("PrescriptionItem");

                entity.Property(e => e.PrescriptionItemId).HasColumnName("PrescriptionItemID");

                entity.Property(e => e.Dosage).HasMaxLength(1000);

                entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionItems)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Medic__7B5B524B");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionItems)
                    .HasForeignKey(d => d.PrescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Presc__7A672E12");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
