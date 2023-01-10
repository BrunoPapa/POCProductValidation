using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ConfigValidationRuleLOVBuilder : GenericBuilder<ConfigValidationRuleLOVEntity>
    {
        public ConfigValidationRuleLOVBuilder()
        {
            _instance =  new ConfigValidationRuleLOVEntity()
            {
                Id = new Random().Next(99999),
                ConfigValidationRule = new ConfigValidationRuleEntity()
            };            
        }

        public ConfigValidationRuleLOVBuilder WithConfigValidationRule(ConfigValidationRuleEntity configValidationRule)
        {
            _instance.ConfigValidationRule = configValidationRule;
            return this;
        }

        public ConfigValidationRuleLOVBuilder WithConfigValidationRuleId(int configValidationRuleId)
        {
            _instance.ConfigValidationRuleId = configValidationRuleId;
            return this;
        }

        public ConfigValidationRuleLOVBuilder WithBaseLOVEntryId(int baseLOVEntryId)
        {
            _instance.BaseLOVEntryId = baseLOVEntryId;
            return this;
        }        
    }
}
