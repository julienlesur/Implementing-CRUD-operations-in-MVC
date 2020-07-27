using Recruiting.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories.Interfaces
{
    public interface IJobRepository
    {
        public Task<IList<Job>> DomainListAsync();
        public int GetApplicationsCountByJobId(int jobId);
    }
}
