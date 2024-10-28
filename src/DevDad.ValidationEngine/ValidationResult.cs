using System;

namespace DevDad.ValidationEngine;

public class ValidationResult<T>
{
    private List<PropertyError> _errors = new();

    public ValidationResult(T payload, string errorMessage)
    {
        Payload = payload;
    }

    public T Payload { get; }
    public bool IsValid => _errors.Count == 0;
    public IReadOnlyCollection<PropertyError> Errors => Errors;
}
