using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ContractBuilder : GenericBuilder<ContractEntity>
    {
        public ContractBuilder()
        {
            _instance =  new ContractEntity()
            {
                Id = new Random().Next(99999),
                Product = new ProductEntity(),
                FieldsContracts = new List<FieldsContractEntity>(),
                Active = true,
                Aproved = false,
                Created = DateTime.Now                
            };            
        }

        public ContractBuilder WithProduct(ProductEntity product)
        {
            _instance.Product = product;
            return this;
        }

        public ContractBuilder WithFieldsContract(List<FieldsContractEntity> fields)
        {
            _instance.FieldsContracts = fields;
            return this;
        }
    }
}
