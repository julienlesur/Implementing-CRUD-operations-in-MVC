using System.Collections.Generic;

namespace Recruiting.BL.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FulllName { get { return (FirstName ?? "") + " " + (LastName ?? ""); } }
        public string Email { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string DisplayApplicationTitle { get; set; }

        public IList<Application> Applications { get; set; }


        public static readonly Applicant _EmptyApplicant = new Applicant { ApplicantId = 0 };
    }
}
