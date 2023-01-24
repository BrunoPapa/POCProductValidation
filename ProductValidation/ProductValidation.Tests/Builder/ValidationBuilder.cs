using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ValidationBuilder : GenericBuilder<ValidationEntity>
    {
        public ValidationBuilder()
        {
            _instance =  new ValidationEntity()
            {
                Id = new Random().Next(99999),
                ValidationMessage = new List<ValidationMessageEntity>(),
                ValidationRule = new List<ValidationRuleEntity>()
            };            
        }

        public ValidationBuilder WithValidationMessage(List<ValidationMessageEntity> validationMessage)
        {
            _instance.ValidationMessage = validationMessage;
            return this;
        }

        public ValidationBuilder WithValidationRule(List<ValidationRuleEntity> validationRule)
        {
            _instance.ValidationRule = validationRule;
            return this;
        }

        public ValidationBuilder WithSeverity(int severity)
        {
            _instance.SeverityId = severity;
            return this;
        }
    }
}
