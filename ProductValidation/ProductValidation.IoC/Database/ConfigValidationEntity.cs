using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class ConfigValidationEntity : IEntity
    {
        public int Id { get; set; }
        public int ConfigVersionId { get; set; }
        public bool IsExternal { get; set; }
    }
}
