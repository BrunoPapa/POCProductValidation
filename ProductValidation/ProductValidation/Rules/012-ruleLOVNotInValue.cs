using ProductValidation.IoC.Commom;
using System.Linq;

namespace ProductValidation.Rules
{
    public class ruleLOVNotInValue : ValidationRuleService
    {
        protected override bool RuleValidation()
        {
            if (_rule.ConfigValidationRuleLOVs.Where(p => p.BaseLOVEntryId.ToString() == _selectedField.value).Count() == 0)
                return true;
            else
                return false;
        }
    }
}
