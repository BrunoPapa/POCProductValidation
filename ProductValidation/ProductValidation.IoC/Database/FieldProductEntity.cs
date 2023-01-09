using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class FieldProductEntity : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Field))]
        public int FieldId { get; set; }
        public FieldEntity Field { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; }
        public string DefaultValue { get; set; }
    }
}
