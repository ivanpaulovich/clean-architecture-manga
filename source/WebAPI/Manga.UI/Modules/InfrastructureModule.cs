namespace Manga.UI.Modules
{
    using Autofac;
    using Manga.Infrastructure.Mappings;
    using Manga.Infrastructure.Mongo;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

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
