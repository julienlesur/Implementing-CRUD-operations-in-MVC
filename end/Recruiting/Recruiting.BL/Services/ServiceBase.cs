using Recruiting.BL.Repositories.Interfaces;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T>
    {
        private IRepositoryBase<T> _repository { get; set; }

        protected ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T newEntity)
            => await _repository.AddAsync(newEntity);

        public async Task<T> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);

        public async Task<T> UpdateAsync(T updatedEntity)
            => await _repository.Update(updatedEntity);

        public async Task<T> FindByIdAsync(int id)
            => await _repository.FindByIdAsync(id);
    }
}
