namespace Manga.Infrastructure.Modules
{
    using Autofac;
    using Manga.Application;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Manga.Application
            //
            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
