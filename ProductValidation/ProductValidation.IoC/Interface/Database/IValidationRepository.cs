using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductValidation.IoC.Interface.Database
{
    public interface IValidationRepository : IGenericRepository<ValidationEntity>
    {
        Task<IEnumerable<ValidationEntity>> GetByProduct(int ProductCoreId);
        Task<IEnumerable<ValidationEntity>> GetByConfigVersion(int ConfigVersionId);
        Task<IEnumerable<ValidationEntity>> GetAll(int ProductCoreId, int ConfigVersionId);
    }
}
