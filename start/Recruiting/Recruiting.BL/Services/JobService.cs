using Recruiting.BL.Mappers;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class JobService : IJobService
    {
        private readonly IEfJobRepository _efJobRepository;
        private readonly Func<IEnumerable<EfJob>, IList<Job>> _mapListEntityToListDomain;

        public JobService(IEfJobRepository efJobRepository)
        {
            _efJobRepository = efJobRepository;
            _mapListEntityToListDomain = JobMapper.MapListEntityToListDomain;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            IEnumerable<EfJob> efJobs = await _efJobRepository.ListAsync();
            return _mapListEntityToListDomain(efJobs);
        }
    }
}
