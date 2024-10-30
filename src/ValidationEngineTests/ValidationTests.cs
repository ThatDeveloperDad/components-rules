using DevDad.RulesAccess.Abstractions;
using DevDad.ValidationEngine;
using ValidationEngineTests.TestSupport;

namespace ValidationEngineTests;

public class ValidateTests
{
    private static IRulesAccess _fakeRulesAccess = new FakeRuleAccess();
    private IValidator _notConfiguredValidator = new Validator();
    private static List<Type> typesToCheck = new List<Type> { typeof(TestSampleClass) };
    private IValidator _configuredValidator = new Validator(_fakeRulesAccess, typesToCheck);

    [Fact]
    public void ValidateTest_PassSubjectAndActivity_NoRuleset_ExpectWarning()
    {
        // Arrange
        IValidator classUnderTest = _notConfiguredValidator;
        TestSampleClass subject = new(){
            Name = "John Doe",
            BirthDate = new DateTime(2000, 1, 1)
        };
        string activityName = "TestActivity";

        // Act
        var result = classUnderTest.Validate(subject, activityName);
        int warningCount = result.Errors
            .Count
            (
                e => e.Severity == PropertyErrorSeverity.Warning
            );
        // Assert that the result contains at least one PropertyError that is a Warning.
        Assert.True(warningCount >= 1);
    }

    [Fact]
    public void ValidateTest_PassValidSubject_RuleSetExists_Expect_IsValidTrue()
    {
        // Arrange
        IValidator classUnderTest = _configuredValidator;
        TestSampleClass subject = new(){
            Name = "John Doe",
            BirthDate = new DateTime(2000, 1, 1)
        };
        string activityName = "TestActivity";
        bool expectedIsValid = true;

        // Act
        var result = classUnderTest.Validate(subject, activityName);
        bool actualIsValid = result.IsValid && (result.HasWarnings == false);
        
        // Assert that the result contains at least one PropertyError that is a Warning.
        Assert.Equal(expectedIsValid, actualIsValid);

    }

    [Fact]
    public void ValidateTest_PassNotValidSubject_RuleSetExists_Expect_IsValidFalse()
    {
        // Arrange
        IValidator classUnderTest = _configuredValidator;
        TestSampleClass subject = new(){
            Name = "John Doe",
            BirthDate = DateTime.Now.AddYears(-18)
        };
        string activityName = "TestActivity";
        bool expectedIsValid = false;

        // Act
        var result = classUnderTest.Validate(subject, activityName);
        bool actualIsValid = result.IsValid && (result.HasWarnings == false);
        
        // Assert that the result contains at least one PropertyError that is a Warning.
        Assert.Equal(expectedIsValid, actualIsValid);

    }
}