using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAPI.ViewModel;
using HealthCore.Domain.Model;
using HealthSQLDB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly HealthContext _context;

        public MedicationsController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<List<MedicationViewModel>>> GetMedications()
        {
            var Medications = await _context.Medications.ToArrayAsync();


            return Medications.Select(a => new MedicationViewModel { Id = a.Id, Name = a.Name }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<List<MedicationViewModel>>> RegisterNewMedication(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedication", new { id = medication.Id}, medication);
        }
    }
}