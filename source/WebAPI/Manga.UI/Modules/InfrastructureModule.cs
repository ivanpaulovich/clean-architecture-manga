namespace Manga.UI.Modules
{
    using Autofac;
#if Mongo
    using Manga.Infrastructure.DataAccess.Mongo;
#endif
    using Manga.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
#if Mongo
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
#endif

            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //
            // Entity Framework
            //
            //var optionsBuilder = new DbContextOptionsBuilder<AccountBalanceContext>();
            //optionsBuilder.UseSqlServer(ConnectionString);

            //builder.RegisterType<AccountBalanceContext>()
            //  .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
            //  .InstancePerLifetimeScope();

            //
            // Register all Types in Manga.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
