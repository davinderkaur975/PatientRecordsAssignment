namespace PatientRecordsAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Patients = new HashSet<Patient>();
        }

        public int DoctorId { get; set; }

        [StringLength(120)]
        [Display(Name = "Doctor Name")]
        public string Name { get; set; }

        [StringLength(300)]
        public string FieldSpecialist { get; set; }

        [StringLength(10)]
        public string OfficeLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
