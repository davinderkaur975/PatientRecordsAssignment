using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordsAssignment.Models
{
    public interface IMockDoctorsRepository
    {
        IQueryable<Doctor> Doctors { get; }

        Doctor Save(Doctor doctor);

        void Delete(Doctor doctor);
    }
}
