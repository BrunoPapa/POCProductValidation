using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductValidation.IoC.Interface.Database
{
    public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
