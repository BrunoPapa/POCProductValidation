using ProductValidation.IoC.Commom;

namespace ProductValidation.Rules
{
    public class ruleFieldIsNotNull : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_value != null)
                return false;
            else
                return true;
        }
    }
}
