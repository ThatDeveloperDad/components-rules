using System;
using System.Runtime.CompilerServices;

namespace DevDad.RulesUtility.Operators;

public class EqualOperator : OperatorBase
{
    public EqualOperator()
        : base(OperatorKinds.Equals) { }
    
    protected override void RegisterKnownTypeStrategies()
    {
        _typeStrategies
            .Add(typeof(bool), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(double), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(float), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(long), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(short), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(byte), 
                 (x, y) => x.Equals(y));

        _typeStrategies
            .Add(typeof(char), 
                 (x, y) => x.Equals(y));
        _typeStrategies
            .Add(typeof(string), 
                 (x, y) => string.Equals(x as string, y as string, StringComparison.OrdinalIgnoreCase));
        
        _typeStrategies
            .Add(typeof(int), 
                 (x, y) => x.Equals(y));
        
        _typeStrategies
            .Add(typeof(decimal), 
                 (x, y) => x.Equals(y));
        
        _typeStrategies
            .Add(typeof(DateTime), 
                 (x, y) => ((DateTime)x).Equals((DateTime)y));
    }
}
