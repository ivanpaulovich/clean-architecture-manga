namespace Manga.Infrastructure.Modules
{
    using Autofac;
    using Manga.Infrastructure.InMemoryDataAccess;

    public class InMemoryDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<Context>()
                .SingleInstance();

            //
            // Register all Types in InMemoryDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("InMemoryDataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
