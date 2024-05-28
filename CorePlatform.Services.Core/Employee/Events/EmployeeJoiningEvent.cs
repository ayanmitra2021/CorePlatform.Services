using CorePlatform.Services.Core.Abstraction;

namespace CorePlatform.Services.Core.Employee.Events
{
    public record EmployeeJoiningEvent(int employeeId) : IDomainEvent;
}
