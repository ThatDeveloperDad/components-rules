using System;

namespace DevDad.RulesAccess.Abstractions;

/// <summary>
/// Defines a single rule that is accessed by a RulesAccess service.
/// </summary>
public class RuleDefinition
{
    /// <summary>
    /// Default constructor for RuleDefinition.  This is required for serialization.  Do not use this constructor in your code.
    /// </summary>
    public RuleDefinition() { }

    /// <summary>
    /// Constructor for RuleDefinition.  This is the constructor you should use in your code when manually
    /// creating RuleDefinitions.
    /// </summary>
    /// <param name="ruleName"></param>
    /// <param name="subjectTypeName"></param>
    /// <param name="propertyTypeName"></param>
    /// <param name="propertyName"></param>
    /// <param name="operatorKindName"></param>
    /// <param name="comparisonConstant"></param>
    public RuleDefinition(string ruleName, string subjectTypeName, string propertyTypeName, string propertyName, string operatorKindName, object comparisonConstant)
    {
        RuleName = ruleName;
        SubjectTypeName = subjectTypeName;
        PropertyTypeName = propertyTypeName;
        PropertyName = propertyName;
        OperatorKindName = operatorKindName;
        ComparisonConstant = comparisonConstant;
    }


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
