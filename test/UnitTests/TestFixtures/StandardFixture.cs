namespace UnitTests.TestFixtures
{
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Infrastructure.InMemoryDataAccess;
    using Infrastructure.InMemoryDataAccess.Repositories;
    using Infrastructure.InMemoryDataAccess.Services;

    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            Context = new MangaContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UserRepository = new UserRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
            UserService = new UserService();
            CustomerService = new CustomerService(EntityFactory, CustomerRepository);
            SecurityService = new SecurityService(EntityFactory, UserRepository);
            AccountService = new AccountService(EntityFactory, AccountRepository);
        }

        public EntityFactory EntityFactory { get; }

        public MangaContext Context { get; }

        public AccountRepository AccountRepository { get; }

        public CustomerRepository CustomerRepository { get; }

        public UserRepository UserRepository { get; }

        public UnitOfWork UnitOfWork { get; }

        public UserService UserService { get; }

        public CustomerService CustomerService { get; }

        public SecurityService SecurityService { get; }

        public AccountService AccountService { get; }
    }
}
