using Ardalis.GuardClauses;
using CorePlatform.Services.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CorePlatform.Services.Core.Rule
{
    public class RulesLibrary(string ruleName) : EntityBase
    {
        public string RuleName { get; private set; } = Guard.Against.NullOrEmpty(ruleName, nameof(ruleName));
        public RuleStatus Status { get; private set; } = RuleStatus.ActiveRule;
        public string RuleExpression { get; set; } = string.Empty;

        public void UpdateRuleName(string newRuleName)
        {
            RuleName = Guard.Against.NullOrEmpty(newRuleName, nameof(newRuleName));
        }
    }

    public class PlanAssociation(string planName) : EntityBase
    {
        public string PlanName { get; private set; } = Guard.Against.NullOrEmpty(planName, nameof(planName));

        public RulesLibrary Library { get; set; } 
        public void UpdatePlanName(string newPlanName)
        {
            PlanName = Guard.Against.NullOrEmpty(newPlanName, nameof(newPlanName));
        }
    }
}
