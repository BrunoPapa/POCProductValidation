namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Validation")]
    public partial class ValidationEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ValidationEntity()
        {
            ValidationMessage = new HashSet<ValidationMessageEntity>();
            ValidationRule = new HashSet<ValidationRuleEntity>();
        }

        public int Id { get; set; }

        public int? BaseProductId { get; set; }

        public int? ConfigVersionId { get; set; }

        public int SeverityId { get; set; }

        public virtual BaseProductEntity BaseProduct { get; set; }

        public virtual ConfigVersionEntity ConfigVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidationMessageEntity> ValidationMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidationRuleEntity> ValidationRule { get; set; }
    }
}
