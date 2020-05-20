using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAPI.ViewModel;
using HealthCore.Application.Service;
using HealthCore.Domain.Model;
using HealthSQLDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("HealthPolicy")]
    public class PatientsController : ControllerBase
    {
        private HealthService _healthService;
        private HealthContext _context;

        public PatientsController(HealthContext context, HealthService healthService)
        {
            _healthService = healthService;
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<List<PatientViewModel>>> GetPatients()
        {
            var Patients = await _context.Patients
                .Include(pa => pa.PatientAilments)
                 .ThenInclude(pa => pa.Ailment)
                .Include(pm => pm.PatientMedications)
                .ThenInclude(pm => pm.Medication)
                  .ToListAsync();
            return Patients.Select(p => new PatientViewModel(p)).ToList();

        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientViewModel>> GetPatient(int id)
        {
            var patient = await _context.Patients
              .Include(pa => pa.PatientAilments)
               .ThenInclude(pa => pa.Ailment)
              .Include(pm => pm.PatientMedications)
                .ThenInclude(pm => pm.Medication)
                .FirstOrDefaultAsync(i => i.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            return new PatientViewModel(patient);
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientViewModel>> PostPatient(PatientViewModel patient)
        {
            var p = patient.ConvertToPatient();
            var newPatient = await _healthService.CreatePatient(p);

            //_context.Patients.Add(newPatient);
            //await _context.SaveChangesAsync();

            //newPatient.PatientAilments = new List<PatientAilments>();
            //newPatient.PatientMedications = new List<PatientMedications>();

            //foreach (var ailment in patient.Ailments)
            //{
            //    var Ailment = await _context.Ailments.FirstOrDefaultAsync(a => a.Id == ailment.Id);
            //    var patientAilment = new PatientAilments() {Patient = newPatient, PatientId = newPatient.PatientId, Ailment = Ailment, AilmentId = Ailment.Id };
            //    newPatient.PatientAilments.Add(patientAilment);
            //}

            //foreach (var medication in patient.Medications)
            //{
            //    var Medication = await _context.Medications.FirstOrDefaultAsync(m => m.Id == medication.Id);
            //    var patientMedication = new PatientMedications() { Patient = newPatient, PatientId = newPatient.PatientId, Medication = Medication, MedicationId = Medication.Id };
            //    newPatient.PatientMedications.Add(patientMedication);
            //}

            //_context.Patients.Update(newPatient);
            //await _context.SaveChangesAsync();

            return new PatientViewModel(newPatient);
            //CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }

        [HttpGet("{id:int}/medication")]
        public async Task<IActionResult> GetMedications(int id)
        {
            var patient = await _context.Patients

                .FirstOrDefaultAsync(i => i.PatientId == id);

            if (patient == null) return NotFound();
            return Ok(patient);
        }
    }

}
