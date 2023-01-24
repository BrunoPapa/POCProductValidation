namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigVersion")]
    public partial class ConfigVersionEntity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConfigVersionEntity()
        {
            Validation = new HashSet<ValidationEntity>();
        }

        public int Id { get; set; }

        public int ChannelId { get; set; }

        public int BrandId { get; set; }

        [StringLength(200)]
        public string OfferName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ConfigurationVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidationEntity> Validation { get; set; }
    }
}
