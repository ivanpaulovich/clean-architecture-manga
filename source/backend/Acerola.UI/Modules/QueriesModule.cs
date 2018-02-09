namespace Acerola.UI.Modules
{
    using Autofac;
    using Acerola.Application.Queries;
    using Acerola.Infrastructure.Queries;
    
    public class QueriesModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomersQueries>()
                .As<ICustomersQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountsQueries>()
                .As<IAccountsQueries>()
                .InstancePerLifetimeScope();
        }
    }
}
