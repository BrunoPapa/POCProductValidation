namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValidationRuleLOV")]
    public partial class ValidationRuleLOVEntity : IEntity
    {
        public int Id { get; set; }

        public int ValidationRuleId { get; set; }

        public int BaseLOVEntryId { get; set; }

        public virtual ValidationRuleEntity ValidationRule { get; set; }
    }
}
