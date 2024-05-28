namespace CorePlatform.Services.Core.Employee
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        void Add(Employee employee);
    }
}
