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
    public class AilmentRepository : IAilmentRepository
    {
        private readonly HealthContext _db;
        public AilmentRepository(HealthContext db)
        {
            _db = db;
        }

        public async Task<Ailment> ReadById(int ailmentId)
        {
            return await _db.Ailments.FirstOrDefaultAsync(a => a.Id == ailmentId);
        }
    }
}
