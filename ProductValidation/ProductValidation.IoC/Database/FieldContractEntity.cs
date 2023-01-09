using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class FieldContractEntity : IEntity
    {
        public int Id { get; set; }
        public FieldEntity Field { get; set; }
        public string Value { get; set; }
    }
}
