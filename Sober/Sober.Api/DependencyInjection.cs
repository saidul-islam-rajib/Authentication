using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sober.Api.Common.Errors;
using Sober.Api.Common.Mapping;

namespace Sober.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, PortfolioProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}
