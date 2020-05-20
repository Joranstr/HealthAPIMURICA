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
        private readonly IPatientRepository _patientRepository;
        private IAilmentRepository _ailmentRepository;
        private IMedicationRepository _medicationRepository;

        public HealthService(
            IPatientRepository patientRepository, 
            IAilmentRepository ailmentRepository, 
            IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
            _ailmentRepository = ailmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patient> AddPatient(Patient patient) 
        {
            var patientModel = await _patientRepository.ReadAsync(patient.PatientId);
            //patientModel.AddPatient(patient.PatientId);
            await _patientRepository.UpdateAsync(patientModel); ;
            return patientModel;
        }

        public async Task<Patient> ReadOnePatient(int id)
        {
            return await _patientRepository.ReadAsync(id);
        }


        public async Task<Patient> CreatePatient(Patient patient)
        {

            //foreach (var patientAilment in patient.PatientAilments)
            //{
            //    patientAilment.Ailment = await _ailmentRepository.ReadById(patientAilment.AilmentId);
            //    patientAilment.Patient = patient;
            //    patientAilment.PatientId = patient.PatientId;
            //}

            //foreach (var patientMedication in patient.PatientMedications)
            //{
            //    patientMedication.Medication = await _medicationRepository.ReadById(patientMedication.MedicationId);
            //    patientMedication.Patient = patient;
            //    patientMedication.PatientId = patient.PatientId;
            //}

            await _patientRepository.CreateAsync(patient);

            return patient;
        }
    }
}
