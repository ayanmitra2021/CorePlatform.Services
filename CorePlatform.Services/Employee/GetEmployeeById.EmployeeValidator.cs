using FastEndpoints;
using FluentValidation;

namespace CorePlatform.Services.Employee
{
    public class GetEmployeeByIdValidator : Validator<GetEmployeeByIdRequest>
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .WithMessage("Employee Id is required");
        }
    }
}
