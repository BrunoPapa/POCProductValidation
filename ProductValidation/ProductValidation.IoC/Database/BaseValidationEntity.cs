using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class BaseValidationEntity : IEntity
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(BaseProduct))]
        public int BaseProductId { get; set; }

        public ProductEntity BaseProduct { get; set; }
        public bool IsExternal { get; set; }
        public IEnumerable<ConfigValidationRuleEntity> ConfigValidationRules { get; set; }
        public IEnumerable<ConfigValidationMessageEntity> ConfigValidationMessages { get; set; }
    }
}
