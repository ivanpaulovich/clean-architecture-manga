namespace UnitTests.UseCaseTests
{
    using Application.Services;
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
            this.TestUserService = new TestUserService();
            this.CurrencyExchangeFake = new CurrencyExchangeFake();
        }

        public EntityFactory EntityFactory { get; }

        public MangaContextFake Context { get; }

        public AccountRepositoryFake AccountRepositoryFake { get; }

        public CustomerRepositoryFake CustomerRepositoryFake { get; }

        public UserRepositoryFake UserRepositoryFake { get; }

        public UnitOfWorkFake UnitOfWork { get; }

        public TestUserService TestUserService { get; }

        public CurrencyExchangeFake CurrencyExchangeFake { get; }
    }
}
