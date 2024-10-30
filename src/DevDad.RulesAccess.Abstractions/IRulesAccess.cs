namespace DevDad.RulesAccess.Abstractions;

public interface IRulesAccess
{
    IEnumerable<T> LoadRules<T>(string? subjectTypeName) where T: IRuleResource
    {
        string[] typeNames = 
            subjectTypeName == null 
            ? throw new ArgumentException("Must provide at least one subjectTypeName", nameof(subjectTypeName)) 
            : new string[] { subjectTypeName };

            return LoadRules<T>(typeNames);
    }

    IEnumerable<T> LoadRules<T>(IEnumerable<string> subjectTypeNames) where T: IRuleResource;
}
