using DevDad.RulesUtility.Operators;
using DevDad.RulesUtility.Tests.TestData;

namespace DevDad.RulesUtility.Tests;

public class RulesUtilityTests
{
    private readonly List<RuleDefinition> _ruleDefinitions;

    public RulesUtilityTests()
    {
        _ruleDefinitions = CreateRuleDefinitions();
    }


#region BooleanProperty rule tests
    [Fact]
    public void Test_BoolProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.BoolProperty = (bool)GetDefaultValue(typeof(bool));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r=> r.RuleName == "BoolProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_BoolProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "BoolProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);    

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion BooleanProperty rule tests  

#region DoubleProperty rule tests
    [Fact]
    public void Test_DoubleProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = (double)GetDefaultValue(typeof(double));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = (double)GetDefaultValue(typeof(double));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = (double)GetDefaultValue(typeof(double)) + 1;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = 3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = (double)GetDefaultValue(typeof(double));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = -3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = 3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = -3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = -3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = 3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = 3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 3.14159, 2.71828 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DoubleProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DoubleProperty = 3.14159;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DoubleProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 2.71828, 1.61803 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion DoubleProperty rule tests

#region FloatProperty rule tests
    [Fact]
    public void Test_FloatProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = (float)GetDefaultValue(typeof(float));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = (float)GetDefaultValue(typeof(float));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = (float)GetDefaultValue(typeof(float)) + 1;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = 3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = (float)GetDefaultValue(typeof(float));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = -3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = 3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = -3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = -3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = 3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = 3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 3.14159f, 2.71828f };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_FloatProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.FloatProperty = 3.14159f;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "FloatProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 2.71828f, 1.61803f };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion FloatProperty rule tests

#region LongProperty rule tests
    [Fact]
    public void Test_LongProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = (long)GetDefaultValue(typeof(long));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = (long)GetDefaultValue(typeof(long));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = (long)GetDefaultValue(typeof(long)) + 1;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = 100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = (long)GetDefaultValue(typeof(long));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = -100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = 100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = -100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = -100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = 100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = 100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 100L, 200L };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_LongProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.LongProperty = 100L;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "LongProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 200L, 300L };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion LongProperty rule tests

#region ShortProperty rule tests
    [Fact]
    public void Test_ShortProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = (short)GetDefaultValue(typeof(short));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = (short)GetDefaultValue(typeof(short));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = (short)GetDefaultValue(typeof(short));
        subject.ShortProperty++;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = (short)GetDefaultValue(typeof(short));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { (short)100, (short)200 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_ShortProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.ShortProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "ShortProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { (short)200, (short)300 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion ShortProperty rule tests

#region CharProperty rule tests
    [Fact]
    public void Test_CharProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.CharProperty = (char)GetDefaultValue(typeof(char));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_CharProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_CharProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.CharProperty = (char)GetDefaultValue(typeof(char));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_CharProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.CharProperty = (char)GetDefaultValue(typeof(char));
        subject.CharProperty = 'B';
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_CharProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.CharProperty = 'A';
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 'A', 'B' };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_CharProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.CharProperty = 'A';
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "CharProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 'B', 'C' };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion CharProperty rule tests

#region StringProperty rule tests
    [Fact]
    public void Test_StringProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = (string)GetDefaultValue(typeof(string));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_StringProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_StringProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = (string)GetDefaultValue(typeof(string));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_StringProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = (string)GetDefaultValue(typeof(string)) + "Mismatch";
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_StringProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = "test";
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { "test", "example" };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_StringProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = "test";
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { "example", "sample" };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion StringProperty rule tests

#region IntProperty rule tests
    [Fact]
    public void Test_IntProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = (int)GetDefaultValue(typeof(int));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = (int)GetDefaultValue(typeof(int));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = (int)GetDefaultValue(typeof(int)) + 1;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = (int)GetDefaultValue(typeof(int));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = -100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 100, 200 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_IntProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.IntProperty = 100;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "IntProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 200, 300 };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion IntProperty rule tests

#region DecimalProperty rule tests
    [Fact]
    public void Test_DecimalProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = (decimal)GetDefaultValue(typeof(decimal));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = (decimal)GetDefaultValue(typeof(decimal));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = (decimal)GetDefaultValue(typeof(decimal)) + 1;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = 100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = (decimal)GetDefaultValue(typeof(decimal));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = -100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = 100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = -100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = -100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = 100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = 100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 100m, 200m };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DecimalProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DecimalProperty = 100m;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DecimalProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { 200m, 300m };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
    #endregion DecimalProperty rule tests

#region DateTimeProperty rule tests
    [Fact]
    public void Test_DateTimeProperty_EqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = (DateTime)GetDefaultValue(typeof(DateTime));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = subject.DateTimeProperty;
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_EqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_NotEqualsRule_WithSubjectMatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = (DateTime)GetDefaultValue(typeof(DateTime));
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = subject.DateTimeProperty;
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_NotEqualsRule_WithSubjectMismatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        DateTime subjectValue = (DateTime)GetDefaultValue(typeof(DateTime));
        subjectValue = subjectValue.AddDays(1);
        subject.DateTimeProperty = subjectValue;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_NotEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_GreaterThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now.AddDays(1);
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_GreaterThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        DateTime subjectValue = (DateTime)GetDefaultValue(typeof(DateTime));
        subjectValue = subjectValue.AddDays(-1);
        subject.DateTimeProperty = subjectValue;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_GreaterThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_LessThanRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now.AddDays(-1);
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_LessThanRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        DateTime subjectValue = (DateTime)GetDefaultValue(typeof(DateTime));
        subjectValue = subjectValue.AddDays(1);
        subject.DateTimeProperty = subjectValue;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_LessThan")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_GreaterOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_GreaterOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now.AddDays(-1);
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_GreaterOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_LessOrEqualsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = subject.DateTimeProperty;
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_LessOrEqualsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now.AddDays(1);
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_LessOrEquals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_ContainsRule_WithSubjectMatch_ExpectTrue()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { DateTime.Now, DateTime.Now.AddDays(1), subject.DateTimeProperty };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = true;
        // Assert
        Assert.Equal(expected, passed);
    }

    [Fact]
    public void Test_DateTimeProperty_ContainsRule_WithSubjectMismatch_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.DateTimeProperty = DateTime.Now;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "DateTimeProperty_IsContainedBy")
            ?? throw new Exception("Rule definition not found.");
        ruleDefinition.ComparisonConstant = new[] { DateTime.Now.AddDays(1), DateTime.Now.AddDays(2) };
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }
#endregion DateTimeProperty rule tests

#region Null-Checking tests

    [Fact]
    public void RulesEngineTest_WhenPropertyIsNull_ExpectFalse()
    {
        // Arrange
        var subject = SampleSubject.CreateSample();
        subject.StringProperty = null;
        var ruleDefinition = _ruleDefinitions
            .FirstOrDefault(r => r.RuleName == "StringProperty_Equals")
            ?? throw new Exception("Rule definition not found.");
        ISimpleRule rule = RuleFactory.BuildRule(ruleDefinition);

        // Act
        var passed = rule.Execute(subject);
        bool expected = false;
        // Assert
        Assert.Equal(expected, passed);
    }

#endregion Null-Checking tests
    

#region Helper methods
    private List<RuleDefinition> CreateRuleDefinitions()
        {
            var ruleDefinitions = new List<RuleDefinition>();
            var operatorKinds = Enum.GetValues(typeof(OperatorKinds));
            var properties = typeof(SampleSubject).GetProperties();

            foreach (OperatorKinds operatorKind in operatorKinds)
            {
                foreach (var property in properties)
                {
                    var ruleDefinition = new RuleDefinition
                    {
                        RuleName = $"{property.Name}_{operatorKind}",
                        SubjectTypeName = typeof(SampleSubject).Name,
                        PropertyTypeName = property.PropertyType.Name,
                        PropertyName = property.Name,
                        OperatorKindName = operatorKind.ToString(),
                        ComparisonConstant = GetDefaultValue(property.PropertyType)
                    };

                    ruleDefinitions.Add(ruleDefinition);
                }
            }

            return ruleDefinitions;
        }

        private object GetDefaultValue(Type type)
        {
            if (type == typeof(bool)) return true;
            if (type == typeof(double)) return 0.0;
            if (type == typeof(float)) return 0.0f;
            if (type == typeof(long)) return 0L;
            if (type == typeof(short)) return (short)0;
            if (type == typeof(byte)) return (byte)0;
            if (type == typeof(char)) return 'A';
            if (type == typeof(string)) return "test";
            if (type == typeof(int)) return 0;
            if (type == typeof(decimal)) return 0.0m;
            if (type == typeof(DateTime)) return DateTime.Now;
            throw new NotSupportedException($"Type {type.FullName} is not supported.");
        }

#endregion Helper methods
}