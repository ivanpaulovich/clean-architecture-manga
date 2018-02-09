namespace Acerola.UI.Modules
{
    using Autofac;
    using Acerola.Infrastructure.DataAccess;
    using Acerola.Infrastructure.DataAccess.Repositories.Customers;
    using Acerola.Domain.Customers;
    using Acerola.Domain.Accounts;
    using Acerola.Infrastructure.DataAccess.Repositories.Accounts;
    using Acerola.Application.Accounts.Close;
    using Acerola.UI.UseCases.Accounts.Close;

    public class ApplicationModule : Module
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

            builder.RegisterType<Interactor>()
                .As<IInputBoundary>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Presenter>()
                .As<IOutputBoundary>()
                .As<Presenter>()
                .InstancePerLifetimeScope();
        }
    }
}
