using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleNumberLesserValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (Convert.ToInt32(_value) < Convert.ToInt32(_compareValue))
                return false;
            else
                return true;
        }
    }
}
