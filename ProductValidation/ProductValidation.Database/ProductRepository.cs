using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Database;

namespace ProductValidation.Database
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
    }
}
