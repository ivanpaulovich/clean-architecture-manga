namespace UnitTests.UseCaseTests
{
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Infrastructure.CurrencyExchange;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Infrastructure.ExternalAuthentication;

    /// <summary>
    /// </summary>
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            this.Context = new MangaContextFake();
            this.AccountRepositoryFake = new AccountRepositoryFake(this.Context);
            this.CustomerRepositoryFake = new CustomerRepositoryFake(this.Context);
            this.UserRepositoryFake = new UserRepositoryFake(this.Context);
            this.UnitOfWork = new UnitOfWorkFake();
            this.EntityFactory = new EntityFactory();
            this.TestUserService = new TestUserService(this.EntityFactory);
            this.CustomerService = new CustomerService(this.EntityFactory, this.CustomerRepositoryFake);
            this.SecurityService = new SecurityService(this.UserRepositoryFake);
            this.AccountService = new AccountService(this.EntityFactory, this.AccountRepositoryFake);
            this.CurrencyExchange = new CurrencyExchangeServiceFake();
        }

        public EntityFactory EntityFactory { get; }

        public MangaContextFake Context { get; }

        public AccountRepositoryFake AccountRepositoryFake { get; }

        public CustomerRepositoryFake CustomerRepositoryFake { get; }

        public UserRepositoryFake UserRepositoryFake { get; }

        public UnitOfWorkFake UnitOfWork { get; }

        public TestUserService TestUserService { get; }

        public CustomerService CustomerService { get; }

        public SecurityService SecurityService { get; }

        public AccountService AccountService { get; }

        public CurrencyExchangeServiceFake CurrencyExchange { get; }
    }
}
