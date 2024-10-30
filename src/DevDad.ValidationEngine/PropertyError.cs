namespace DevDad.ValidationEngine;

public record class PropertyError
{
    public PropertyError(string propertyName, string errorMessage, PropertyErrorSeverity severity = PropertyErrorSeverity.Error)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
        Severity = severity;
    }

    public string PropertyName { get; init; }
    public string ErrorMessage { get; init; }

    public PropertyErrorSeverity Severity { get; init; }
}

public enum PropertyErrorSeverity
{
    /// <summary>
    /// Applies to Property Errors that signal a Process should be Halted due to invalid Subject State.
    /// </summary>
    Error,
    /// <summary>
    /// Applies to errors that should be logged as potential issues, but should not halt the Use Case Execution.
    /// </summary>
    Warning
}
