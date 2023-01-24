using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ValidationRuleLOVBuilder : GenericBuilder<ValidationRuleLOVEntity>
    {
        public ValidationRuleLOVBuilder()
        {
            _instance =  new ValidationRuleLOVEntity()
            {
                Id = new Random().Next(99999),
                ValidationRule = new ValidationRuleEntity()
            };            
        }

        public ValidationRuleLOVBuilder WithValidationRule(ValidationRuleEntity validationRule)
        {
            _instance.ValidationRule = validationRule;
            return this;
        }

        public ValidationRuleLOVBuilder WithConfigValidationRuleId(int configValidationRuleId)
        {
            _instance.ValidationRuleId = configValidationRuleId;
            return this;
        }

        public ValidationRuleLOVBuilder WithBaseLOVEntryId(int baseLOVEntryId)
        {
            _instance.BaseLOVEntryId = baseLOVEntryId;
            return this;
        }        
    }
}
