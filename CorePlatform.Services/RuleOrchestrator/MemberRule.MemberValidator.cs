using FastEndpoints;
using FluentValidation;

namespace CorePlatform.Services.RuleOrchestrator
{
    public class MemberValidator : Validator<MemberRequest>
    {
        public MemberValidator()
        {
            RuleFor(x => x.MemberId)
                .NotEmpty()
                .WithMessage("Member Id is required")
                .GreaterThan(0);
        }
    }
}
