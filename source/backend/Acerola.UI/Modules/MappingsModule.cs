namespace Acerola.UI.Modules
{
    using Autofac;
    using Acerola.Application;
    using Acerola.Infrastructure.Mappings;

    public class MappingsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ResponseConverter>()
               .As<IResponseConverter>()
               .InstancePerLifetimeScope();
        }
    }
}