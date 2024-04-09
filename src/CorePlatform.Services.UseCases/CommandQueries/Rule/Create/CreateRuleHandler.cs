using CorePlatform.Services.Core.Rule;
using CorePlatform.Services.Infrastructure.Data;
using CorePlatform.Services.Infrastructure.Repository;
using CorePlatform.Services.UseCases.Events.Rule.Create;
using CorePlatform.Services.UseCases.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.CommandQueries.Rule.Create
{
    public class CreateRuleHandler : IRequestHandler<CreateRuleCommand, ResultInfo<int>>
    {
        private IMediator _mediator;
        public CreateRuleHandler(AppDbContext context, IMediator mediator)
        {
            UnitOfWork.Initialize(context);
            _mediator = mediator;
        }

        public async Task<ResultInfo<int>> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {
            var ruleLib = new RulesLibrary(request.RuleName);
            ruleLib.RuleExpression = request.RuleExpression;
            UnitOfWork.RuleLibraryRepository.Insert(ruleLib);
            await UnitOfWork.Save();

            //raise notification 
            var domainEvent = new CreateRuleEvent(ruleLib.Id);
            await _mediator.Publish(domainEvent);

            return ruleLib.Id;
        }
    }
}
