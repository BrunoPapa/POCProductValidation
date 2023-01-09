namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contract")]
    public partial class ContractEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractEntity()
        {
            FieldsContracts = new HashSet<FieldsContractEntity>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public bool Aproved { get; set; }

        public string ErrorValidation { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public virtual ProductEntity Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FieldsContractEntity> FieldsContracts { get; set; }
    }
}
