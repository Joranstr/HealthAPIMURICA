using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        public ICollection<PatientAilments> PatientAilments { get; set; }
        public ICollection<PatientMedications> PatientMedications { get; set; }
        public void AddPatient(int id)
        {
            
        }
    }
}
