using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class PatientMedications
    {
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int Doses { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
    }
}
