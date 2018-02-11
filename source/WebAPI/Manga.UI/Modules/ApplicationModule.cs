namespace Manga.UI.Modules
{
    using Autofac;
    using Manga.Infrastructure.DataAccess;
    using Manga.Infrastructure.DataAccess.Repositories.Customers;
    using Manga.Domain.Customers;
    using Manga.Domain.Accounts;
    using Manga.Infrastructure.DataAccess.Repositories.Accounts;
    using Manga.Application;
    using Manga.UI.Presenters;

    public class ApplicationModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerReadOnlyRepository>()
                .As<ICustomerReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerWriteOnlyRepository>()
                .As<ICustomerWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountReadOnlyRepository>()
                .As<IAccountReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountWriteOnlyRepository>()
                .As<IAccountWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Application.UseCases.Register.Interactor).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}
