using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class ConfigValidationMessageEntity : IEntity
    {
        public int Id { get; set; }
        public ConfigValidationEntity ConfigVersion { get; set; }
        public BaseValidationEntity BaseValidation { get; set; }
        public int LanguageId { get; set; }
        public string Message { get; set; }
        public bool IsExternal { get; set; }
    }
}
