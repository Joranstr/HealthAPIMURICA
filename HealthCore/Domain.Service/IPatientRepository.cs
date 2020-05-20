using HealthCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthCore.Domain.Service
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAll();
        Task<int> CreateAsync(Patient patientModel);
        Task<Patient> ReadAsync(int id);
        Task<int> UpdateAsync(Patient patientModel);
    }
}
