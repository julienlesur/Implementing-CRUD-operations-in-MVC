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
        private IUnitEfRepository _unitRepository { get; set; }

        protected ServiceBase(IRepositoryBase<T> repository, IUnitEfRepository unitRepository)
        {
            _repository = repository;
            _unitRepository = unitRepository;
        }

        public async Task<T> AddAsync(T newEntity)
        {
            newEntity = await _repository.AddAsync(newEntity);
            await _unitRepository.CommitAsync();

            return newEntity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            T deletedEntity = await _repository.DeleteAsync(id);
            await _unitRepository.CommitAsync();
            return deletedEntity;
        }

        public async Task<T> UpdateAsync(T updatedEntity)
        {
            updatedEntity = _repository.Update(updatedEntity);
            await _unitRepository.CommitAsync();
            return updatedEntity;
        }
    }
}
