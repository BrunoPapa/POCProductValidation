using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleNumberGreaterValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value.ToInt() > _compareValue.ToInt())
                return true;
            else
                return false;
        }
    }
}
