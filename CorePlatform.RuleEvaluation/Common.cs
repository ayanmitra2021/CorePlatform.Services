using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.RuleEvaluation
{
    public enum RuleLibrary
    {
        DiscountRule = 1,
        ElgibilityRule = 2,
        ElgibilityPlusRule = 3,
        EligibilityChain = 4,
        RuleWithAction = 5,
        CalculationExample = 6
    }
}
