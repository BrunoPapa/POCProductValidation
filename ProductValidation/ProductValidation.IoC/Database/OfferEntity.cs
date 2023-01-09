using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class OfferEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FieldEntity> Fields { get; set; }
    }
}