using ProductValidation.IoC.Database;
using ProductValidation.IoC.Enumerators;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class FieldBuilder : GenericBuilder<FieldEntity>
    {
        public FieldBuilder()
        {
            _instance = new FieldEntity()
            {
                Id = new Random().Next(99999),
                Created = DateTime.Now,
                Active = true                
            };
        }

        public FieldBuilder WithCode(string code)
        {
            _instance.Code = code;
            return this;
        }

        public FieldBuilder WithName(string name)
        {
            _instance.Name = name;
            return this;
        }

        public FieldBuilder WithType(FieldType type)
        {
            _instance.Type = (short)type;
            return this;
        }
    }
}
