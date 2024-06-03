using CorePlatform.Services.Core.Employee;
using Microsoft.Extensions.Caching.Memory;

namespace CorePlatform.Services.Infrastructure.Repository
{
    public sealed class CachedEmployeeRepository(EmployeeRepository employeeRepository, IMemoryCache memoryCache) : IEmployeeRepository
    {
        public void Add(Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            string key = $"employee={id}";

            return memoryCache.GetOrCreateAsync(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                return employeeRepository.GetByIdAsync(id, cancellationToken);
            });
        }
    }
}
