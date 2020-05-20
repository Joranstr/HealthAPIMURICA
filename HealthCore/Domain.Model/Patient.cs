using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        public ICollection<PatientAilments> PatientAilments { get; set; }
        public ICollection<PatientMedications> PatientMedications { get; set; }

        public Patient()
        {
        }

        public Patient(IEnumerable<int> ailmentIds, IEnumerable<int> medicationIds)
        {
            PatientAilments = ailmentIds.Select(aid=>new PatientAilments { AilmentId = aid}).ToList();
            PatientMedications = medicationIds.Select(mid=>new PatientMedications { MedicationId = mid}).ToList();
        }
    }
}
