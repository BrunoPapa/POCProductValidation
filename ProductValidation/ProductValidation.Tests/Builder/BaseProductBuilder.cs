using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class BaseProductBuilder : GenericBuilder<BaseProductEntity>
    {
        public BaseProductBuilder()
        {
            _instance =  new BaseProductEntity()
            {
                Id = new Random().Next(99999),
            };            
        }

        public BaseProductBuilder WithProductCoreId(int productCoreId)
        {
            _instance.ProductCoreId = productCoreId;
            return this;
        }

        public BaseProductBuilder WithValidation(List<ValidationEntity> validation)
        {
            _instance.Validation = validation;
            return this;
        }

        public BaseProductBuilder WithProductVersion(int productVersion)
        {
            _instance.ProductVersion = productVersion;
            return this;
        }

        public BaseProductBuilder WithProductExtRef(int productExtRef)
        {
            _instance.ProductExtRef = productExtRef;
            return this;
        }
    }
}
