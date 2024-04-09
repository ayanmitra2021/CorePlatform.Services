using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.Events.Rule.Create
{
    internal class CreateRuleEventHandler(ILogger<CreateRuleEventHandler> logger) : INotificationHandler<CreateRuleEvent>
    {
        public Task Handle(CreateRuleEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation(">>>>> A new rule is created in the system and the rule identifier is {RuleId}", notification.RuleId);

            return Task.CompletedTask;
        }
    }
}
