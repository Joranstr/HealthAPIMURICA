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
    public class AilmentsController : ControllerBase
    {
        private readonly HealthContext _context;

        public AilmentsController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<List<AilmentViewModel>>> GetAilments()
        {
            var Ailments = await _context.Ailments.ToArrayAsync();
            
               
            return Ailments.Select(a => new AilmentViewModel{Id = a.Id, Name=a.Name }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<List<AilmentViewModel>>> RegisterNewAilment( Ailment ailment)
        {

            _context.Ailments.Add(ailment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAilment", new { id = ailment.Id }, ailment);
        }
    }
    
}