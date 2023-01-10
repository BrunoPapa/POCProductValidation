using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ConfigValidationMessageBuilder : GenericBuilder<ConfigValidationMessageEntity>
    {
        public ConfigValidationMessageBuilder()
        {
            _instance =  new ConfigValidationMessageEntity()
            {
                Id = new Random().Next(99999),
                BaseValidation = new BaseValidationEntity(),
                ConfigValidation = new ConfigValidationEntity()                
            };            
        }

        public ConfigValidationMessageBuilder WithBaseValidation(BaseValidationEntity baseValidation)
        {
            _instance.BaseValidation = baseValidation;
            return this;
        }

        public ConfigValidationMessageBuilder WithConfigValidation(ConfigValidationEntity configValidation)
        {
            _instance.ConfigValidation = configValidation;
            return this;
        }

        public ConfigValidationMessageBuilder WithMessage(string message)
        {
            _instance.Message = message;
            return this;
        }

        public ConfigValidationMessageBuilder WithLanguageId(int languageId)
        {
            _instance.LanguageId = languageId;
            return this;
        }

        public ConfigValidationMessageBuilder WithIsExternal(bool isExternal)
        {
            _instance.IsExternal = isExternal;
            return this;
        }
    }
}
