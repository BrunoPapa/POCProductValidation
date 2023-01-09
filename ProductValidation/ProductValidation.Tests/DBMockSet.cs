using ProductValidation.IoC.Interface.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductValidation.Tests
{    
    public class DBMockSet<T> : IGenericRepository<T> where T : class, IEntity
    {
        private HashSet<T> _data;

        public DBMockSet()
        {
            _data = new HashSet<T>();
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public void Detach(T item)
        {
            
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return _data.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<T> Create(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _data.Remove(entity);            
        }
    }
}
