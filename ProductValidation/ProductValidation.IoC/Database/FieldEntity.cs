using ProductValidation.IoC.Enumerators;
using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{ 
    public class FieldEntity : IEntity
    {
        public int Id { get; set; }
        public FieldType Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
