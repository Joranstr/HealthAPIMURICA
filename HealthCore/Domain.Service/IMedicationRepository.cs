using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthCore.Domain.Model;

namespace HealthCore.Domain.Service
{
    public interface IMedicationRepository
    {
        Task<Medication> ReadById(int id);
    }
}
