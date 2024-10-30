using System;
using Storage = DevDad.RulesAccess.Abstractions;
using DevDad.RulesUtility;

namespace DevDad.ValidationEngine;

public class Validator : IValidator
{
    private readonly Dictionary<string, IEnumerable<ValidationRule>> _ruleSets = new();

    public Validator()
    {
        
    }

    public Validator(Storage.IRulesAccess rulesAccess, IEnumerable<Type> subjectTypes)
    {
        //TODO: use the injected rulesAccess component to load the rules and populate the _ruleSets dictionary.
        InitializeRulesets(rulesAccess, subjectTypes);
    }

    /// <summary>
    /// Executes the set of rules that apply to the given subject payload and activityContext.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="payload"></param>
    /// <param name="activityContext"></param>
    /// <returns></returns>
    public ValidationResult<T> Validate<T>(T payload, string? activityContext = null)
    {
        ValidationResult<T> result = new ValidationResult<T>(payload);

        string ruleSetKey = $"{typeof(T).Name}|{activityContext??"All"}";

        if(_ruleSets.TryGetValue(ruleSetKey, out IEnumerable<ValidationRule>? ruleSet))
        {
            foreach(ValidationRule rule in ruleSet)
            {
                if(rule.Execute(payload, out PropertyError? error) == false)
                {
                    if (error != null)
                    {
                        result.AddError(error);
                    }
                }
            }
        }
        else
        {
            result.AddError
                (new PropertyError
                    ("SubjectInstance", 
                     $"No rules have been defined for the activity {activityContext} on Type {typeof(T).Name}.",
                     PropertyErrorSeverity.Warning)
                );
        }

        return result;
    }

    private void InitializeRulesets(Storage.IRulesAccess rulesAccess, IEnumerable<Type> subjectTypes)
    {
        var subjectTypeNames = subjectTypes.Select(t => t.Name);
        IEnumerable<Storage.ValidationRuleDefinition> ruleDefinitions = rulesAccess.LoadRules<Storage.ValidationRuleDefinition>(subjectTypeNames);

        foreach(Storage.ValidationRuleDefinition ruleDefinition in ruleDefinitions)
        {
            string activityContext = ruleDefinition.ActivityContext ?? "All";
            string failureMessage = ruleDefinition.FailureMessage ?? "";
            Storage.RuleDefinition? storageDefinition = ruleDefinition.RuleDefinition;

            RuleDefinition utilityDefinition = 
            new(
                ruleName: storageDefinition?.RuleName ?? "",
                subjectTypeName: storageDefinition?.SubjectTypeName ?? "",
                propertyTypeName: storageDefinition?.PropertyTypeName ?? "",
                propertyName: storageDefinition?.PropertyName ?? "",
                operatorKindName: storageDefinition?.OperatorKindName ?? "",
                comparisonConstant: storageDefinition?.ComparisonConstant ?? ""
            );
            
            ISimpleRule? innerRule = RuleFactory.BuildRule(utilityDefinition);

            ValidationRule rule = new(innerRule, failureMessage);
            
            string ruleSetKey = $"{ruleDefinition.SubjectTypeName}|{activityContext}";
            if(_ruleSets.TryGetValue(ruleSetKey, out IEnumerable<ValidationRule>? ruleSet))
            {
                _ruleSets[ruleSetKey] = ruleSet.Append(rule);
            }
            else
            {
                _ruleSets[ruleSetKey] = new List<ValidationRule> { rule };
            }
        }
    }
}

