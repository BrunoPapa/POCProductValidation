﻿using ProductValidation.IoC.Commom;

namespace ProductValidation.Rules
{
    public class ruleDateNotEqValue : ValidationRuleService
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