using Recruiting.BL.Models;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
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
