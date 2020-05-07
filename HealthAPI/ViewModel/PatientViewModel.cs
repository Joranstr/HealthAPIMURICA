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
            if(patient.PatientAilments != null)
                Ailments = patient.PatientAilments.Select(p => new AilmentViewModel { Name = p.Ailment.Name , Id = p.AilmentId}).ToList();
            if(patient.PatientMedications != null)
            Medications = patient.PatientMedications.Select(p => new MedicationViewModel { Name = p.Medication.Name , Id = p.MedicationId, Doses = p.Doses}).ToList();
        }
        public PatientViewModel()
        {

        }

        public Patient ConvertToPatient()
        {
            var patient = new Patient();
            //patient.PatientAilments = new List<PatientAilments>();
            //patient.PatientMedications = new List<PatientMedications>();

            patient.Name = this.Name;
            
            //foreach(var ailment in this.Ailments)
            //{
            //    var patientAilment = new PatientAilments();
            //    var Ailment = ailment.ConvertToAilment();
            //    patientAilment.Ailment = Ailment;
            //    patientAilment.Patient = patient;
            //    patient.PatientAilments.Add(patientAilment);
            //}
            
            //foreach (var medication in this.Medications)
            //{
            //    var patientMedication = new PatientMedications();
            //    var Medication = medication.ConvertToMedication();
            //    patientMedication.Medication = Medication;
            //    patientMedication.Patient = patient;
            //    patientMedication.Doses = medication.Doses;
            //    patient.PatientMedications.Add(patientMedication);
            //}

            return patient;
        }

    }
}
