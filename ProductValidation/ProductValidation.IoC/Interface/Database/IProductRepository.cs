using ProductValidation.IoC.Database;

namespace ProductValidation.IoC.Interface.Database
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
    }
}
