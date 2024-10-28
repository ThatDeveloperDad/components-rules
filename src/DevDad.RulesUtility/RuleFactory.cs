using System.Reflection;
using DevDad.RulesUtility.Operators;

namespace DevDad.RulesUtility;


public static class RuleFactory
{
    public static ISimpleRule BuildRule(RuleDefinition ruleDefinition)
    {
        //First, we resolve OperatorKindName to an instance of the OperatorKinds enum.
        var operatorKind = (OperatorKinds)Enum.Parse(typeof(OperatorKinds), ruleDefinition.OperatorKindName);
        if(operatorKind == OperatorKinds.IsContainedBy)
        {
            return BuildCollectionRule(ruleDefinition);   
        }

        // Use Reflection to get an instance of Type that matches the TYpenames referenced in the RuleDefinition.
        Type subjectType = GetTypeFromAppDomain(ruleDefinition.SubjectTypeName) ?? throw new Exception($"Type {ruleDefinition.SubjectTypeName} not found");
        Type operandType = GetTypeFromAppDomain(ruleDefinition.PropertyTypeName) ?? throw new Exception($"Type {ruleDefinition.PropertyTypeName} not found");
        Type? operandCollectionType = null;

        // We can use these Type arguments to find the correct constructor method to create the RUle we need to create.
        var ruleType = typeof(Rule<,>).MakeGenericType(subjectType, operandType);
        var ruleCtor = ruleType.GetConstructor(new Type[] { typeof(string), typeof(string), operandType, typeof(RuleExpression) });

        // Now we need to create the RuleExpression that will be used by the Rule.
        
        
        // Next, we create the RuleExpression instance.
        var ruleExpression = new RuleExpression(operatorKind);

        // Need to convert the ComparisonConstant to the correct Type. 
        // If the ComparisonType is an IEnumerable, we need to convert 
        // the ComparisonConstant to an IEnumerable of the operandType.
        object? comparisonConstant;
        if(operandCollectionType!=null)
        {
            comparisonConstant = ruleDefinition.ComparisonConstant;
        }
        else
        {
            comparisonConstant = Convert.ChangeType(ruleDefinition.ComparisonConstant, operandType);
        }
        

        // Finally, we can build our RuleBase instance as cast it as an instance of our ruleTYpe type.
        var ruleInstance = ruleCtor?.Invoke(new object[] { ruleDefinition.RuleName, ruleDefinition.PropertyName, comparisonConstant, ruleExpression })
            ?? throw new Exception("RuleBase constructor not found");

        // convert the ruleInstance to the Type defined by the ruleType variable.
        var rule = Convert.ChangeType(ruleInstance, ruleType);

        return (ISimpleRule)rule;
    }

    private static ISimpleRule BuildCollectionRule(RuleDefinition ruleDefinition){
        
        // FIRST!!!!
        // We need to use reflection to create a Derived Type for the
        // rule definition we've passed in.
        // We HAVE a generic definition of a Rule that uses a Collection of values
        // to test correctness, but we don't know until runtime what the
        // Subject of that rule will be, nor do we know the Property and the Type of
        // that property until we're running the code.

        // Translate the String Values (Names) of those types into actual Type instances.
        Type subjectType = GetTypeFromAppDomain(ruleDefinition.SubjectTypeName) ?? throw new Exception($"Type {ruleDefinition.SubjectTypeName} not found");
        Type operandType = GetTypeFromAppDomain(ruleDefinition.PropertyTypeName) ?? throw new Exception($"Type {ruleDefinition.PropertyTypeName} not found");
        Type? operandCollectionType = typeof(IEnumerable<>).MakeGenericType(operandType);

        // Use those Types to build the concrete Type of the Class Template.
        var ruleType = typeof(CollectionRule<,>).MakeGenericType(subjectType, operandType);
        
        // Now, we find the constructor for that type that we'll need to call.
        var ruleCtor = ruleType.GetConstructor
            (new Type[] 
                { 
                    typeof(string), 
                    typeof(string), 
                    operandCollectionType, 
                    typeof(RuleExpression) 
                }
            );

        // SECOND:
        // Get the actual instances of the Types we need to pass into the Constructor 
        // that we just created.
        var operatorKind = (OperatorKinds)Enum.Parse(typeof(OperatorKinds), ruleDefinition.OperatorKindName);
        var ruleExpression = new RuleExpression(operatorKind);

        // Need to convert the ComparisonConstant to the correct Type. 
        // If the ComparisonType is an IEnumerable, we need to convert 
        // the ComparisonConstant to an IEnumerable of the operandType.

        // This probably ain't right.  FAFO time.
        object? comparisonConstant = ruleDefinition.ComparisonConstant;

        // Finally, we can build our RuleBase instance as cast it as an instance of our ruleTYpe type.
        var ruleInstance = ruleCtor?.Invoke(new object[] { ruleDefinition.RuleName, ruleDefinition.PropertyName, comparisonConstant, ruleExpression })
            ?? throw new Exception("RuleBase constructor not found");

        // convert the ruleInstance to the Type defined by the ruleType variable.
        var rule = Convert.ChangeType(ruleInstance, ruleType);

        return (ISimpleRule)rule;
        
    }

    private static Type? GetTypeFromAppDomain(string typeName)
    {
        // Try to get the type from the current assembly first
        Type? type = Type.GetType(typeName);
        if (type != null)
        {
            return type;
        }

        // If not found, scan all loaded assemblies in the current AppDomain
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = assembly
                .GetTypes()
                .FirstOrDefault(t=> t.Name == typeName);
            if (type != null)
            {
                return type;
            }
        }

        // Return null if the type is not found
        return null;
    }
}

