namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ConfigValidationRuleLOV")]
    public partial class ConfigValidationRuleLOVEntity : IEntity
    {
        public int Id { get; set; }

        public int ConfigValidationRuleId { get; set; }

        public int BaseLOVEntryId { get; set; }

        public virtual ConfigValidationRuleEntity ConfigValidationRule { get; set; }
    }
}
