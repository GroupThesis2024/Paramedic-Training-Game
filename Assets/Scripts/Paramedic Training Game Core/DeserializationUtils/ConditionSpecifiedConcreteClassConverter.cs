using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Backend;

public class ConditionSpecifiedConcreteClassConverter : DefaultContractResolver
{
    protected override JsonConverter ResolveContractConverter(Type objectType)
    {
        if (typeof(Condition).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
        return base.ResolveContractConverter(objectType);
    }
}