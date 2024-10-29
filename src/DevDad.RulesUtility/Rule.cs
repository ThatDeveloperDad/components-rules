using System;
using System.Reflection;

namespace DevDad.RulesUtility;

internal class Rule<T, V>:ISimpleRule
{
    private readonly PropertyInfo _propToTest;

    public Rule(string functionName, string targetProperty, V baseValue, RuleExpression expression)
    {
        PropertyName = targetProperty;
        BaseValue = baseValue;
        Expression = expression;

        _propToTest = RuleAppliesTo.GetProperty(PropertyName) 
            ?? throw new Exception($"Property {PropertyName} not found on Type {RuleAppliesTo.Name}");
        if(_propToTest.PropertyType != typeof(V))
        {
            throw new Exception($"The RuleDefinition's PropertyTypeName specifies {typeof(V).Name}, but the actual property is of type {_propToTest.GetType().Name}.");
        }
        
    }
    
    public Type RuleAppliesTo => typeof(T);
    public string PropertyName {get; init; }

    public Type PropertyType => typeof(V);

    public V BaseValue { get; init; }

    public RuleExpression Expression { get; init; }

    public bool Execute(object testObject)
    {
        T typedSubject = (T)Convert.ChangeType(testObject, typeof(T));
        bool evaluationResult = Execute(typedSubject);
        return evaluationResult;
    }

    public string SubjectTypeName => RuleAppliesTo.Name;

    

    private bool Evaluate(V testValue)
    {
        return Expression.Evaluate(testValue, BaseValue);
    }

    private bool Execute(T testObject)
    {
        if(testObject == null)
        {
            return false;
        }

        var testPropValue = _propToTest.GetValue(testObject);

        if(testPropValue == null)
        {
            return false;
        }
        //Convert the Reflected testPropValue to the correct Type for the rule.
        V testValue = (V)testPropValue;
        return Evaluate(testValue);
    }   
}