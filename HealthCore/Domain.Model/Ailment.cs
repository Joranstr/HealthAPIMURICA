using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class Ailment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientAilments> PatientAilments { get; set; }
    }
}
