using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.Events.Rule.Create
{
    internal sealed class CreateRuleEvent(int ruleId) : INotification
    {
        public int RuleId { get; set; } = ruleId;
    }
}
