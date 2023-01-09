using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class ContractEntity : IEntity
    {
        public int Id { get; set; }
        public ProductEntity Product { get; set; }
        public IEnumerable<FieldContractEntity> Fields { get; set; }
        public bool Approved { get; set; }
        public string ErrorValidation { get; set; }
    }
}
