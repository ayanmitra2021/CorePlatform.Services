using CorePlatform.Services.Core.Abstraction;

namespace CorePlatform.Services.Core.Employee.Events
{
    public record EmployeeRetirementEvent(int employeeId) : IDomainEvent;

}
