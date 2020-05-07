using HealthCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.ViewModel
{
    public class AilmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
       public Ailment ConvertToAilment()
       {
           var Ailment = new Ailment();
           Ailment.Name = this.Name;
           Ailment.Id = this.Id;
           return Ailment;
       }
    }
}
