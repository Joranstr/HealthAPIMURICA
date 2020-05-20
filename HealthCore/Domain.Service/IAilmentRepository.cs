using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthCore.Domain.Model;

namespace HealthCore.Domain.Service
{
    public interface IAilmentRepository
    {
        Task<Ailment> ReadById(int ailmentId);
    }
}
