using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ConfigVersionBuilder : GenericBuilder<ConfigVersionEntity>
    {
        public ConfigVersionBuilder()
        {
            _instance =  new ConfigVersionEntity()
            {
                Id = new Random().Next(99999),  
            };            
        }

        public ConfigVersionBuilder WithConfigValidationMessages(int configurationVersion)
        {
            _instance.ConfigurationVersion = configurationVersion;
            return this;
        }

        public ConfigVersionBuilder WithConfigValidationRules(List<ValidationEntity> validation)
        {
            _instance.Validation = validation;
            return this;
        }
    }
}
