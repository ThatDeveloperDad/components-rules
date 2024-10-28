using System;
using System.Linq;

namespace DevDad.RulesUtility.Operators;

public class ContainsOperator : OperatorBase
{
    public ContainsOperator() 
        : base(OperatorKinds.IsContainedBy) { }

    protected override void RegisterKnownTypeStrategies()
    {
        // No need for Type Strategies.
        // The Contains operation is only 
        // supported for IEnumerable<T> baseline values
        // and does not require type awareness.
    }
}