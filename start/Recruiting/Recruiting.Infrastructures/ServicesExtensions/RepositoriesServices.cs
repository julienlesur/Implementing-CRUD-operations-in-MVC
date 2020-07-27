using Recruiting.BL.Repositories;
using Recruiting.BL.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();

            return services;
        } 
    }
}
