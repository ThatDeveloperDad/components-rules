using System;

namespace DevDad.ValidationEngine;

public class ValidationResult<T>
{
    private List<PropertyError> _errors = new();

    public ValidationResult(T payload)
    {
        Payload = payload;
    }

    public T Payload { get; }
    
    public bool IsValid => _errors.Count(e=> e.Severity == PropertyErrorSeverity.Error) == 0;
    
    public bool HasWarnings => _errors.Count(e=> e.Severity == PropertyErrorSeverity.Warning) > 0;

    public IReadOnlyCollection<PropertyError> Errors => _errors.AsReadOnly();

    public void AddError(PropertyError error)
    {
        _errors.Add(error);
    }
}
