using Autofac;
using ProductValidation.Database;
using ProductValidation.IoC.Interface.Database;

namespace ProductValidation.WebApi.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseValidationRepository>().As<IBaseValidationRepository>();            
        }
    }
}