using CorePlatform.Services.Core.Rule;
using CorePlatform.Services.Infrastructure.Data;
using CorePlatform.Services.Infrastructure.Repository;
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
        public CreateRuleHandler(AppDbContext context) 
        {
            UnitOfWork.Initialize(context);
        }

        public async Task<ResultInfo<int>> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
        {
            var ruleLib = new RulesLibrary(request.RuleName);
            ruleLib.RuleExpression = request.RuleExpression;
            UnitOfWork.RuleLibraryRepository.Insert(ruleLib);
            await UnitOfWork.Save();
            return ruleLib.Id;
        }
    }
}
