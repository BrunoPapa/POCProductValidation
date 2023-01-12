using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Enumerators;
using System;

namespace ProductValidation.Tests.Builder
{
    public class FieldBuilder : GenericBuilder<Field>
    {
        public FieldBuilder()
        {
            _instance = new Field()
            {
                metadata = new Metadata()
            };
        }

        public FieldBuilder WithKey(string key)
        {
            _instance.key = key;
            return this;
        }

        public FieldBuilder WithValue(string value)
        {
            _instance.value = value;
            return this;
        }

        public FieldBuilder WithMetaData(Metadata metadata)
        {
            _instance.metadata = metadata;
            return this;
        }
    }
}
