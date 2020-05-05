using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthCore.Domain.Model
{
    public class PatientAilments
    {

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AilmentId { get; set; }
        public Ailment Ailment { get; set; }
    }
}
