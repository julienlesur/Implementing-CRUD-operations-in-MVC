using Recruiting.BL.Repositories.Interfaces;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories
{
    public abstract class RepositoryBase<TDomain, TEntity> : IRepositoryBase<TDomain>
    {
        protected readonly Func<TDomain, TEntity> _mapDomainToEntity;
        protected readonly Func<TEntity, TDomain> _mapEntityToDomain;
        private readonly IEfRepositoryBase<TEntity> _efRepository;

        public RepositoryBase(Func<TDomain, TEntity> mapDomainToEntity, Func<TEntity, TDomain> mapEntityToDomain, IEfRepositoryBase<TEntity> efRepository)
        {
            _mapDomainToEntity = mapDomainToEntity;
            _mapEntityToDomain = mapEntityToDomain;
            _efRepository = efRepository;
        }

        public async Task<TDomain> AddAsync(TDomain newDomainEntity)
        {
            TEntity entity = _mapDomainToEntity(newDomainEntity);
            await _efRepository.AddAsync(entity);
            await _efRepository.CommitAsync();
            return _mapEntityToDomain(entity);
        }

        public async Task<TDomain> DeleteAsync(int id)
        {
            TEntity entity = await _efRepository.DeleteAsync(id);
            await _efRepository.CommitAsync();
            return _mapEntityToDomain(entity);
        }

        public async Task<TDomain> FindByIdAsync(int id)
        {
            TEntity entity = await _efRepository.FindByIdAsync(id);
            return _mapEntityToDomain(entity);
        }

        public async Task<TDomain> Update(TDomain updatedDomainEntity)
        {
            TEntity entity = _mapDomainToEntity(updatedDomainEntity);
            _efRepository.Update(entity);
            await _efRepository.CommitAsync();
            return _mapEntityToDomain(entity);
        }
    }
}
