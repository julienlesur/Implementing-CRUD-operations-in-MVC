using Microsoft.EntityFrameworkCore;
using Recruiting.Data.Data;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories
{
    public abstract class EfRepositoryBase<T> : IEfRepositoryBase<T> where T : EfModelBase
    {
        protected readonly RecruitingContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepositoryBase(RecruitingContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
