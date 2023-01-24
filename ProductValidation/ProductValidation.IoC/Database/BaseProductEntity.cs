namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseProduct")]
    public partial class BaseProductEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseProductEntity()
        {
            Validation = new HashSet<ValidationEntity>();
        }

        public int Id { get; set; }

        public int? ProductExtRef { get; set; }

        public int? ProductVersion { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ProductCoreId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidationEntity> Validation { get; set; }
    }
}
