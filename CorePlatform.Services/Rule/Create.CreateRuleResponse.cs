namespace CorePlatform.Services.Rule
{
    public class CreateRuleResponse (int Id, string ruleName, string ruleExpression)
    {
        public int Id { get; set; } = Id;

        public string Name { get; set; } = ruleName;

        public string RuleExpression { get; set; } = ruleExpression;
    }
}
