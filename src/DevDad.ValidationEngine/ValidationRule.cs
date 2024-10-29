using System;
using DevDad.RulesUtility;

namespace DevDad.ValidationEngine;

internal class ValidationRule
{
    private const string SubjectIsNullError = "Cannot validate a Null subject instance.";

    private readonly ISimpleRule _rule;
    private readonly string _failureMessage;

    public ValidationRule(ISimpleRule rule, string failureMessage)
    {
        _rule = rule;
        _failureMessage = failureMessage;
    }

    public bool Execute<T>(T subject, out PropertyError? error)
    {
        if (subject == null)
        {
            error = new PropertyError("Subject Instance", SubjectIsNullError);
            return false;
        }

        if(typeof(T).Name != _rule.SubjectTypeName)
        {
            error = new PropertyError("Subject Instance", $"The subject instance is of type {typeof(T).Name}, but the rule is defined for type {_rule.SubjectTypeName}.");
            return false;
        }

        var result = _rule.Execute(subject);
        error = result ? null : new PropertyError(_rule.PropertyName, _failureMessage);
        return result;
    }

}
