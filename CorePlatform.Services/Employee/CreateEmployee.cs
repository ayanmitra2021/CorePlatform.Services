using CorePlatform.Services.UseCases.CommandQueries.Employee.Create;
using FastEndpoints;
using MediatR;

namespace CorePlatform.Services.Employee
{
    public class CreateEmployee(IMediator _mediator)
        : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        public override void Configure()
        {
            Post(CreateEmployeeRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand(
                    request.FirstName, request.LastName, request.Gender, request.DateOfBirth,
                    request.NetSalary, request.EmploymentStatus, request.DateOfJoining,
                    request.DateOfJoining, request.ResignationDate, request.RetirementDate
                ), cancellationToken);

            if (result.IsSuccess)
            {
                Response = new CreateEmployeeResponse()
                {
                    Id = result.Value,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    DateOfBirth = request.DateOfBirth,
                    NetSalary = request.NetSalary,
                    EmploymentStatus = request.EmploymentStatus,
                    DateOfJoining = request.DateOfJoining,
                    TrainingCompleteDate = request.TrainingCompleteDate,
                    RetirementDate = request.RetirementDate,
                    ResignationDate = request.ResignationDate
                };
            }

            return;
        }
    }
}
