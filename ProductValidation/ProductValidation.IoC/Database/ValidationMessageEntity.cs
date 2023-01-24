namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValidationMessage")]
    public partial class ValidationMessageEntity : IEntity
    {
        public int Id { get; set; }

        public int ValidationId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsExternal { get; set; }

        public virtual ValidationEntity Validation { get; set; }
    }
}
