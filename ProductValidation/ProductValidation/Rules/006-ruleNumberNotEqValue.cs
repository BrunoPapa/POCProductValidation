﻿using ProductValidation.IoC.Commom;

namespace ProductValidation.Rules
{
    public class ruleNumberNotEqValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value.ToInt() != _compareValue.ToInt())
                return true;
            else
                return false;
        }
    }
}
