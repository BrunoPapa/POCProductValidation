using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductValidation.Database
{
    public class BaseValidationRepository : GenericRepository<BaseValidationEntity>, IBaseValidationRepository
    {
        public async Task<IEnumerable<BaseValidationEntity>> GetByProduct(int ProductId)
        {
            using (Context context = new Context())
            {
                var query = context.BaseValidation
                    .Where(p => p.BaseProductId == ProductId)
                    .Include(p => p.ConfigValidationRules)
                    .Include(p => p.ConfigValidationMessages);

                return query.ToList();
            }
        }
    }
}
