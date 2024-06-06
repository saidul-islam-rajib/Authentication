using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Common.Interfaces.Services;
using Sober.Infrastructure.Authentication;
using Sober.Infrastructure.Persistence;
using Sober.Infrastructure.Persistence.Repositories;
using Sober.Infrastructure.Services;
using System.Text;

namespace Sober.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
           ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            services.AddDbContext<PortfolioDbContext>(options =>
                options.UseSqlServer("Data Source=SAIDUL-INTERN;Initial Catalog=Portfolio;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var JwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, JwtSettings);


            services.AddSingleton(Options.Create(JwtSettings));


            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSettings.Secret))
                });

            return services;
        }


    }
}
