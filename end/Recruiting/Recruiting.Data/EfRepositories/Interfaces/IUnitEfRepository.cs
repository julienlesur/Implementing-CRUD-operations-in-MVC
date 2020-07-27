using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories.Interfaces
{
    public interface IUnitEfRepository
    {
        Task<int> CommitAsync();
    }
}
