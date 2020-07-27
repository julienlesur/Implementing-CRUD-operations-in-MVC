using Recruiting.BL.Models;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Data.EfRepositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class JobService : ServiceBase<Job>, IJobService
    {
        private IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository, IUnitEfRepository unitRepository)
            : base(jobRepository, unitRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = await _jobRepository.DomainListAsync();
            return jobs;
        }
    }
}
