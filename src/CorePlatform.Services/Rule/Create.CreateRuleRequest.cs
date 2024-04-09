using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace CorePlatform.Services.Rule
{
    public class CreateRuleRequest
    {
        public const string Route = "/Rules";

        [Required]
        public string? RuleName { get; set; }

        [Required]
        public string? RuleExpression { get; set; }

    }
}
