﻿using ProductValidation.IoC.Commom;

namespace ProductValidation.Rules
{
    public class ruleTextEqValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value == _compareValue)
                return false;
            else
                return true;
        }
    }
}
