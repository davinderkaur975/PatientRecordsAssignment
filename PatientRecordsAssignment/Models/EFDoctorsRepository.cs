using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientRecordsAssignment.Models
{
    public class EFDoctorsRepository : IMockDoctorsRepository
    {
        //db connection moved here from PatientsController
        private PatientRecordsModel db = new PatientRecordsModel();

        public IQueryable<Doctor> Doctors { get { return db.Doctors; } }

        public void Delete(Doctor doctor)
        {
            db.Doctors.Remove(doctor);
            db.SaveChanges();
        }

        public Doctor Save(Doctor doctor)
        {
            if (doctor.DoctorId == null)
            {
                db.Doctors.Add(doctor);
            }
            else
            {
                // mark the state of the current object as modified
                db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return doctor;
        }
    }
}