namespace DevDad.ValidationEngine;

public record class PropertyError
{
    public PropertyError(string propertyName, string errorMessage, PropertyErrorSeverity severity = PropertyErrorSeverity.Error)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }

    public string PropertyName { get; }
    public string ErrorMessage { get; }

    public PropertyErrorSeverity Severity { get; set; }
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
