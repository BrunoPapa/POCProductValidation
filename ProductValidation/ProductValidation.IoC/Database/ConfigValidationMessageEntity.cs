namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ConfigValidationMessage")]
    public partial class ConfigValidationMessageEntity : IEntity
    {
        public int Id { get; set; }

        public int ConfigValidationId { get; set; }

        public int BaseValidationId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsExternal { get; set; }

        public virtual BaseValidationEntity BaseValidation { get; set; }

        public virtual ConfigValidationEntity ConfigValidation { get; set; }
    }
}
