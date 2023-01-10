using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductValidation.Tests.Builder
{
    public abstract class GenericBuilder<T> : IDisposable
    {
        protected T _instance;
        
        public void Dispose()
        {            
        }

        public T Instance() => _instance;
    }
}
