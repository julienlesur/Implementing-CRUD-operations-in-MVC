using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;

namespace Recruiting.Web.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public async Task<IActionResult> List()
        {
            IEnumerable<Applicant> applicants = await _applicantService.GetApplicantListWithLastApplication();
            
            return View(applicants);
        }
    }
}
