# components-rules
Contains the code to create and execute serializable Rules so that I don't have to hard-code things like validation logic anymore.

## Concepts
Within this repository, a Rule is an expression that can be evaluated to either a True or False result.

A Rule has a Subject (any Class with readable properties of a primitive type.)
A Rule has a PropertyName (which identifies the Property on the Subject to which the rule applies.)
A Rule has an Operator (which describes the comparison operation between the Subject and the Rule.)
A Rule has a ComparisonConstant (which is the value that the Subject.Property must satisfy to pass the Rule.)

This implementation supports the common Operation kinds against most of the primitive types avilable in .Net.

## Code artifacts

### ISimpleRule
Defines an executable Rule that can be added to a collection of applicable rules or exeuted in an ad-hoc fashion.

### RuleDefinition
A simple .Net class that can act as a DTO or basis for a Storage Model for Rule definitions for your system.

### RuleFactory
Static .Net class with a BuildRule method that accepts a RuleDefinition instance and returns an instance of an ISimpleRule implementation.

### SampleConsole.csproj
A simple console application that imports RulesUtility and demonstrates the construction and execution of these concepts.

### ValidationEngine
Coming soon.  It's only stubbed out here. ;)
 * As I work out the Validation Engine, i'll be adding Effects to the Rule concept.
   * Initially, the Effect will be some function that takes an action using the Subject instance if the Rule evaluates as false.  Not sure how I'll do that yet, but I have some ideas.
   * My idea here is that the Effect will add a function that returns a PropertyError when the Rule evaluates false.  This property error would be added to the ValidationResult and sent back to the caller after all Rules have run.  We'll see how this plays out.  Might have to get a little freaky in the Validation Engine's internals.

## To use this code:
For now, just Clone or Fork the repository, and copy the RulesUtility folder into your own Solutions.
Add a project reference, and start building your rules.
