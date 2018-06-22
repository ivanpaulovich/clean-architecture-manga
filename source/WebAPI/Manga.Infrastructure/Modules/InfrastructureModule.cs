namespace Manga.Infrastructure.Modules
{
    using Autofac;
    using Manga.Infrastructure.MongoDataAccess;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<Context>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            //
            // Register all Types in Manga.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
