using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T> AddAsync(T newEntity);

        T Update(T updatedEntity);

        Task<T> DeleteAsync(int id);

    }
}
