using Recruiting.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.BL.Services.Interfaces
{
    public interface IJobService
    {
        public Task<IEnumerable<Job>> GetJobs();
    }
}
