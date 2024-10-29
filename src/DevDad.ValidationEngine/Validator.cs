using System;
using DevDad.RulesUtility;

namespace DevDad.ValidationEngine;

public class Validator : IValidator
{
    private readonly Dictionary<string, IEnumerable<ValidationRule>> _ruleSets = new();

    public Validator()
    {
        //TODO:  We need to populate the _ruleSets with RuleDefinitions that come from ????
    }

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
}

