using CorePlatform.Services.Core.Employee;

namespace CorePlatform.Services.Infrastructure.Repository
{
    internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext dbContext) : base(dbContext) { }
    }
}
