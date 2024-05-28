//using MediatR;
//using FastEndpoints;
//using CorePlatform.Services.UseCases.CommandQueries.Rule.Create;
//using Newtonsoft.Json;

//namespace CorePlatform.Services.Rule
//{
//    public class Create(IMediator _mediator)
//        : Endpoint<CreateRuleRequest, CreateRuleResponse>
//    {
//        public override void Configure()
//        {
//            Post(CreateRuleRequest.Route);
//            AllowAnonymous();
//        }

//        public override async Task HandleAsync(CreateRuleRequest request, CancellationToken cancellationToken)
//        {
//            var result = await _mediator.Send(new CreateRuleCommand(request.RuleName!, request.RuleExpression!), cancellationToken);

//            if(result.IsSuccess)
//            {
//                Response = new CreateRuleResponse(result.Value, request.RuleName!, request.RuleExpression!);
//            }

//            return;
//        }
//    }
//}
