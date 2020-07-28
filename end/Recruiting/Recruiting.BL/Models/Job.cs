using Recruiting.BL.Validation;
using Recruiting.Data.EfModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recruiting.BL.Models
{
    public class Job
    {
        public int JobId { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required, StringLength(20)]
        [IsUniqueJobReference]
        public string Reference { get; set; }
        [Required]
        public JobType Type { get; set; }
        public string Location { get; set; }
        [Required]
        public string Company { get; set; }

        public int NumberOfApplications { get; set; }
        public IList<Application> Applications { get; set; }
    }
}
