using Recruiting.BL.Models;
using Recruiting.BL.Repositories;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }
        public async Task<IEnumerable<Applicant>> GetApplicantsWithLastApplication()
        {
            var applicants = await _applicantRepository.DomainListAsync();
            foreach (var applicant in applicants)
            {
                var applicationNAmeAndRef = await _applicantRepository.GetLastApplicationNameAndRef(applicant.ApplicantId);
                applicant.DisplayApplicationTitle = applicationNAmeAndRef;
            }
            return applicants;
        }
    }
}
