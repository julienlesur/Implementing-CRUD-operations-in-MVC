using Recruiting.BL.Models;
using Recruiting.BL.Repositories;
using Recruiting.BL.Repositories.Interfaces;
using Recruiting.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruiting.BL.Mappers
{
    public static class JobMapper
    {
        public static Job MapEntityToDomain(EfJob entity, IJobRepository jobRepository)
        => new Job
        {
            JobId = entity.Id,
            Reference = entity.Reference,
            Title = entity.Title,
            Company = entity.Company,
            Description = entity.Description,
            Location = entity.Location,
            Type = entity.Type,
            NumberOfApplications = jobRepository.GetApplicationsCountByJobId(entity.Id)
        };

        public static EfJob MapDomainToEntity(Job domain)
            => new EfJob
            {
                Id = domain.JobId,
                Reference = domain.Reference,
                Title = domain.Title,
                Company = domain.Company,
                Description = domain.Description,
                Location = domain.Location,
                Type = domain.Type
            };

        public static IList<Job> MapListEntityToListDomain(IEnumerable<EfJob> entities, IJobRepository jobRepository)
        {
            IList<Job> domainJobs = new List<Job>();
            foreach (EfJob entity in entities)
            {
                domainJobs.Add(MapEntityToDomain(entity, jobRepository));
            }
            return domainJobs;
        }
    }
}
