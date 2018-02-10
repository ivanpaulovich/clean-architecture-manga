namespace Acerola.UI.Modules
{
    using Autofac;
    using Acerola.Infrastructure.DataAccess;
    using Acerola.Infrastructure.DataAccess.Repositories.Customers;
    using Acerola.Domain.Customers;
    using Acerola.Domain.Accounts;
    using Acerola.Infrastructure.DataAccess.Repositories.Accounts;
    using Acerola.Application;
    using System.Reflection;
    using Acerola.Application.Customers.Register;
    using Acerola.UI.UseCases.Customers.Register;

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

            builder.RegisterAssemblyTypes(typeof(Application.Customers.Register.Interactor).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UseCases.Customers.Register.Presenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();


            //builder.RegisterType<Interactor>()
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<Presenter>()
            //    .As<IOutputBoundary<Response>>()
            //    .As<Presenter>()
            //    .InstancePerLifetimeScope();
        }
    }
}
