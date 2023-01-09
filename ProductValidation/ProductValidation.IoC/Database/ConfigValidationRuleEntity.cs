namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    [Table("ConfigValidationRule")]
    public partial class ConfigValidationRuleEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConfigValidationRuleEntity()
        {
            ConfigValidationRuleLOVs = new HashSet<ConfigValidationRuleLOVEntity>();
        }

        public int Id { get; set; }

        public int ConfigValidationId { get; set; }

        public int BaseValidationId { get; set; }

        [Required]
        [StringLength(100)]
        public string RuleDescription { get; set; }

        public bool IsFieldChoice { get; set; }

        public int RuleTypeId { get; set; }

        public int LeftFieldId { get; set; }

        public int LeftRiskFieldId { get; set; }

        public int OperatorId { get; set; }

        [StringLength(100)]
        public string ValueText { get; set; }

        public DateTime? ValueDate { get; set; }

        public long? ValueMin { get; set; }

        public long? ValueMax { get; set; }

        [StringLength(100)]
        public string ValueSelect { get; set; }

        public bool ValueNull { get; set; }

        public int? BaseLoveEntryId { get; set; }

        public int Severity { get; set; }

        public virtual BaseValidationEntity BaseValidation { get; set; }

        public virtual ConfigValidationEntity ConfigValidation { get; set; }

        public virtual OperatorEntity Operator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigValidationRuleLOVEntity> ConfigValidationRuleLOVs { get; set; }
    }
}
