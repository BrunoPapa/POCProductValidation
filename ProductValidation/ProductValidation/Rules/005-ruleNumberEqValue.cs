using ProductValidation.IoC.Commom;

namespace ProductValidation.Rules
{
    public class ruleNumberEqValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value == _compareValue)
                return true;
            else
                return false;
        }
    }
}
