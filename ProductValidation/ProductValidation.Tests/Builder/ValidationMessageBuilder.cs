using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ValidationMessageBuilder : GenericBuilder<ValidationMessageEntity>
    {
        public ValidationMessageBuilder()
        {
            _instance =  new ValidationMessageEntity()
            {
                Id = new Random().Next(99999),
                Validation = new ValidationEntity()        
            };            
        }

        public ValidationMessageBuilder WithValidation(ValidationEntity validation)
        {
            _instance.Validation = validation;
            return this;
        }

        public ValidationMessageBuilder WithMessage(string message)
        {
            _instance.Message = message;
            return this;
        }

        public ValidationMessageBuilder WithLanguageId(int languageId)
        {
            _instance.LanguageId = languageId;
            return this;
        }

        public ValidationMessageBuilder WithIsExternal(bool isExternal)
        {
            _instance.IsExternal = isExternal;
            return this;
        }
    }
}
