using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleNumberBetweenMaxandMin : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (Convert.ToDecimal(_value) >= _rule.ValueMin && Convert.ToDecimal(_value) <= _rule.ValueMax)
                return true;
            else
                return false;
        }
    }
}
