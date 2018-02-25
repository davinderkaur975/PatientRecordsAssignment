namespace PatientRecordsAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientRecordsModel : DbContext
    {
        public PatientRecordsModel()
            : base("name=PatientRecordsConnection")
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);
        }
    }
}
