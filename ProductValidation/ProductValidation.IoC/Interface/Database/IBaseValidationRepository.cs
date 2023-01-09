using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductValidation.IoC.Interface.Database
{
    public interface IBaseValidationRepository : IGenericRepository<BaseValidationEntity>
    {
        Task<IEnumerable<BaseValidationEntity>> GetByProduct(int ProductId);
    }
}
