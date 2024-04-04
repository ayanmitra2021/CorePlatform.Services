using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.CommandQueries.MemberRule
{
    public record MemberRuleEvaluationDTO(int memberId, string planName);
}
