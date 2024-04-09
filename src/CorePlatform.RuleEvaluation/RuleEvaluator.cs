using CorePlatform.RuleEvaluation.RuleInput;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace CorePlatform.RuleEvaluation
{
    public class RuleEvaluator
    {
        //private ReSettings _reSettings;
        List<Workflow> _ruleWorkflow;
        RuleLibrary _library;
        RulesEngine.RulesEngine _businesRuleEngine;
        List<RuleParameter> _ruleParameters;
        public string _ruleJSON;

        public RuleEvaluator(string ruleJSON, RuleLibrary library)
        {
            _ruleJSON = ruleJSON;
            _library = library;
            _ruleWorkflow = JsonConvert.DeserializeObject<List<Workflow>>(_ruleJSON);
            if (_ruleWorkflow == null) throw new Exception("Invalid rule json object");

            _businesRuleEngine = new RulesEngine.RulesEngine(_ruleWorkflow.ToArray());
            this.InitializeInputs();
        }

        private void InitializeInputs()
        {
            _ruleParameters = new List<RuleParameter>();
            switch (this._library)
            {
                case RuleLibrary.DiscountRule:
                    RuleParameter parameter = new RuleParameter("input1", new DiscountInputs());
                    _ruleParameters.Add(parameter);
                    break;
                case RuleLibrary.ElgibilityRule:
                    RuleParameter memberParameter1 = new RuleParameter("member", new MemberInput());
                    RuleParameter dependentParameter1 = new RuleParameter("dependent", new DependentInput());
                    _ruleParameters.Add(memberParameter1);
                    _ruleParameters.Add(dependentParameter1);
                    break;
                case RuleLibrary.ElgibilityPlusRule:
                    RuleParameter memberParameter2 = new RuleParameter("member", new MemberInput());
                    _ruleParameters.Add(memberParameter2);
                    break;
                case RuleLibrary.EligibilityChain:
                    RuleParameter memberParameter3 = new RuleParameter("member", new MemberInput()
                    {
                        name = "John Doe",
                        age = 52,
                        stateCode = "IL",
                        extraCode5 = "A2",
                        annualSalary = 300000,
                        extraInt1 = 3
                    });
                    RuleParameter dependentParameter3 = new RuleParameter("dependent", new DependentInput()
                    {
                        name = "Jane Doe",
                        gender = "F",
                        age = 42
                    });
                    _ruleParameters.Add(memberParameter3);
                    _ruleParameters.Add(dependentParameter3); break;
                case RuleLibrary.RuleWithAction:
                    RuleParameter memberParameter4 = new RuleParameter("member", new MemberInput()
                    {
                        name = "John Doe",
                        age = 52,
                        stateCode = "IL",
                        extraCode5 = "A2",
                        annualSalary = 300000,
                        extraInt1 = 3,
                        forzenSalary = 2500,
                        managerEmployeeNo = "3A",
                        fullOrPartTimeCode = "FT"
                    });
                    _ruleParameters.Add(memberParameter4);
                    break;
                case RuleLibrary.CalculationExample:
                    RuleParameter scoreParam = new RuleParameter("input1", new SubjectScore());
                    _ruleParameters.Add(scoreParam);
                    break;

            }

        }

        public List<string> GetEvaluatedRule()
        {
            List<string> result = new List<string>();
            foreach (var item in _ruleWorkflow)
            {
                List<RuleResultTree> resultList = _businesRuleEngine.ExecuteAllRulesAsync(item.WorkflowName, _ruleParameters.ToArray()).Result;
                resultList.ForEach(evalItem =>
                {
                    if (evalItem.IsSuccess)
                    {
                        result.Add(evalItem.Rule.SuccessEvent);
                    }
                    else
                    {
                        if (evalItem.ActionResult != null && evalItem.ActionResult.Output != null)
                        {
                            result.Add(evalItem.ActionResult.Output.ToString());
                        }
                    }
                });
            }

            return result;
        }

        public async Task<List<string>> GetEvaluateRuleWithActionFlow(string ruleName)
        {
            List<string> output = new List<string>();
            foreach (var item in _ruleWorkflow)
            {
                var workflowResult = await _businesRuleEngine.ExecuteActionWorkflowAsync(item.WorkflowName, ruleName, _ruleParameters.ToArray());
                foreach (var result in workflowResult.Results)
                {
                    if (result.IsSuccess)
                    {
                        output.Add(result.Rule.SuccessEvent);
                    }
                }
            }
            return output;
        }
    }
}
