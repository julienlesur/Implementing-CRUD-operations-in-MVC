using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories.Interfaces
{
    public interface IEfRepositoryBase<T>
    {
        Task<IEnumerable<T>> ListAsync();
    }
}
