﻿using Recruiting.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services.Interfaces
{
    public interface IApplicantService
    {
        public Task<IEnumerable<Applicant>> GetApplicantsWithLastApplication();
    }
}