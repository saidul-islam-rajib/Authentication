using Microsoft.AspNetCore.Mvc.Infrastructure;
using Authentication.Api.Common.Errors;
using Authentication.Api.Common.Mapping;

namespace Authentication.Api;

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
