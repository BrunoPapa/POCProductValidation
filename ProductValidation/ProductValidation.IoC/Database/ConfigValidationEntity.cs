namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ConfigValidation")]
    public partial class ConfigValidationEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConfigValidationEntity()
        {
            ConfigValidationMessages = new HashSet<ConfigValidationMessageEntity>();
            ConfigValidationRules = new HashSet<ConfigValidationRuleEntity>();
        }

        public int Id { get; set; }

        public int ConfigVersionId { get; set; }

        public bool IsExternal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigValidationMessageEntity> ConfigValidationMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigValidationRuleEntity> ConfigValidationRules { get; set; }
    }
}
