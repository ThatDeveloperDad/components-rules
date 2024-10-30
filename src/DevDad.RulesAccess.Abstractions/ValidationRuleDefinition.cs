using System;

namespace DevDad.RulesAccess.Abstractions;

/// <summary>
/// Defines a single validations rule that is accessed by a RulesAccess service.
/// It associates a RuleDefinition with an ActivityContext and a FailureMessage.
/// </summary>
public record ValidationRuleDefinition
{

    public ValidationRuleDefinition() { }

    public ValidationRuleDefinition(string activityContext, string failureMessage, RuleDefinition ruleDefinition)
    {
        ActivityContext = activityContext;
        FailureMessage = failureMessage;
        RuleDefinition = ruleDefinition;
    }

    /// <summary>
    /// Identifies the Activity that the associated Rule applies to.
    /// </summary>
    public string? ActivityContext { get; init; }

    public string? SubjectTypeName => RuleDefinition?.SubjectTypeName;

    /// <summary>
    /// Provides the error message to add to a PropertyError when the Subject fails the rule.
    /// </summary>
    public string? FailureMessage { get; init; }

    public RuleDefinition? RuleDefinition { get; init; }
}
