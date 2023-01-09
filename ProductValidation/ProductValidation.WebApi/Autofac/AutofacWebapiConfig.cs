using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace ProductValidation.WebApi.Autofac
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            Container = builder.Build();
            return Container;
        }
    }
}