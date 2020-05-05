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
        public List<AilmentVeiwModel> Ailments { get; set; }
        public List<MedicationVeiwModel> Medications { get; set; }
        public PatientViewModel(Patient patient)
        {
            Id = patient.PatientId;
            Name = patient.Name;
            Ailments = patient.PatientAilments.Select(p => new AilmentVeiwModel { Name = p.Ailment.Name , Id = p.AilmentId}).ToList();
            Medications = patient.PatientMedications.Select(p => new MedicationVeiwModel { Name = p.Medication.Name , Id = p.MedicationId, Doses = p.Doses}).ToList();
        }



    }
}
