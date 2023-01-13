using ProductValidation.IoC.Commom;
using System;

namespace ProductValidation.Rules
{
    public class ruleDateLesserOrEqualValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value.ToDateTime() <= _compareValue.ToDateTime())
                return true;
            else
                return false;
        }
    }
}
