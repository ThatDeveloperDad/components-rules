namespace DevDad.ValidationEngine;

public interface IValidator
{
    /// <summary>
    /// Validates the payload using the rules defined in the validator and returns an object containing the original Subject instance
    /// and a collection of errors.
    /// </summary>
    /// <typeparam name="T">The Type of the Subject object to be validated</typeparam>
    /// <param name="payload">The instance of the Subject Type to be validated</param>
    /// <param name="activityContext">[Optional] the name of the Activity for which the Subject is being validated.  Omit this to run all validation rules against the subject.</param>
    /// <returns></returns>
    ValidationResult<T> Validate<T>(T payload, string? activityContext = null);
}
