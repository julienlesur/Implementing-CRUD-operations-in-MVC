using Recruiting.BL.Mappers;
using Recruiting.BL.Models;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly IEfApplicantRepository _efApplicantRepository;
        private readonly Func<IEnumerable<EfApplicant>, IList<Applicant>> _mapListEntityToListDomain;

        public ApplicantRepository(IEfApplicantRepository efApplicantRepository)
        {
            _efApplicantRepository = efApplicantRepository;
            _mapListEntityToListDomain = ApplicantMapper.MapListEntityToListDomain;
        }
        public async Task<IList<Applicant>> DomainListAsync()
        {
            IEnumerable<EfApplicant> efApplicants = await _efApplicantRepository.ListAsync();
            return _mapListEntityToListDomain(efApplicants);
        }

        public async Task<string> GetLastApplicationNameAndRef(int applicantId)
        {
            var efApplication = await _efApplicantRepository.GetLastApplicationByApplicantId(applicantId);
            return efApplication?.Job?.Title ?? "" + " - " + efApplication?.Job?.Reference ?? "" ;
        }
    }
}
