// See https://aka.ms/new-console-template for more information
using System;
using DevDad.RulesUtility;
using DevDad.RulesUtility.Operators;
using SampleConsole;

// Demonstrates how to create, then use simple rules with 
// different Classes.

// Create a couple instances of some class.
// These are the "Subjects" of the Rules.
MyClass sampleClass = new()
{
    Name = "Arthas Menethil",
    BirthDate = new DateTime(1976, 6, 6)
};

MyClass otherSampleClass = new()
{
    Name = "Anduin Wrynn",
    BirthDate = new DateTime(2009, 9, 13)
};

// To clean up the output code, let's put those into a list.
List<MyClass> subjects = new() 
    { 
        sampleClass, 
        otherSampleClass,
        new() { Name = "Garrosh Hellscream", BirthDate = new DateTime(1980, 1, 1) }
    };

// Now, we'll define a couple of rules.
RuleDefinition nameIsArthas = new();
// RuleName is metadata, used to identify the Rule.
nameIsArthas.RuleName = "IsTheLichKing";
// Next three properties set up the type safety for the rule.
nameIsArthas.SubjectTypeName = typeof(MyClass).Name;
nameIsArthas.PropertyName = nameof(MyClass.Name);
nameIsArthas.PropertyTypeName = typeof(string).Name;
// Next, we define the Operator used to evaluate it.
// The operators are all defined in the OperatorKinds enum.
nameIsArthas.OperatorKindName = OperatorKinds.Equals.ToString();
// Finally, we define the value to compare against.
nameIsArthas.ComparisonConstant = "Arthas Menethil";

// Same thing for the second rule, 
// but let's use a different property & operator.
// We'll also use a different constructor.
RuleDefinition canBuyAle = new
    (
        ruleName: "CanGoToTheTavern",
        subjectTypeName: typeof(MyClass).Name,
        propertyName: nameof(MyClass.Age),
        operatorKindName: OperatorKinds.GreaterOrEquals.ToString(),
        comparisonConstant: 21,
        propertyTypeName: typeof(int).Name
    );

// One more example, showing the alternate constructor.
// This constructor is best used for ad-hoc rule definitions
// created inside your code.  (You can's serialize or Transmit Type parmeters.)
RuleDefinition onlyGarrosh = new
    (
        ruleName: "IsGarroshHellscream",
        subjectType: typeof(MyClass),
        propertyName: nameof(MyClass.Name),
        operatorKind: OperatorKinds.Equals,
        comparisonConstant: "Garrosh Hellscream"
    );

// We create executable instances of the RuleDefinitions by
// passing those definitions into the RuleFactory.
ISimpleRule isLichKing = RuleFactory.BuildRule(nameIsArthas);
ISimpleRule canGoToTavern = RuleFactory.BuildRule(canBuyAle);
ISimpleRule feelsGreatAboutTheramore = RuleFactory.BuildRule(onlyGarrosh);

// Now, we can Execute them.
foreach(MyClass subject in subjects)
{
    // We pass the subject into the Execute method.
    string isTheLichKing = isLichKing.Execute(subject)?"is":"is not";
    string tavernOrder = canGoToTavern.Execute(subject)?"Here's your icy cold beer, your unholiness.":"Would you like some milk, youngster?";
    string theramoreReaction = feelsGreatAboutTheramore.Execute(subject)?"Destroying Theramore will Make the Horde Great Again!":"He's kinda mad about Theramore.";
    
    Console.WriteLine($"{subject.Name} {isTheLichKing} the Lich King.");
    Console.WriteLine(tavernOrder);
    Console.WriteLine(theramoreReaction);
    Console.WriteLine();
}