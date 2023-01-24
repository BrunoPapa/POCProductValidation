namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValidationRule")]
    public partial class ValidationRuleEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ValidationRuleEntity()
        {
            ValidationRuleLOV = new HashSet<ValidationRuleLOVEntity>();
        }

        public int Id { get; set; }

        public int ValidationId { get; set; }

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
        public int RightChoiceId { get; set; }
        public int RightFieldId { get; set; }

        public int? BaseLoveEntryId { get; set; }

        public virtual OperatorEntity Operator { get; set; }

        public virtual ValidationEntity Validation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidationRuleLOVEntity> ValidationRuleLOV { get; set; }
    }
}
