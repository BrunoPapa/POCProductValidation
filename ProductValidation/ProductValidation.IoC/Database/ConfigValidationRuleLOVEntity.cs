using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class ConfigValidationRuleLOVEntity : IEntity
    {
        public int Id { get; set; }
        public ConfigValidationRuleEntity ConfigValidationRule { get; set; }
        public int BaseLOVEntryId { get; set; }
    }
}