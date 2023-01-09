using Autofac;
using ProductValidation.IoC.Interface.Service;

namespace ProductValidation.WebApi.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseValidationService>().As<IBaseValidationService>();
            builder.RegisterType<ValidationService>().As<IValidationService>();
        }
    }
}