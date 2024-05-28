using FastEndpoints;
using FluentValidation;

namespace CorePlatform.Services.Employee
{
    public class CreateEmployeeValidator : Validator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5)
                .WithMessage("First name cannot be empty and must be 5-50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5)
                .WithMessage("Last name cannot be empty and must be 5-50 characters");

            RuleFor(x => x.DateOfBirth)
                .GreaterThanOrEqualTo(new DateOnly(1980, 1, 1))
                .WithMessage("Date of birth must be on or after Jan 1st, 1980");

        }
    }
}
