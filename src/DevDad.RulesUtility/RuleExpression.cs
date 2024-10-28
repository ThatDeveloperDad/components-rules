using System;
using DevDad.RulesUtility.Operators;

namespace DevDad.RulesUtility;

public class RuleExpression
{
    
    public OperatorKinds Operator { get; init; }

    private readonly OperatorBase _evaluationStrategy;

    public RuleExpression(OperatorKinds operatorKind)
    {
        Operator = operatorKind;
        _evaluationStrategy = CreateOperator(Operator);
    }

    public bool Evaluate<T>(T? testValue, T baselineValue)
    {
        return _evaluationStrategy.Evaluate(testValue, baselineValue);
    }

    public bool Evaluate<T>(T? testValue, IEnumerable<T> set){
        return _evaluationStrategy.Evaluate(testValue, set);
    }

    /// <summary>
    /// Provides a method by which custom TYpe Strategies can be added to the Expression's 
    /// internal list of Strategies.
    /// </summary>
    /// <typeparam name="T">The Type the new evaluation expression requires as its operands</typeparam>
    /// <param name="strategy">The Evaluation Expression to use for the specified Type</param>
    public void AddTypeStrategy<T>(Func<T, T, bool> strategy)
    {
        _evaluationStrategy.RegisterTypeStrategy(strategy);
    }

    private OperatorBase CreateOperator(OperatorKinds operatorKind)
    {
        switch(operatorKind)
    {
        case OperatorKinds.Equals:
            return new EqualOperator();
        case OperatorKinds.NotEquals:
            return new NotEqualsOperator();
        case OperatorKinds.GreaterThan:
            return new GreaterThanOperator();
        case OperatorKinds.LessThan:
            return new LessThanOperator();
        case OperatorKinds.GreaterOrEquals:
            return new GreaterOrEqualsOperator();
        case OperatorKinds.LessOrEquals:
            return new LessOrEqualsOperator();
        case OperatorKinds.IsContainedBy:
            return new ContainsOperator();
        default:
            throw new ArgumentOutOfRangeException(nameof(operatorKind), operatorKind, null);
    }
    }
}
