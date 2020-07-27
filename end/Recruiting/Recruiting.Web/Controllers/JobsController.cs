using Microsoft.AspNetCore.Mvc;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public async Task<IActionResult> List()
        {
            IEnumerable<Job> jobs = await _jobService.GetJobs();
            return View(jobs);
        }
    }
}
