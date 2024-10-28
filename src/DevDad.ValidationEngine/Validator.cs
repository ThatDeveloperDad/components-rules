using System;

namespace DevDad.ValidationEngine;

public class Validator : IValidator
{
    public ValidationResult<T> Validate<T>(T payload, string? activityContext = null)
    {
        throw new NotImplementedException();
    }
}
