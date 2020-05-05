using HealthCore.Domain.Model;
using HealthCore.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthCore.Application.Service
{
    public class HealthService
    {
        private readonly IHealthModelRepository _repository;

        public HealthService(IHealthModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> AddPatient(Patient patient) 
        {
            var patientModel = await _repository.ReadAsync(patient.PatientId);
            patientModel.AddPatient(patient.PatientId);
            await _repository.UpdateAsync(patientModel); ;
            return patientModel;
        }

        public async Task<Patient> ReadOnePatient(int id)
        {
            return await _repository.ReadAsync(id);
        }

        
    }
}
