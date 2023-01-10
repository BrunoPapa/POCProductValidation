using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class BaseValidationBuilder : GenericBuilder<BaseValidationEntity>
    {
        public BaseValidationBuilder()
        {
            _instance =  new BaseValidationEntity()
            {
                Id = new Random().Next(99999),
                Product = new ProductEntity(),
                ConfigValidationMessages = new List<ConfigValidationMessageEntity>(),
                ConfigValidationRules = new List<ConfigValidationRuleEntity>(),
                IsExternal = false
            };            
        }

        public BaseValidationBuilder WithConfigValidationMessages(List<ConfigValidationMessageEntity> configValidationMessages)
        {
            _instance.ConfigValidationMessages = configValidationMessages;
            return this;
        }

        public BaseValidationBuilder WithFieldsContract(List<ConfigValidationRuleEntity> configValidationRules)
        {
            _instance.ConfigValidationRules = configValidationRules;
            return this;
        }

        public BaseValidationBuilder WithIsExternal(bool isExternal)
        {
            _instance.IsExternal = isExternal;
            return this;
        }
    }
}
