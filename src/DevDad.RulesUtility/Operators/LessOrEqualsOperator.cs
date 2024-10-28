using System;

namespace DevDad.RulesUtility.Operators;
public class LessOrEqualsOperator : OperatorBase
{
    public LessOrEqualsOperator() 
        : base(OperatorKinds.LessOrEquals) { }

    protected override void RegisterKnownTypeStrategies()
    {
        _typeStrategies
            .Add(typeof(long), 
                 (x, y) => (long)x <= (long)y);
        _typeStrategies
            .Add(typeof(float), 
                 (x, y) => (float)x <= (float)y);
        _typeStrategies
            .Add(typeof(double), 
                 (x, y) => (double)x <= (double)y);
        _typeStrategies
            .Add(typeof(short), 
                 (x, y) => (short)x <= (short)y);
        _typeStrategies
            .Add(typeof(byte), 
                 (x, y) => (byte)x <= (byte)y);
        _typeStrategies
            .Add(typeof(char), 
                 (x, y) => (char)x <= (char)y);
        _typeStrategies
            .Add(typeof(int), 
                 (x, y) => (int)x <= (int)y);
        _typeStrategies
            .Add(typeof(decimal), 
                 (x, y) => (decimal)x <= (decimal)y);
        _typeStrategies
            .Add(typeof(DateTime), 
                 (x, y) => ((DateTime)x) <= ((DateTime)y));
        _typeStrategies
            .Add(typeof(string), 
                 (x, y) => string.Compare(x as string, y as string, StringComparison.OrdinalIgnoreCase) <= 0);
    }
}