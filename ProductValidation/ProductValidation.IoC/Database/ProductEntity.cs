using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{ 
    public class ProductEntity : IEntity
    {
        public int Id { get; set; }
        public OfferEntity Offer { get; set; }
        public string Name { get; set; }        
        public IEnumerable<FieldProductEntity> Fields { get; set; }                
    }
}
