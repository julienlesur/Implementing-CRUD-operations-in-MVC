using Recruiting.Data.Data;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories
{
    public class UnitEfRepository : IUnitEfRepository
    {
        protected readonly RecruitingContext _context;

        public UnitEfRepository(RecruitingContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
