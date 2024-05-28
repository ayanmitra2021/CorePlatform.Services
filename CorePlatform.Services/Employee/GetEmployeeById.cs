using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.UseCases.CommandQueries.Employee.Query;
using FastEndpoints;
using MediatR;

namespace CorePlatform.Services.Employee
{
    public class GetEmployeeById(IMediator _mediator) : Endpoint<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        public override void Configure()
        {
            Get(GetEmployeeByIdRequest.Route);
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new EmployeeQuery(request.EmployeeId);

            var result = await _mediator.Send(query, cancellationToken);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                Response = new GetEmployeeByIdResponse(result.Value.employeeId, result.Value.firstName, result.Value.lastName,
                result.Value.gender, result.Value.dateofBirth, result.Value.netSalary, result.Value.status,
                result.Value.dateOfJoining, result.Value.dateOfTrainingCompletion, result.Value.dateOfResignation, result.Value.dateOfRetirement);
            }
        }
    }
}
