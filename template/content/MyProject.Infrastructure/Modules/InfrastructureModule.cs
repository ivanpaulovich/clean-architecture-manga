namespace MyProject.Infrastructure.Modules
{
    using Autofac;
#if Mongo
    using MyProject.Infrastructure.MongoDataAccess;
#endif
    using MyProject.Infrastructure.Mappings;
#if (EntityFramework)
    using MyProject.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
#endif

    public class InfrastructureModule : Autofac.Module
    {
#if (Mongo)
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
#endif
#if (Dapper)
        public string DapperConnectionString { get; set; }
#endif
#if (EntityFramework)
        public string SQLServerConnectionString { get; set; }
#endif

        protected override void Load(ContainerBuilder builder)
        {
#if (Mongo)
            builder.RegisterType<Context>()
                .As<Context>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
#endif
#if (EntityFramework)
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseSqlServer(SQLServerConnectionString);
                optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<Context>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerLifetimeScope();
#endif

            //
            // Register all Types in MyProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
#if (Dapper)
                .WithParameter("connectionString", DapperConnectionString)
#endif
                .InstancePerLifetimeScope();
        }
    }
}
