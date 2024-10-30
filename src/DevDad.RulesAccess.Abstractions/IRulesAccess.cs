namespace DevDad.RulesAccess.Abstractions;

public interface IRulesAccess
{
    IEnumerable<T> LoadRules<T>(string? subjectTypeName);
}
