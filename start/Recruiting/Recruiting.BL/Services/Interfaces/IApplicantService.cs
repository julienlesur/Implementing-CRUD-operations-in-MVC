using Recruiting.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.BL.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<Application> GetApplicantLastApplication(int applicantId);
        Task<IEnumerable<Applicant>> GetApplicantListWithLastApplication();
    }
}
