namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Operator")]
    public partial class OperatorEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperatorEntity()
        {
            ConfigValidationRules = new HashSet<ConfigValidationRuleEntity>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        public bool Is_Active { get; set; }

        public bool IsFieldLOV { get; set; }

        public bool IsField_Integer { get; set; }

        public bool IsField_Decimal { get; set; }

        public bool IsField_Text { get; set; }

        public bool IsField_Date { get; set; }

        public bool IsRisk { get; set; }

        public bool IsFieldRiskLOV { get; set; }

        public bool IsFieldRisk { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsExternal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfigValidationRuleEntity> ConfigValidationRules { get; set; }
    }
}
