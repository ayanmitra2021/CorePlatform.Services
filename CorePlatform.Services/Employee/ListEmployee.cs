using Azure.Core;
using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.UseCases.CommandQueries.Employee.List;
using CorePlatform.Services.UseCases.CommandQueries.Employee.Query;
using MediatR;

namespace CorePlatform.Services.Employee
{
    public class ListEmployee(IMediator _mediator) : FastEndpoints.EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("/Employee");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var query = new EmployeeList();

            var result = await _mediator.Send(query, cancellationToken);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
                Response = result;
        }
    }
}
