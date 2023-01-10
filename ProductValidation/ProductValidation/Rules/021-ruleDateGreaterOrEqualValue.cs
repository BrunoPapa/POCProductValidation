using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleDateGreaterOrEqualValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (Convert.ToDateTime(_value) >= Convert.ToDateTime(_compareValue))
                return true;
            else
                return false;
        }
    }
}
