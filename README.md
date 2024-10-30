# components-rules
Contains the code to create and execute serializable Rules so that I don't have to hard-code things like validation logic anymore.

## Concepts
Within this repository, a Rule is an expression that can be evaluated to either a True or False result.

A Rule has a Subject (any Class with readable properties of a primitive type.)  
A Rule has a PropertyName (which identifies the Property on the Subject to which the rule applies.)  
A Rule has an Operator (which describes the comparison operation between the Subject and the Rule.)  
A Rule has a ComparisonConstant (which is the value that the Subject.Property must satisfy to pass the Rule.)  

This implementation supports the common Operation kinds against most of the primitive types avilable in .Net.

## To use this code:
For now, just Clone or Fork the repository, and copy the RulesUtility folder into your own Solutions.  
Add a project reference, and start building your rules.

## Points of Interest

### ISimpleRule
Defines an executable Rule that can be added to a collection of applicable rules or executed in an ad-hoc fashion.

### RuleDefinition
A simple .Net class that can act as a DTO or basis for a Storage Model for Rule definitions for your system.  
For each Rule you need to run, you create a RuleDefinition instance.  These instances are then passed to the RuleFactory to be converted into executuable Rules.

### RuleFactory
Static .Net class with a BuildRule method that accepts a RuleDefinition instance and returns an instance of an ISimpleRule implementation.

### SampleConsole.csproj
A simple console application that imports RulesUtility and demonstrates the construction and execution of these concepts.

### ValidationEngine
The Validation Engine that I've implemented, here "rhymes with" the RulesUtility.  That is, the public contract on that Engine class is very narrow.  

It exposes a single generic method:  
**Validate<T>(T subjectInstance, string? activityContext = null) returns ValidationResult<T>**  

In this case, "T" represents the Type that you'll be validating with this method.
Unlike the RulesUtility, which returns a bool from each Rule execution, the Validator returns a ValidationResult<T>, which wraps the Subject instance, and provides a collection of PropertyError objects that can be logged locally, and transmitted back to whichever client requested the use case we're executing.
