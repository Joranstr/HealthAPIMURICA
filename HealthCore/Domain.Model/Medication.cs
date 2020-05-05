using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<PatientMedications> PatientMedications { get; set; }
    }
}
