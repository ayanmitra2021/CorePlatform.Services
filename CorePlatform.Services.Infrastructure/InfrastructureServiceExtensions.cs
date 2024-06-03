using CorePlatform.Services.Core.Abstraction;
using CorePlatform.Services.Core.Employee;
using CorePlatform.Services.Infrastructure.Data;
using CorePlatform.Services.Infrastructure.Repository;
using CorePlatform.Services.UseCases.Abstraction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CorePlatform.Services.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
        {
            AddPersistence(services, config);

            logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext

            var connectionsString =
                configuration.GetConnectionString("SqlServerConnection") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(connectionsString);
            });


            #endregion

            #region Dapper

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionsString));

            #endregion

            #region Repositories Registration

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<IEmployeeRepository, CachedEmployeeRepository>();

            #endregion

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDBContext>());
        }
    }
}
