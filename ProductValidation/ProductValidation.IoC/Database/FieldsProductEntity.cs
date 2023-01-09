namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FieldsProduct")]
    public partial class FieldsProductEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FieldsProductEntity()
        {
            FieldsContracts = new HashSet<FieldsContractEntity>();
        }

        public int Id { get; set; }

        public int FieldId { get; set; }

        public int ProductId { get; set; }

        public bool IsEditable { get; set; }

        public bool IsVisible { get; set; }

        [StringLength(200)]
        public string DefaultValue { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public virtual FieldEntity Field { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FieldsContractEntity> FieldsContracts { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
