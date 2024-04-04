using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CorePlatform.Services.Infrastructure.Data;

namespace CorePlatform.Services.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
        {
            string? connectionString = config.GetConnectionString("SqliteConnection");
            Guard.Against.Null(connectionString);
            services.AddApplicationDbContext(connectionString);

            logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }
    }
}
