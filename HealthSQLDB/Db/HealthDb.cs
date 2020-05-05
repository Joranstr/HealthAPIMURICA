using HealthCore.Domain.Model;
using HealthCore.Domain.Service;
using HealthSQLDB.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HealthSQLDB.Db
{
    public class HealthDb : IHealthModelRepository
    {
        private readonly HealthContext _db;
        public HealthDb(HealthContext db)
        {
            _db = db;
        }
        public async Task<int> CreateAsync(Patient patientModel)
        {
            await _db.Patients.AddAsync(patientModel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Patient> ReadAsync(int id)
        {
            return await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<int> UpdateAsync(Patient patientModel)
        {
            _db.Patients.Update(patientModel);
            return await _db.SaveChangesAsync();
        }
    }
}
