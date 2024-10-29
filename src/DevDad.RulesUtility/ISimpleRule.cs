using System;

namespace DevDad.RulesUtility;

public interface ISimpleRule
{
    /// <summary>
    /// Executes the rule defined by the implementation class against the supplied testObject
    /// </summary>
    /// <param name="testObject"></param>
    /// <returns></returns>
    bool Execute(object testObject);

    string SubjectTypeName {get;}
    string PropertyName {get;}
}