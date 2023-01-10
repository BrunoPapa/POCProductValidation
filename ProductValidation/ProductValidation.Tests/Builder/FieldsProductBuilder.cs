using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class FieldsProductBuilder : GenericBuilder<FieldsProductEntity>
    {
        public FieldsProductBuilder()
        {
            _instance = new FieldsProductEntity()
            {
                Id = new Random().Next(99999),
                Field = new FieldEntity(),
                FieldsContracts = new List<FieldsContractEntity>(),
                Product = new ProductEntity(),
                Created = DateTime.Now,
                Active = true                
            };
        }

        public FieldsProductBuilder WithField(FieldEntity field)
        {
            _instance.Field = field;
            return this;
        }

        public FieldsProductBuilder WithFieldsContract(List<FieldsContractEntity> fieldsContract)
        {
            _instance.FieldsContracts = fieldsContract;
            return this;
        }

        public FieldsProductBuilder WithProduct(ProductEntity product)
        {
            _instance.Product = product;
            return this;
        }        
    }
}
