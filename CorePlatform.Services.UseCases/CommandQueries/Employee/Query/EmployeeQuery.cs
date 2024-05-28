using CorePlatform.Services.Core.Abstraction.Result;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.Query
{
    public record EmployeeQuery(int employeeId) : IRequest<ResultInfo<EmployeeResponseDTO>>;
}
