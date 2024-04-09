using CorePlatform.Services.UseCases.CommandQueries.MemberRule.Query;
using CorePlatform.Services.UseCases.Result;
using FastEndpoints;
using MediatR;

namespace CorePlatform.Services.RuleOrchestrator
{
    public class MemberRule(IMediator _mediator) : Endpoint<MemberRequest, List<MemberResponse>>
    {
        public override void Configure()
        {
            Get(MemberRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(MemberRequest request, CancellationToken cancellationToken)
        {
            var command = new MemberRuleQuery(request.MemberId);

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                foreach (var item in result.Value)
                {
                    Response.Add(new MemberResponse(item.memberId, item.planName));
                }
            }
        }
    }

}
