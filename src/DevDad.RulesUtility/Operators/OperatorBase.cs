using System;

namespace DevDad.RulesUtility.Operators;

public abstract class OperatorBase
{
    protected readonly Dictionary<Type, Func<object, object, bool>> _typeStrategies;
    public OperatorKinds OperatorKind { get; private init; }

    protected OperatorBase(OperatorKinds operatorKind)
    {
        OperatorKind = operatorKind;
        _typeStrategies = new Dictionary<Type, Func<object, object, bool>>();
        RegisterKnownTypeStrategies();
    }

    public virtual bool Evaluate<T>(T? valueToTest, T baseValue)     
    {
        if(valueToTest == null || baseValue == null)
        {
            return false;
        }

        _typeStrategies.TryGetValue(typeof(T), out var strategy);
        if(strategy == null)
        {
            throw new ArgumentException($"There is no {OperatorKind} evaluator for type {typeof(T)}.");
        }

        return strategy(valueToTest, baseValue);
    }

    // Overload for IEnumerable<T> baseline value
    public virtual bool Evaluate<T>(T? testValue, IEnumerable<T> baselineValues)
    {
        if(testValue == null)
        {
            return false;
        }
        return baselineValues.Contains(testValue);
    }

    /// <summary>
    /// Allows custom Types to register an evaluation strategy with the
    /// Operator instance.
    /// </summary>
    /// <typeparam name="T">The Operand Type handled by this Operation expression</typeparam>
    /// <param name="strategy">A Function that compares two instances of Type supported by this strategy and returns whether the comparison is true or false.</param>
    public virtual void RegisterTypeStrategy<T>(Func<T, T, bool> strategy)
    {
        _typeStrategies.Add(typeof(T), (x, y) => strategy((T)x, (T)y));
    }

    protected abstract void RegisterKnownTypeStrategies();

}
