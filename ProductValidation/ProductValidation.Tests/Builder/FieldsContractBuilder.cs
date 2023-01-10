using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class FieldsContractBuilder : GenericBuilder<FieldsContractEntity>
    {
        public FieldsContractBuilder()
        {
            _instance = new FieldsContractEntity()
            {
                Id = new Random().Next(99999),
                Contract = new ContractEntity(),
                FieldsProduct = new FieldsProductEntity()                
            };
        }

        public FieldsContractBuilder WithContract(ContractEntity contract)
        {
            _instance.Contract = contract;
            return this;
        }

        public FieldsContractBuilder WithFieldProduct(FieldsProductEntity field)
        {
            _instance.FieldsProduct = field;
            return this;
        }

        public FieldsContractBuilder WithValue(string value)
        {
            _instance.Value = value;
            return this;
        }
    }
}
