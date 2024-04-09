using CorePlatform.Services.UseCases.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.CommandQueries.Rule.Create
{
    public record CreateRuleCommand(string RuleName, string RuleExpression) : IRequest<ResultInfo<int>>;
}
