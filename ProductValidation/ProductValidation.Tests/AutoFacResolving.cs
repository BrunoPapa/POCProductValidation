using Autofac;
using ProductValidation.Database;
using System;
using Xunit;

namespace ProductValidation.Tests
{
    public class AutoFacResolving : IDisposable
    {
        protected ILifetimeScope Scope { get; set; }

        public AutoFacResolving()
        {
            var Builder = new ContainerBuilder();
            Builder.RegisterModule<AutoFacModule>();
            var container = Builder.Build();
            Scope = container.BeginLifetimeScope("httpRequest");
        }

        public void Dispose()
        {
            // Cleanup the scope at the end of the test run.
            Scope.Dispose();
        }        
    }
}
