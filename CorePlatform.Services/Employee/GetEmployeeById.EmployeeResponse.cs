using CorePlatform.Services.Core.Employee.Enums;

namespace CorePlatform.Services.Employee
{
    public record GetEmployeeByIdResponse(int employeeId, string firstName, string lastName,
        EmployeeGender gender, DateOnly dateofBirth, decimal netSalary,
        EmployeeStatus status, DateOnly dateOfJoining, DateOnly? dateOfTrainingCompletion,
        DateOnly? dateOfResignation, DateOnly? dateOfRetirement);
}
