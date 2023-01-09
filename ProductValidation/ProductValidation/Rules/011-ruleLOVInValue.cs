using ProductValidation.IoC.Commom;
using System.Linq;

namespace ProductValidation.Rules
{
    public class ruleLOVInValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_rule.ConfigValidationRuleLOVs.Where(p => p.BaseLOVEntryId.ToString() == _selectedField.Value).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
