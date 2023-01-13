using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleNumberNotBetweenMaxandMin : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value.ToInt() < _rule.ValueMin || _value.ToInt() > _rule.ValueMax)
                return true;
            else
                return false;
        }
    }
}
