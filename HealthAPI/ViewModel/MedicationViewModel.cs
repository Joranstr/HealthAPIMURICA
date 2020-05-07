using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCore.Domain.Model;

namespace HealthAPI.ViewModel
{
    public class MedicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Doses { get; set; }

        public Medication ConvertToMedication()
        {
            var Medication = new Medication();
            Medication.Name = this.Name;
            Medication.Id = this.Id;
            return Medication;
        }
    }

}
