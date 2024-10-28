using System;

namespace DevDad.RulesUtility;

public class RuleDefinition
{
    /// <summary>
    /// A plain language name for the Rule.
    /// </summary>
    public string RuleName { get; set; } = string.Empty;

    /// <summary>
    /// The Type Name for the object that the Rule is applied to.
    /// </summary>
    public string SubjectTypeName { get; set; } = string.Empty;

    /// <summary>
    /// The Type Name for the property that the Rule is applied to.
    /// </summary>
    public string PropertyTypeName { get; set; } = string.Empty;

    /// <summary>
    /// The name of the Subject's property that the Rule is applied to.
    /// </summary>
    public string PropertyName { get; set; } = string.Empty;

    /// <summary>
    /// Identifies the Operator that this rule uses.
    /// </summary>
    public string OperatorKindName { get; set; } = string.Empty;

    /// <summary>
    /// The value used to compare the Subject.Property to when determining whethe
    /// that Subject instance "passes" the Rule.
    /// </summary>
    public object ComparisonConstant { get; set; } = string.Empty;
}
