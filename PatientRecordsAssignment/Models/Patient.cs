namespace PatientRecordsAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        [StringLength(120)]
        [Display(Name = "Patient Name")]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(300)]
        public string Disease { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
