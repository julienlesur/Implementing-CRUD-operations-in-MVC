using Recruiting.BL.Mappers;
using Recruiting.BL.Models;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly IEfJobRepository _efJobRepository;
        private readonly Func<IEnumerable<EfJob>, IJobRepository, IList<Job>> _mapListEntityToListDomain;

        public JobRepository(IEfJobRepository efJobRepository)
        {
            _efJobRepository = efJobRepository;
            _mapListEntityToListDomain = JobMapper.MapListEntityToListDomain;
        }
        public async Task<IList<Job>> DomainListAsync()
        {
            IEnumerable<EfJob> efJobs = await _efJobRepository.ListAsync();
            return _mapListEntityToListDomain(efJobs, this);
        }
        public int GetApplicationsCountByJobId(int jobId)
        {
            return _efJobRepository.GetNumberOfApplicationsByJobId(jobId);
        }
    }
}
