using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthCore.Domain.Model;
using HealthCore.Domain.Service;
using HealthSQLDB.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSQLDB.Db
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly HealthContext _db;
        public MedicationRepository(HealthContext db)
        {
            _db = db;
        }

        public async Task<Medication> ReadById(int id)
        {
            return await _db.Medications.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
