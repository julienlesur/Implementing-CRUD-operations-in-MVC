using System;
using System.Collections.Generic;
using System.Text;

namespace Recruiting.BL.Models
{
    public class Application
    {
        public int JobId { get; set; }
        public string JobReference { get; set; }
        public string JobTitle { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantFullName { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
