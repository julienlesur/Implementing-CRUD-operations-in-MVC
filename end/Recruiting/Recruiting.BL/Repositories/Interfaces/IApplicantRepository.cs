using Recruiting.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories.Interfaces
{
    public interface IApplicantRepository
    {
        public Task<IList<Applicant>> DomainListAsync();
        public Task<string> GetLastApplicationNameAndRef(int applicantId);
    }
}
