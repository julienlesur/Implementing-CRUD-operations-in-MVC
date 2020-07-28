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

        public JobService(IJobRepository jobRepository)
            : base(jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<IEnumerable<Job>> GetJobs()
            => await _jobRepository.DomainListAsync();

        public bool IsReferenceUnique(int id, string reference)
            => _jobRepository.IsJobReferenceUnique(id, reference);
    }
}
