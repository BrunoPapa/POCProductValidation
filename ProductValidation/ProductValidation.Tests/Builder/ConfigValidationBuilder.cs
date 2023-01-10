using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ConfigValidationBuilder : GenericBuilder<ConfigValidationEntity>
    {
        public ConfigValidationBuilder()
        {
            _instance =  new ConfigValidationEntity()
            {
                Id = new Random().Next(99999),
                ConfigValidationMessages = new List<ConfigValidationMessageEntity>(),
                ConfigValidationRules = new List<ConfigValidationRuleEntity>()                
            };            
        }

        public ConfigValidationBuilder WithConfigValidationMessages(List<ConfigValidationMessageEntity> configValidationMessages)
        {
            _instance.ConfigValidationMessages = configValidationMessages;
            return this;
        }

        public ConfigValidationBuilder WithConfigValidationRules(List<ConfigValidationRuleEntity> configValidationRules)
        {
            _instance.ConfigValidationRules = configValidationRules;
            return this;
        }
        public ConfigValidationBuilder WithConfigVersionId(int configVersionId)
        {
            _instance.ConfigVersionId = configVersionId;
            return this;
        }

        public ConfigValidationBuilder WithIsExternal(bool isExternal)
        {
            _instance.IsExternal = isExternal;
            return this;
        }
    }
}
