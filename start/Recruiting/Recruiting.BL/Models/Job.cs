using Recruiting.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruiting.BL.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public JobType Type { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }

        public int NumberOfApplications { get; set; }
        public IList<Application> Applications { get; set; }

        public static readonly Job _EmptyJob = new Job { JobId = 0 };
    }
}
