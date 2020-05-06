using HealthCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.ViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AilmentViewModel> Ailments { get; set; }
        public List<MedicationViewModel> Medications { get; set; }
        public PatientViewModel(Patient patient)
        {
            Id = patient.PatientId;
            Name = patient.Name;
            Ailments = patient.PatientAilments.Select(p => new AilmentViewModel { Name = p.Ailment.Name , Id = p.AilmentId}).ToList();
            Medications = patient.PatientMedications.Select(p => new MedicationViewModel { Name = p.Medication.Name , Id = p.MedicationId, Doses = p.Doses}).ToList();
        }



    }
}
