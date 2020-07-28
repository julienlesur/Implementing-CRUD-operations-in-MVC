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
    public class JobRepository : RepositoryBase<Job, EfJob>, IJobRepository
    {
        private readonly IEfJobRepository _efJobRepository;
        private readonly Func<IEnumerable<EfJob>, IList<Job>> _mapListEntityToListDomain;

        public JobRepository(IEfJobRepository efJobRepository)
            : base(JobMapper.MapDomainToEntity, JobMapper.MapEntityToDomain, efJobRepository)
        {
            _efJobRepository = efJobRepository;
            _mapListEntityToListDomain = JobMapper.MapListEntityToListDomain;
        }
        public async Task<IList<Job>> DomainListAsync()
        {
            IEnumerable<EfJob> efJobs = await _efJobRepository.ListAsync();
            return _mapListEntityToListDomain(efJobs);
        }
        public int GetApplicationsCountByJobId(int jobId)
        {
            return _efJobRepository.GetNumberOfApplicationsByJobId(jobId);
        }

        public bool IsJobReferenceUnique(int id, string reference)
        {
            return _efJobRepository.IsJobReferenceUnique(id, reference);
        }
    }
}
