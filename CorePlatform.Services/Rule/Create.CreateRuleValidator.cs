using CorePlatform.Services.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CorePlatform.Services.Rule
{
    public class CreateRuleValidator : Validator<CreateRuleRequest>
    {
        public CreateRuleValidator()
        {
            RuleFor(x => x.RuleName)
                .NotEmpty()
                .WithMessage("Rule name cannot be empty")
                .MinimumLength(10)
                .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

            RuleFor(x => x.RuleExpression)
                .NotEmpty()
                .WithMessage("Rule expression cannot be empty");
        }
    }
}
