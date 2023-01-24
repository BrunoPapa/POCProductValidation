using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductValidation.Database
{
    public class ValidationRepository : GenericRepository<ValidationEntity>, IValidationRepository
    {
        public async Task<IEnumerable<ValidationEntity>> GetByProduct(int ProductCoreId)
        {
            using (Context context = new Context())
            {
                var query = context.Validation
                    .Where(p => p.BaseProduct.ProductCoreId == ProductCoreId)
                    .Include(p => p.ValidationRule.Select(o => o.Operator))
                    .Include(p => p.ValidationRule.Select(o => o.ValidationRuleLOV))
                    .Include(p => p.ValidationMessage);

                return query.ToList();
            }
        }

        public async Task<IEnumerable<ValidationEntity>> GetByConfigVersion(int ConfigVersionId)
        {
            using (Context context = new Context())
            {
                var query = context.Validation
                    .Where(p => p.ConfigVersion.ConfigurationVersion == ConfigVersionId)
                    .Include(p => p.ValidationRule.Select(o => o.Operator))
                    .Include(p => p.ValidationRule.Select(o => o.ValidationRuleLOV))
                    .Include(p => p.ValidationMessage);

                return query.ToList();
            }
        }

        public async Task<IEnumerable<ValidationEntity>> GetAll(int ProductCoreId, int ConfigVersionId)
        {
            using (Context context = new Context())
            {
                var query = context.Validation
                    .Where(p => p.BaseProduct.ProductCoreId == ProductCoreId || p.ConfigVersion.ConfigurationVersion == ConfigVersionId)
                    .Include(p => p.ValidationRule.Select(o => o.Operator))
                    .Include(p => p.ValidationRule.Select(o => o.ValidationRuleLOV))
                    .Include(p => p.ValidationMessage);

                return query.ToList();
            }
        }
    }
}
