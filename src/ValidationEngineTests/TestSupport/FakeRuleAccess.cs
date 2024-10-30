using System;
using DevDad.RulesAccess.Abstractions;
using DevDad.RulesUtility.Operators;

namespace ValidationEngineTests.TestSupport;

public class FakeRuleAccess : IRulesAccess
{
    private readonly Dictionary<string, IEnumerable<IRuleResource>> _rules = new();

    public FakeRuleAccess()
    {
        string activityContext = "TestActivity";
        string ruleDictKeyValue = typeof(TestSampleClass).Name;

        ValidationRuleDefinition minAgeRule 
            = new
            (
                activityContext: activityContext,
                failureMessage: "Must be at least 21 years old.",
                ruleDefinition: new
                (
                    ruleName: "MustBeAtLeast21",
                    subjectTypeName: typeof(TestSampleClass).Name,
                    propertyName: nameof(TestSampleClass.Age),
                    propertyTypeName: typeof(int).Name,
                    operatorKindName: OperatorKinds.GreaterOrEquals.ToString(),
                    comparisonConstant: 21
                )
            );


            _rules.Add(ruleDictKeyValue
                , new List<IRuleResource> 
                    { 
                        minAgeRule 
                    });
    }

    public IEnumerable<T> LoadRules<T>(IEnumerable<string> subjectTypeNames) where T : IRuleResource
    {
        List<T> filteredRules = new();

        foreach(string typeName in subjectTypeNames)
        {
            if(_rules.TryGetValue(typeName, out IEnumerable<IRuleResource>? rules))
            {
                foreach(IRuleResource rule in rules)
                {
                    if(rule is T tRule)
                    {
                        filteredRules.Add(tRule);
                        //TODO:  Come back once it's working, and experiment with this.
                        //yield return tRule;
                    }
                }
            }
        }

        return filteredRules;
    }
}
