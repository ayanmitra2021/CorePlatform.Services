using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.Core.Employee.Enums;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.Create
{
    public record CreateEmployeeCommand(string firstName, string lastName,
        EmployeeGender gender, DateOnly dateofBirth, decimal netSalary,
        EmployeeStatus status, DateOnly dateOfJoining, DateOnly? dateOfTrainingCompletion,
        DateOnly? dateOfResignation, DateOnly? dateOfRetirement) : IRequest<ResultInfo<int>>;

}
