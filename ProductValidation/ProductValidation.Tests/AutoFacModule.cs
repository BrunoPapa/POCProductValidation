using Autofac;
using ProductValidation.Database;
using ProductValidation.IoC.Interface.Database;
using ProductValidation.IoC.Interface.Service;

namespace ProductValidation.Tests
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseValidationService>().As<IBaseValidationService>();
            builder.RegisterType<ValidationService>().As<IValidationService>();

            builder.RegisterType<BaseValidationRepository>().As<IBaseValidationRepository>();            
        }
    }
}
